using AutoMapper;
using CredixAPI.Communication.Request;
using CredixAPI.Communication.Response;
using CredixAPI.Domain.Entities;

namespace CredixAPI.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestMapper();
        ResponseMapper();
    }

    private void RequestMapper()
    {
        CreateMap<RequestLoansJson, Loan>();
        
    }

    private void ResponseMapper()
    {
        CreateMap<Loan, ResponseRegisterJson>();
    }
}