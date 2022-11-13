namespace Core.Entities.Users;

/// <summary>
/// Застройщик
/// </summary>
public class Builder : BaseUser
{
    public string? PSRN { get; set; }
    public string? TIN { get; set; }
    public string? TRRC { get; set; }
    public string? Address { get; set; }
    public string? Director { get; set; }
}