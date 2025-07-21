using CredixAPI.Communication.Request;
using CredixAPI.Communication.Response;

namespace CredixAPI.Application.UseCases.Register;

public interface IRegisterUseCase
{
    public Task<ResponseRegisterJson> Execute(RequestLoansJson request);
}