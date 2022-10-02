using CharacterCreator.Core;

namespace CharacterCreator.Data.Interfaces;

public interface IAbilityRepository
{
    public IEnumerable<Ability> GetAllAbilities();

    public void AddDefaultAbilities();

    public Ability GetAbilityByName(string name);
}