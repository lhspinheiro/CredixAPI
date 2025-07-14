using AutoMapper;
using CredixAPI.Communication.Request;
using CredixAPI.Communication.Response;
using CredixAPI.Domain.Entities;
using CredixAPI.Infrastructure.Data;

namespace CredixAPI.Application.UseCases.Register;

public class RegisterUseCase : IRegisterUseCase
{
    private readonly AppDbContext  _dbContext;
    private readonly IMapper _mapper;

    public RegisterUseCase(AppDbContext  dbContext, IMapper  mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    
    public async Task<ResponseRegisterJson> Execute(RequestLoansJson request)
    {
        var entity = _mapper.Map<Loan>(request);
        
        await _dbContext.Loans.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return new ResponseRegisterJson
        {
            Costumer = entity.Name,
            loans = new List<ResponseLoans>
            {
                new ResponseLoans
                {
                    type = "PERSONAL",
                    interest_rate = 4
                },
                new ResponseLoans
                {
                    type = "GUARANTEED",
                    interest_rate = 3
                }, new ResponseLoans
                {
                    type = "CONSIGNMENT",
                    interest_rate = 2
                }
            }
        };
    }
}