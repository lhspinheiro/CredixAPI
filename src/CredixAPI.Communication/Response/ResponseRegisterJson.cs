namespace CredixAPI.Communication.Response;

public class ResponseRegisterJson
{
    public string Costumer { get; set; } = string.Empty;
    
    public List<ResponseLoans> loans { get; set; }

    
}