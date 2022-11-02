using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using Units_Practic.Abilities;
using Units_Practic.Items;
using Units_Practic.Items.ChestArmors;
using Units_Practic.Items.Helmets;
using Units_Practic.Items.OtherItems;
using Units_Practic.Items.Weapons;

namespace Units_Practic.Characters
{
    public enum Units
    {
        Warrior,
        Rogue,
        Wizard
    }
    [BsonDiscriminator("Unit")]
    public abstract class Unit
    {
        public ObjectId _id;

        public string name;
        public double healthPoint;
        public double manaPoint;
        public Characteristics characteristics;

        public Lvl lvl;
        public double atackPoint;
        public double physicalProtectionPoint;
        public double magicAtackPoint;

        public List<Item> inventory = new List<Item>();
        public List<Item> avaibleItems;

        public Equipment equipment;

        public Unit()
        {
            lvl = new Lvl();
            equipment = new Equipment();

            UpdateAvaibleItems();
        }

        public void UpdateAvaibleItems()
        {
            avaibleItems = new List<Item>
            {
                new RogueGuildHood(), new RogueGuildArmor(), new IronDaggers(),
                new IronHelmet(), new IronChestArmor(), new IronSword(),
                new ScientistTiara(), new GuildMasterArmor(), new Stick(),
                new Apple(), new Bread(), new Leather()
            };
        }

        public override string ToString()
        {
            return name;
        }

        public void UpdateHaracteristics()
        {
            healthPoint = characteristics.HealthUpdate(characteristics.type);
            manaPoint = characteristics.ManaUpdate(characteristics.type);
            atackPoint = characteristics.AttackUpdate(characteristics.type);
            magicAtackPoint = characteristics.ManaAttackUpdate(characteristics.type);
            physicalProtectionPoint = characteristics.PhysicalProtectionUpdate(characteristics.type);
        }
    }
}