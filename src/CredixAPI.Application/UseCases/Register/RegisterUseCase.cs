using AutoMapper;
using CredixAPI.Application.Validator;
using CredixAPI.Communication.Event;
using CredixAPI.Communication.Request;
using CredixAPI.Communication.Response;
using CredixAPI.Domain.Entities;
using CredixAPI.Exception;
using CredixAPI.Infrastructure.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace CredixAPI.Application.UseCases.Register;

public class RegisterUseCase : IRegisterUseCase
{
    private readonly AppDbContext  _dbContext;
    private readonly IMapper _mapper;
    private readonly IBus _bus;

    public RegisterUseCase(AppDbContext  dbContext, IMapper  mapper,  IBus bus)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _bus = bus;
    }
    
    public async Task<ResponseRegisterJson> Execute(RequestLoansJson request)
    {
        await Validate(request); 
        
        var entity = _mapper.Map<Loan>(request);
        
        await _dbContext.Loans.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        var eventRequest = new LoansEvent(entity);
        
        await _bus.Publish(eventRequest);
        
        if (request.Income <= 3000)
        {
            return new ResponseRegisterJson
            {
                Costumer = entity.Name,
                loans = new List<ResponseLoans>
                {
                    new ResponseLoans
                    {
                        type = "PERSONAL",
                        interest_rate = 4
                    }, new ResponseLoans
                    {
                        type = "GUARANTEED",
                        interest_rate = 3
                    }
                    
                }
            };
        }
        else if (request.Income > 3000 && request.Income <= 5000 && request.Age < 30 && request.Location == "sp")
        {
            return new ResponseRegisterJson
            {
                Costumer = entity.Name,
                loans = new List<ResponseLoans>
                {
                    new ResponseLoans
                    {
                        type = "PERSONAL",
                        interest_rate = 4
                    }, new ResponseLoans
                    {
                        type = "GUARANTEED",
                        interest_rate = 3
                    }
                }
            };
        } else 
        {
            return new ResponseRegisterJson
            {
                Costumer = entity.Name,
                loans = new List<ResponseLoans>
                {
                    new ResponseLoans
                    {
                        type = "CONSIGNMENT",
                        interest_rate = 2
                    }
                }
            };
        } 
    }

    private async Task Validate(RequestLoansJson request)
    {
        var validator = new ValidatorRequest();

        var result = await validator.ValidateAsync(request);

        if (result.IsValid == false)
        {
            var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessage);
        }

        var userVerify = await _dbContext.Loans.AnyAsync(cpf => cpf.CPF == request.CPF);

        if (userVerify)
        {
            throw new ErrorOnValidationException(new List<string>{"User already exists"});
        }
    }
}