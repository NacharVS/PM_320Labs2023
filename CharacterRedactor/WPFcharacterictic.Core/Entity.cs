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

        Dictionary<string, bool> _abilities = new Dictionary<string, bool>
        {
            {"one", true},
            {"two", true},
            {"three", true},
            {"four", true},
            {"five", true},
            {"six", true},
            {"seven", true},
            {"eight", true},
            {"nine", true},
            {"ten", true}
        };

        public Dictionary<string, bool> Abilities 
        { 
            get { return _abilities; }
            set { _abilities = value; }
        }
        int _pointAbility;
        int _pointAbilityLvl = 1;

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
                AvailablePoints += 5;
                _expNewLvl += _lvl * 1000;
                _pointAbilityLvl++;
                if (_pointAbilityLvl == 3) 
                {
                    _pointAbilityLvl = 0;
                    _pointAbility++;
                }
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
            if (Level % 3 == 0 && Level != 0 && _pointAbility != 0 && Abilities[ability] == true) 
            {
                Abilities[ability] = false;
                _pointAbility--;
                switch (ability) 
                {
                    case "one":
                        Mana += 10;
                        Health += 10;
                        break;
                    case "two":
                        PhysicalAttack += 10;
                        MagicAttack += 10;
                        break;
                    case "three":
                        PhysicalDefense += 10;
                        MagicDefense += 10;
                        break;
                    case "four":
                        Mana += 10;
                        PhysicalAttack += 10;
                        break;
                    case "five":
                        PhysicalAttack += 10;
                        Health += 10;
                        break;
                    case "six":
                        PhysicalDefense += 10;
                        Mana += 10;
                        break;
                    case "seven":
                        Health += 10;
                        MagicDefense += 10;
                        break;
                    case "eigth":
                        MagicAttack += 10;
                        MagicDefense += 10;
                        break;
                    case "nine":
                        PhysicalDefense += 10;
                        PhysicalDefense += 10;
                        break;
                    case "ten":
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