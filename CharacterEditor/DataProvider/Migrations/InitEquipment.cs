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
            2, 0, 0, 60, 0, 0, 0, 5, 0, 1, 0));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Iron helmet", 30, 15, 30, 5,
            1, 0, 0, 0, 0, 30, 0, 2, 4, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Steel helmet", 10, 15, 40, 5,
            2, 0, 0, 0, 0, 40, 0, 2, 6, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Body, "Iron armor", 30, 15, 30, 5,
            1, 0, 0, 0, 0, 60, 0, 2, 10, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Body, "Steel armor", 10, 15, 40, 5,
            2, 0, 0, 0, 0, 75, 0, 2, 15, 0, 0));

        //rogue
        repository.Save(new Equipment(EquipmentSlot.RightHand,"Iron axe", 15, 20, 20, 5, 
            1, 0, 0, 30, 0, 0, 0, 2, 0, 1, 0));
        repository.Save(new Equipment(EquipmentSlot.RightHand, "Steel axe", 20, 30, 20, 5,
            1, 0, 0, 60, 0, 0, 0, 5, 0, 1, 0));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Fur helmet", 10, 15, 30, 5,
            1, 0, 0, 0, 0, 15, 0, 2, 4, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Leather helmet", 10, 25, 40, 5,
            1, 0, 0, 0, 0, 25, 0, 2, 6, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Body, "Fur armor", 30, 15, 30, 5,
            1, 0, 0, 0, 0, 35, 0, 2, 10, 0, 0));
        repository.Save(new Equipment(EquipmentSlot.Body, "Leather armor", 10, 25, 20, 5,
            1, 0, 0, 0, 0, 45, 0, 2, 15, 0, 0));
        
        //wizard
        repository.Save(new Equipment(EquipmentSlot.RightHand,"Wooden staff", 5, 10, 10, 25, 
            1, 0, 0, 5, 30, 0, 0, 2, 0, 1, 4));
        repository.Save(new Equipment(EquipmentSlot.RightHand, "Stalhgrim staff", 10, 20, 10, 35,
            1, 0, 0, 10, 50, 0, 0, 5, 0, 1, 8));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Novice hood", 5, 10, 30, 5,
            1, 0, 0, 0, 0, 3, 20, 0, 0, 1, 4));
        repository.Save(new Equipment(EquipmentSlot.Helmet, "Adept hood", 5, 10, 40, 5,
            1, 0, 0, 0, 0, 5, 20, 0, 0, 2, 8));
        repository.Save(new Equipment(EquipmentSlot.Body, "Novice robe", 5, 10, 30, 5,
            1, 0, 0, 0, 0, 5, 30, 0, 2, 3, 10));
        repository.Save(new Equipment(EquipmentSlot.Body, "Adept Robe", 5, 10, 20, 5,
            1, 0, 0, 0, 0, 10, 60, 0, 2, 5, 15));
    }
}