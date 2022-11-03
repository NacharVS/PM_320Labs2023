using CreateCharacterWarcraftWpf.Equipments;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace CreateCharacterWarcraftWpf
{
    public class Character
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        public string name;
        public int healthPoint;
        public int manaPoint;
        public int attack;
        public double protDet;
        public int skillPoint;
        public int strength;
        public int strengthMax;
        public int dexterity;
        public int dexterityMax;
        public int constitution;
        public int constitutionMax;
        public int intelligence;
        public int intelligenceMax;
        public int experience;
        public int level;
        public List<string> activeAbility = new List<string>();
        public List<string> inventory = new List<string>();
        public string[] equipments = {"None", "None", "None" };
        public Character(string name, int healthPoint, int manaPoint, int attack, double protDet, int skillPoint, int strength, int strengthMax,
            int dexterity, int dexterityMax, int constitution, int constitutionMax, int intelligence,
            int intelligenceMax, int experience, int level, List<string> activeAbility, List<string> inventory, string[] equipments)
        {
            this.name = name;
            this.healthPoint = healthPoint;
            this.manaPoint = manaPoint;
            this.attack = attack;
            this.protDet = protDet;
            this.skillPoint = skillPoint;
            this.strength = strength;
            this.strengthMax = strengthMax;
            this.dexterity = dexterity;
            this.dexterityMax = dexterityMax;
            this.constitution = constitution;
            this.constitutionMax = constitutionMax;
            this.intelligence = intelligence;
            this.intelligenceMax = intelligenceMax;
            this.experience = experience;
            this.level = level;
            this.activeAbility = activeAbility;
            this.inventory = inventory;
        }

        public string getInfo()
        {
            return (name + ", class: " + Convert.ToString(GetType()).Substring(24) + ", hp: " + healthPoint + ", mp: " + manaPoint + ", ap: " + attack
                + ", protDet: " + protDet + ", sp :" + skillPoint + ", str: " + strength + ", dex: " + dexterity + ", con: " + constitution
                + ", int: " + intelligence);
        }

        public bool alive()
        {
            if(healthPoint > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Attack(Character unit)
        {
            healthPoint = healthPoint - unit.attack;
        }
    }
}