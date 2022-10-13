using CharacterCreator.Core;
using CharacterCreator.Data.Interfaces;
using CharacterCreator.Data.Models;
using MongoDB.Driver;

namespace CharacterCreator.Data.Repositories;

public class EquipmentRepository : IRepository<Equipment>
{
    private DbConnection<EquipmentDbModel> _dbConnection;

    public EquipmentRepository(DbConnection<EquipmentDbModel> connection)
    {
        _dbConnection = connection;
    }


    public IEnumerable<Equipment> GetAllEntities()
    {
        IEnumerable<EquipmentDbModel> res = _dbConnection.Collection.Find(x => true).ToEnumerable();

        return res.Select(ConvertModelToEntity);
    }

    public Equipment GetEntityById(string id)
    {
        Equipment result = ConvertModelToEntity(_dbConnection.Collection.Find(x => x.Id == id).FirstOrDefault());
        return result;
    }

    public IEnumerable<Equipment> GetEquipmentsBytType(EquipmentType type)
    {
        return _dbConnection.Collection.Find(x => x.EquipmentType ==
                                                  type.ToString()).ToEnumerable().Select(ConvertModelToEntity);
    }

    public void Save(Equipment entity)
    {
        bool entityInDB = _dbConnection.Collection.Find(x => x.Name == entity.Name).FirstOrDefault() is not null;

        if (entityInDB)
            return;

        EquipmentDbModel entityToSave = new EquipmentDbModel(entity.Type.ToString(), entity.Name, entity.RequiredLevel,
            entity.RequiredStrength, entity.RequiredDexterity, entity.RequiredConstitution, entity.RequiredIntelligence,
            entity.Strength, entity.Constitution, entity.Dexterity, entity.Intelligence, entity.HealthPoint,
            entity.ManaPoint, entity.PhysAttack, entity.PhysDefense, entity.MagicalAttack, entity.IsEquipped);

        _dbConnection.Collection.InsertOne(entityToSave);
    }

    public void Delete(string id)
    {
        try
        {
            _dbConnection.Collection.DeleteOne(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void Update(Equipment entity, string id)
    {
        throw new Exception();
    }

    public Equipment ConvertModelToEntity(EquipmentDbModel model)
    {
        Equipment resultedEquipment = new Equipment(
            model.Name, model.RequiredLevel, model.RequiredDexterity,
            model.RequiredStrength, model.RequiredIntelligence, model.RequiredConstitution, model.HealthPoint,
            model.ManaPoint, model.PhysAttack, model.PhysDefense, model.MagicalAttack, model.Strength, model.Dexterity,
            model.Intelligence, model.Constitution, Enum.Parse<EquipmentType>(model.EquipmentType), model.IsEquipped
        );

        return resultedEquipment;
    }

    public void AddDefaultEquipments()
    {
        foreach (Equipment eq in CreatedItems.Equipments)
        {
            Save(eq);
        }
    }

}