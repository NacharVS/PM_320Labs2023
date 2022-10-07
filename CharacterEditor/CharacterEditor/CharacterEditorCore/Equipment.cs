namespace CharacterEditorCore.Items
{
    public class Equipment
    {
        public int MaxAvailableHelmetRang { get; private set; }
        public int MaxAvailablBreastplateRang { get; private set; }
        public int MaxAvailableWeaponRang { get; private set; }

        private Helmet _helmet;
        public Helmet Helmet
        {
            get { return _helmet; }
            set
            {
                if (value.Rang <= MaxAvailableHelmetRang)
                {
                    _helmet = value;
                }
            }
        }

        private Breastplate _breastplate;
        public Breastplate Breastplate
        {
            get { return _breastplate; }
            set
            {
                if (value.Rang <= MaxAvailablBreastplateRang)
                {
                    _breastplate = value;
                }
            }
        }

        private Weapon _weapon;
        public Weapon Weapon
        {
            get { return _weapon; }
            set
            {
                if (value.Rang <= MaxAvailableWeaponRang)
                {
                    _weapon = value;
                }
            }
        }

        public Equipment(int maxAvailableHelmetRang,
            int maxAvailablBreastplateRang, int maxAvailableWeaponRang)
        {
            MaxAvailableHelmetRang = maxAvailableHelmetRang;
            MaxAvailablBreastplateRang = maxAvailablBreastplateRang;
            MaxAvailableWeaponRang = maxAvailableWeaponRang;
        }
    }
}