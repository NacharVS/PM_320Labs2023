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
    
    public Task<Data.User[]> GetUserAsync(DateTime startDate)
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Data.User
        {
            Name = Names[Random.Shared.Next(Names.Length)],
            Surname = Surnames[Random.Shared.Next(Surnames.Length)],
            Age = Random.Shared.Next(19,51)
        }).ToArray());
    }
}