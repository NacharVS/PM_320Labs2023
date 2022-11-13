using Core.Enums;

namespace Core.Entities.Users;
/// <summary>
/// Базовое представление пользователя
/// </summary>
public class BaseUser : BaseEntity
{
    public string? Name { get; set; }
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public UserRole Role { get; set; }
}