using CharacterEditorCore;
using CharacterEditorCore.Items;
using System.Windows;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Window
    {
        private Character _character;
        private Helmet _currentHelmet;
        private Breastplate _currentBreasplate;
        private Weapon _currentWeapon;

        public delegate void CharactericticUpdateDelegate();
        public CharactericticUpdateDelegate CharactericticUpdate;


        public Equipment(Character character)
        {
            InitializeComponent();
            _character = character;

            CharactericticUpdate += UpdateCurrentItems;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData();
            FillCurrentItems();
            CharactericticUpdate?.Invoke();
        }

        private void UpdateCurrentItems()
        {
            cbHelmets.SelectedItem = _currentHelmet;
            cbHelmets.InvalidateVisual();

            cbBreastplates.SelectedItem = _currentBreasplate;
            cbBreastplates.InvalidateVisual();

            cbWeapons.SelectedItem = _currentWeapon;
            cbWeapons.InvalidateVisual();
        }

        private void UpdateData()
        {
            if (_character != null)
            {
                cbHelmets.Items.Clear();
                var helmets = _character.GetAvailableHelmets();
                if (helmets != null)
                {
                    foreach (var helmet in helmets)
                    {
                        cbHelmets.Items.Add(helmet);
                    }
                }
                cbHelmets.DisplayMemberPath = "Name";

                cbBreastplates.Items.Clear();
                var breastplates = _character.GetAvailableBreastplates();
                if (breastplates != null)
                {
                    foreach (var breastplate in breastplates)
                    {
                        cbBreastplates.Items.Add(breastplate);
                    }
                }
                cbBreastplates.DisplayMemberPath = "Name";

                cbWeapons.Items.Clear();
                var weapons = _character.GetAvailableWeapons();
                if (weapons != null)
                {
                    foreach (var weapon in weapons)
                    {
                        cbWeapons.Items.Add(weapon);
                    }
                }
                cbWeapons.DisplayMemberPath = "Name";
            }
        }

        private void FillCurrentItems()
        {
            if (_character == null)
            {
                return;
            }

            if (_character.Equipment.Helmet != null)
            {
                _currentHelmet = _character.Equipment.Helmet;
                cbHelmets.Items.Add(_currentHelmet);
            }
            
            if (_character.Equipment.Breastplate != null)
            {
                _currentBreasplate = _character.Equipment.Breastplate;
                cbBreastplates.Items.Add(_currentBreasplate);
            }

            if (_character.Equipment.Weapon != null)
            {
                _currentWeapon = _character.Equipment.Weapon;
                cbWeapons.Items.Add(_currentWeapon);
            }
        }

        private void cbHelmets_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbHelmets.SelectedItem != null)
            {
                if (_currentHelmet != null && _currentHelmet != cbHelmets.SelectedItem)
                {
                    _character.Inventory.AddItem(_currentHelmet);
                }
                _currentHelmet = cbHelmets.SelectedItem as Helmet;
            }
        }

        private void cbBreastplates_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbBreastplates.SelectedItem != null)
            {
                if (_currentBreasplate != null && _currentBreasplate != cbBreastplates.SelectedItem)
                {
                    _character.Inventory.AddItem(_currentBreasplate);
                }
                _currentBreasplate = cbBreastplates.SelectedItem as Breastplate;
            }      
        }

        private void cbWeapons_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbWeapons.SelectedItem != null)
            {
                if (_currentWeapon != null && _currentWeapon != cbWeapons.SelectedItem)
                {
                    _character.Inventory.AddItem(_currentWeapon);
                }
                _currentWeapon = cbWeapons.SelectedItem as Weapon;
            }         
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _character.Equipment.Helmet = _currentHelmet;
                _character.Equipment.Breastplate = _currentBreasplate;
                _character.Equipment.Weapon = _currentWeapon;

                _character.Inventory.Items.Remove(_currentHelmet);
                _character.Inventory.Items.Remove(_currentBreasplate);
                _character.Inventory.Items.Remove(_currentWeapon);
                MessageBox.Show("Equipment successfully saved!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Failed to save!", "Warning");
            }             
        }
    }
}