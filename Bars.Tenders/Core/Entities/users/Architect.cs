namespace Core.Entities.users;

public class Architect : User
{
    public string PSRN { get; set; }
    public string TIN { get; set; }
    public string TRRC { get; set; }
    public string Address { get; set; }
    public string Director { get; set; }
    public string MainEngineer { get; set; }
}