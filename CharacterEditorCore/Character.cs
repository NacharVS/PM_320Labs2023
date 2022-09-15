using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    [Serializable]
    public abstract class Character
    {
        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;
        protected int availablePoints;

        public double manaPoints;
        public double healthPoints;
        public double attack;
        public double physicalDefense;
        public double magicAttack;

        public virtual int Strength { get; set; }
        public virtual int Dexterity { get; set; }
        public virtual int Constitution { get; set; }
        public virtual int Intelligence { get; set; }
    }
}
