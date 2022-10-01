using DataProvider.Interfaces;
using Editor.Core;
using Editor.Core.Abilities;
using MongoDB.Driver;

namespace DataProvider;

public class AbilityRepository : IRepository<Ability>
{
    private readonly MongoConnection<AbilityDb> _connection;
    private Dictionary<string, Action<Character>> _abilityActions;

    public AbilityRepository(MongoConnection<AbilityDb> connection)
    {
        _connection = connection;
        InitializeAbilityActions();
        //FirstTimeSetup();
    }

    public Ability? GetById(string id)
    {
        var entity = _connection.Collection.Find(x => x.Id == id).FirstOrDefault();
        return InitializeAbility(entity);
    }

    public Ability? GetByName(string name)
    {
        var entity = _connection.Collection.Find(x => x.Name == name).FirstOrDefault();
        return InitializeAbility(entity);
    }

    public IEnumerable<Ability?> GetAllByName(string name)
    {
        return GetAll().Where(x => x?.Name == name).ToList();
    }

    public IEnumerable<Ability?> GetAll()
    {
        
        var entityCollection = _connection.Collection.Find(_ => true).ToList();
        var abilityCollection = new List<Ability?>();

        entityCollection.ToList().ForEach(x =>
            abilityCollection.Add(InitializeAbility(x)));

        return abilityCollection;
        
    }

    public void Delete(Ability entity)
    {
        _connection.Collection.DeleteOne(x => x.Name == entity.Name);
    }

    public void Update(Ability entity)
    {
        var dbAbility = _connection.Collection
            .Find(x => x.Name == entity.Name).FirstOrDefault();
        _connection.Collection.ReplaceOne(x => x.Id == dbAbility.Id,
            new AbilityDb(dbAbility.Id, entity));
    }

    public void Save(Ability entity)
    {
        _connection.Collection.InsertOne(new AbilityDb(Guid.NewGuid().ToString(), entity));
    }

    public void SaveOrUpdate(Ability entity)
    {
        if (_connection.Collection.
                Find(x =>
                    x.Name == entity.Name).FirstOrDefault() != null)
        {
            Update(entity);
        }
        else
        {
            Save(entity);
        }
    }

    private Ability? InitializeAbility(AbilityDb entity)
    {
        return CastToAbility(entity);
    }

    private Ability? CastToAbility(AbilityDb entity)
    {
        if (entity.Name != null) 
            return new Ability(entity.Name, entity.RequiredLevel, _abilityActions[entity.Name]);
        return null;
    }
    private void FirstTimeSetup()
    {
        Save(new Ability("Upgrade Health", 3));
        Save(new Ability("Upgrade Physical Defense", 3));
        Save(new Ability("Stone skin", 3));
        Save(new Ability("Iron fists", 6));
        Save(new Ability("Genius brain", 6));
        Save(new Ability("Holy arms", 9));
        Save(new Ability("Double Upgrade Health", 9));
        Save(new Ability("Double Upgrade Physical Defense", 3));
        Save(new Ability("Daedra skin", 12));
        Save(new Ability("Valkyrie bless", 12));
    }

    /// <summary>
    /// Дикий костыль за невозможностью хранить делегаты в монго
    /// </summary>
    private void InitializeAbilityActions()
    {
        _abilityActions = new Dictionary<string, Action<Character>>
        {
            {"Upgrade Health", x => x.HealthPoints += 15},
            {"Upgrade Physical Defense", x => x.PhysicalDefense += 10},
            {"Stone skin", x => x.PhysicalDefense += 25},
            {"Iron fists", x => x.PhysicalDamage += 25},
            {"Genius brain", x => x.MagicDamage += 18},
            {"Holy arms", x => x.MagicDamage += 35},
            {"Double Upgrade Health", x => x.HealthPoints += 35},
            {"Double Upgrade Physical Defense", x => x.PhysicalDefense += 35},
            {"Daedra skin", x => x.PhysicalDefense += 55},
            {"Valkyrie bless", x => x.MagicDamage += 55}
        };
    }
}