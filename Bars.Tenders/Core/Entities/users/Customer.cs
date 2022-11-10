using Core.Enums;

namespace Core.Entities.users;

public class Customer : User
{
    public IndustryType Industry { get; set; }
}