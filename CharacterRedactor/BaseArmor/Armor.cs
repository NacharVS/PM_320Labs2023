using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFcharacterictic.Core.interfaces;

namespace WPFcharacterictic.Core.BaseArmor
{
    public class Armor : IHaveName
    {
        [BsonId]
        public string Id { get; set; }
        public ArmorType Type { get; set; }
        protected string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        protected double _health;
        public double Health
        {
            get { return _health; }
            private protected set { _health = value; }
        }
        protected double _mana;
        public double Mana
        {
            get { return _mana; }
            private protected set { _mana = value; }
        }
        protected double _physicalAttack;
        public double PhysicalAttack
        {
            get { return _physicalAttack; }
            private protected set { _physicalAttack = value; }
        }
        protected double _magicAttack;
        public double MagicAttack
        {
            get { return _magicAttack; }
            private protected set { _magicAttack = value; }
        }
        protected double _physicalDefense;
        public double PhysicalDefense
        {
            get { return _physicalDefense; }
            private protected set { _physicalDefense = value; }
        }
        protected double _magicDefense;
        public double MagicDefense
        {
            get { return _magicDefense; }
            private protected set { _magicDefense = value; }
        }

        protected string _whoCan;
        public string WhoCan
        {
            get { return _whoCan; }
            set { _whoCan = value; }
        }

        public Armor(string name, ArmorType type, double health, double mana, 
            double physicalAtt, double magicAtt, double physicalDef, double magicDef, string whoCan)
        {
            Id = Guid.NewGuid().ToString();

            Type = type;
            Name = name;
            Health = health;
            Mana = mana;
            PhysicalAttack = physicalAtt;
            MagicAttack = magicAtt;
            PhysicalDefense = physicalDef;
            MagicDefense = magicDef;
            WhoCan = whoCan; 

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
