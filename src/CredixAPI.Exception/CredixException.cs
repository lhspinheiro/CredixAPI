using System.Net;

namespace CredixAPI.Exception;

public abstract class CredixException : System.Exception
{
    public abstract List<string> ErrorMessages();
    public abstract HttpStatusCode ErrorStatusCode();
}