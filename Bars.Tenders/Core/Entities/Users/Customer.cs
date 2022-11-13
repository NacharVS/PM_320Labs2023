using Core.Enums;

namespace Core.Entities.Users;

/// <summary>
/// Заказчик
/// </summary>
public class Customer : BaseUser
{
    public IndustryType Industry { get; set; }
}