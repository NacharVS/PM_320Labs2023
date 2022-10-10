using DataProvider.Models;
using Editor.Core.Inventory;

namespace DataProvider.Domain.Impl;

public class EquipmentRepository : BaseRepository<Equipment, EquipmentDb>
{
    public EquipmentRepository(MongoConnection<EquipmentDb> connection) : base(connection)
    {
    }

    protected override Equipment? InitializeEntity(EquipmentDb model)
    {
        return CastToEntity(model);
    }

    protected override Equipment? CastToEntity(EquipmentDb model)
    {
        return new Equipment(
            model.Name,
            model.RequiredStrength,
            model.RequiredDexterity,
            model.RequiredConstitution,
            model.RequiredIntelligence,
            model.EquipmentLevel,
            model.HealthPoints,
            model.ManaPoints,
            model.PhysicalDamage,
            model.MagicDamage,
            model.PhysicalDefense,
            model.MagicDefense
        );
    }
}