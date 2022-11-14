using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tenders.Data.Users;

public class UserModel
{
    [BsonId] public ObjectId Id { get; set; }
    [BsonIgnoreIfDefault] public string Login { get; set; }
    [BsonIgnoreIfDefault] public string Password { get; set; }
    [BsonIgnoreIfDefault] public string Email { get; set; }
    [BsonIgnoreIfDefault] public string PhoneNumber { get; set; }
    [BsonIgnoreIfDefault] public string Name { get; set; }
    [BsonIgnoreIfDefault] public string PSRN { get; set; } //ОГРН
    [BsonIgnoreIfDefault] public string TIN { get; set; } //ИНН
    [BsonIgnoreIfDefault] public string TRRC { get; set; } //КПП
    [BsonIgnoreIfDefault] public string Address { get; set; }
    [BsonIgnoreIfDefault] public string Director { get; set; }
    [BsonIgnoreIfDefault] public string MainProjectEngineer { get; set; }
    [BsonIgnoreIfDefault] public IndustryType IndustryType { get; set; }
    [BsonIgnoreIfDefault] public UserRole Role { get; set; }

    public UserModel(User user)
    {
        if (user is Customer)
        {
            CreateUserModel(new Customer(user));
        }
        else if (user is Designer)
        {
            CreateUserModel(new Designer(user));
        }
        else if (user is Developer)
        {
            CreateUserModel(new Developer(user));
        }
    }
    
    public void CreateUserModel(Customer customer)
    {
        Login = customer.Login;
        Password = customer.Password;
        Email = customer.Email;
        PhoneNumber = customer.PhoneNumber;
        IndustryType = customer.IndustryType;
        Role = UserRole.Customer;
        Name = customer.FullName;
    }

    public void CreateUserModel(Designer designer)
    {
        Login = designer.Login;
        Password = designer.Password;
        Email = designer.Email;
        PhoneNumber = designer.PhoneNumber;
        Name = designer.Name;
        PSRN = designer.PSRN;
        TIN = designer.TIN;
        TRRC = designer.TRRC;
        Address = designer.Address;
        Director = designer.Director;
        MainProjectEngineer = designer.MainProjectEngineer;
        Role = UserRole.Designer;
    }
    
    public void CreateUserModel(Developer developer)                    
    {                                                      
        Login = developer.Login;                            
        Password = developer.Password;                      
        Email = developer.Email;                            
        PhoneNumber = developer.PhoneNumber;                
        Name = developer.Name;                              
        PSRN = developer.PSRN;                              
        TIN = developer.TIN;                                
        TRRC = developer.TRRC;                              
        Address = developer.Address;                        
        Director = developer.Director;
        Role = UserRole.Developer;                          
    }                                                      
}