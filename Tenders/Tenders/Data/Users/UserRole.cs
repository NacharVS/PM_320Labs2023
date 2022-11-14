using System.ComponentModel;

namespace Tenders.Data.Users;

[DefaultValue(Uncpecified)]
public enum UserRole
{
    Uncpecified,
    Customer,
    Designer,
    Developer
}