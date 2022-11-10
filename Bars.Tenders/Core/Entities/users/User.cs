using Core.Enums;

namespace Core.Entities.users;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
}