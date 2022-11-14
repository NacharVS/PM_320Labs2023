namespace Tenders.Data.Users;

public class Designer : User
{
    public string Name { get; set; }
    public string PSRN { get; set; } //ОГРН
    public string TIN { get; set; } //ИНН
    public string TRRC { get; set; } //КПП
    public string Address { get; set; }
    public string Director { get; set; }
    public string MainProjectEngineer { get; set; }

    public Designer(string login, string password, string email, string phoneNumber, string name, string psrn, string tin, 
                    string trrc, string address, string director, string mainProjectEngineer)
                    : base(login, password, email, phoneNumber)
    {
        Name = name;
        PSRN = psrn;
        TIN = tin;
        TRRC = trrc;
        Address = address;
        Director = director;
        MainProjectEngineer = mainProjectEngineer;
    }
    
    public Designer(UserModel model) : base(model)
    {
        Name = model.Name;
        PSRN = model.PSRN;
        TIN = model.TIN;
        TRRC = model.TRRC;
        Address = model.Address;
        Director = model.Director;
        MainProjectEngineer = model.MainProjectEngineer;
    }
    
    public Designer(User user)
    {
        Login = user.Login;
        Password = user.Password;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
    }
    
    public override string ToString()
    {
        return Name;
    }
}