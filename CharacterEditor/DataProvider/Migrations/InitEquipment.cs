using DataProvider.Domain.Impl;
using DataProvider.Models;
using Editor.Core.Inventory;

namespace DataProvider.Migrations;

public class InitEquipment
{
    public void Up()
    {
        var repository = new EquipmentRepository(
            new MongoConnection<EquipmentDb>("mongodb://localhost", "Characters", "Equipment"));

        //warrior
        repository.Save(new Equipment(EquipmentSlot.RightHand,"Iron sword", 30, 15, 20, 5, 
            1, 0, 0, 30, 0, 0, 0, 2, 0, 1, 0));
        repository.Save(new Equipment(EquipmentSlot.RightHand, "Silver sword", 40, 15, 20, 5,
            1, 0, 0, 60, 0, 0, 0, 5, 0, 1, 0));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Iron helmet", 30, 15, 30, 5,
            1, 0, 0, 0, 0, 30, 0, 2, 4, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Steel helmet", 10, 15, 40, 5,
            1, 0, 0, 0, 0, 40, 0, 2, 6, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Body, "Iron armor", 30, 15, 30, 5,
            1, 0, 0, 0, 0, 60, 0, 2, 10, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Steel armor", 10, 15, 40, 5,
            1, 0, 0, 0, 0, 75, 0, 2, 15, 0, 0));

        //rogue
    }
}