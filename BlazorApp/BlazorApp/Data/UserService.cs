namespace BlazorApp.Data;

public class UserService
{
    private static readonly string[] Names = new[]
    {
        "Billy", "Mary", "Phyllip", "Joseph", "Ernest",
        "Josephine", "Dan", "Pauline", "Elizabeth", "Norma"
    };

    private static readonly string[] Surnames = new[]
    {
        "Henderson", "Thompson", "Murray", "Smith", "Johnson",
        "Davis", "Ross", "Hunter", "Lambert", "Scott"
    };
    
    public List<User> GetUsersList ()
    {
        return Enumerable.Range(1, Random.Shared.Next(1, 10)).Select(index => new User
        {
            Surname = Surnames[Random.Shared.Next(Surnames.Length)],
            Name = Names[Random.Shared.Next(Names.Length)],
            Age = Random.Shared.Next(19,51)
        }).ToList();
    }
}