namespace CredixAPI.Domain.Entities;

public class Loan
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Income { get; set; }
    public string Location { get; set; } = string.Empty;
}