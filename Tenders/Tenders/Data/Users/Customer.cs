using MongoDB.Bson;

namespace Tenders.Data.Users;

public class Customer : User
{
    public string FullName { get; set; }
    public IndustryType IndustryType { get; set; }

    public Customer(string login, string password, string email, string phoneNumber, string fullName,
                    IndustryType industryType) : base(login, password, email, phoneNumber)
    {
        FullName = fullName;
        IndustryType = industryType;
    }

    public Customer(UserModel model) : base(model)
    {
        FullName = model.Name;
        IndustryType = model.IndustryType;
    }

    public Customer(User user)
    {
        Login = user.Login;
        Password = user.Password;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
    }
    
    public override string ToString()
    {
        return FullName;
    }
}