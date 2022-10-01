using MongoDB.Bson.Serialization.Attributes;

namespace WPFcharacterictic.Core
{
    public class Entity
    {
        public delegate void ChangedСharacteristics();
        [BsonId]
        public string Id { get; set; }

        public List<InventoryItem> InventoryItems = new List<InventoryItem>();
        int _maxCountInventoryItem;
        public int MaxCountInventoryItem 
        {
            get { return _maxCountInventoryItem; }
            set { _maxCountInventoryItem = value; }
        }

        List<string> _abilities = new List<string>
        {
            "one","two","three","four","five","six","seven","eight","nine","ten"
        };

        public List<string> Abilities 
        { 
            get { return _abilities; }
            set { _abilities = value; }
        }

        int _expirience = 0;
        int _expNewLvl = 1000;
        public int Expirience
        {
            get { return _expirience; }
            set { _expirience = value; }
        }

        int _lvl = 1;
        public int Level 
        {
            get { return _lvl; }
            set 
            { 
                _lvl = value; 
                _expNewLvl += _lvl * 1000; 
            }
        }

        public int MaxStrength;
        public int MinStrength;
        public int MaxDexterity;
        public int MinDexterity;
        public int MaxConstitution;
        public int MinConstitution;
        public int MaxIntelligence;
        public int MinIntelligence;
        public int AvailablePoints = 5;

        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;

        //
        protected int _health;
        public int Health 
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
        public double _physicalDefense;
        public double PhysicalDefense
        {
            get { return _physicalDefense; }
            private protected set { _physicalDefense = value; }
        }
        public double _magicDefense;
        public double MagicDefense
        {
            get { return _magicDefense; }
            private protected set { _magicDefense = value; }
        }

        string _name;
        public string Name 
        {
            get { return _name; }
            private protected set { _name = value; }
        }

        public Entity()
        {
            Id = Guid.NewGuid().ToString();

            Health = 0;
            Mana = 0;
            PhysicalAttack = 0;
            MagicAttack = 0;
            PhysicalDefense = 0;
            MagicDefense = 0;
        }
        public void UseAbility(string? ability) 
        {
            if (Level % 3 == 0 && Level != 0) 
            { 
                int index = Abilities.IndexOf(ability);
                Abilities.Remove(ability);
                switch (index) 
                {
                    case 0:
                        Mana += 10;
                        Health += 10;
                        break;
                    case 1:
                        PhysicalAttack += 10;
                        MagicAttack += 10;
                        break;
                    case 2:
                        PhysicalDefense += 10;
                        MagicDefense += 10;
                        break;
                    case 3:
                        Mana += 10;
                        PhysicalAttack += 10;
                        break;
                    case 4:
                        PhysicalAttack += 10;
                        Health += 10;
                        break;
                    case 5:
                        PhysicalDefense += 10;
                        Mana += 10;
                        break;
                    case 6:
                        Health += 10;
                        MagicDefense += 10;
                        break;
                    case 7:
                        MagicAttack += 10;
                        MagicDefense += 10;
                        break;
                    case 8:
                        PhysicalDefense += 10;
                        PhysicalDefense += 10;
                        break;
                    case 9:
                        Mana += 10;
                        MagicDefense += 10;
                        break;
                }

            }
        }
        public void AddExpirience(int expAmount)
        {
            Expirience += expAmount;
            if (Expirience >= _expNewLvl)
            {
               ++Level;
            }
        }

        public void AddInventoryItem() 
        {
            if (InventoryItems.Count <= MaxCountInventoryItem)
            {
                var newItem = new InventoryItem();
                newItem.Name = $"{InventoryItems.Count + 1} weapon";

                InventoryItems.Add(newItem);
            }
        }

        public virtual void IncreasedStrength() 
        {
        }
        public virtual void IncreasedDexterity()
        {
        }
        public virtual void IncreasedConstitution()
        {
        }
        public virtual void IncreasedIntelligence()
        {
        }
    }
}