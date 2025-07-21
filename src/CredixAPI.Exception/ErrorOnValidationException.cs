using System.Net;

namespace CredixAPI.Exception;

public class ErrorOnValidationException : CredixException
{
    
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errors)
    {
        _errors = errors;
    }
    
    public override List<string> ErrorMessages() => _errors;
    
    public override HttpStatusCode ErrorStatusCode() => HttpStatusCode.BadRequest;
}