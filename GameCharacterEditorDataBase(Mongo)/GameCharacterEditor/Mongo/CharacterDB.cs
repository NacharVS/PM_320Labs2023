using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class CharacterDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public decimal HP { get; set; } 
        public decimal MP { get; set; } 
        public decimal PDef { get; set; } 
        public decimal Attack { get; set; } 
        public decimal MPAttack { get; set; }

        public CharacterDB (int id, string name, int strength, int dexterity, int constitution, int intelligence, decimal hP, decimal mP, decimal pDef, decimal attack, decimal mPAttack)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            HP = hP;
            MP = mP;
            PDef = pDef;
            Attack = attack;
            MPAttack = mPAttack;
        }
    }
}
