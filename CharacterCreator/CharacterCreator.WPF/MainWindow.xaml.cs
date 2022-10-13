using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CharacterCreator.Data.Interfaces;
using CharacterCreator.Data.Repositories;

namespace CharacterCreator.Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Character? _selectedCharacter;

        private IRepository<Character> _characterRepository;
        private IRepository<Equipment> _equipmentRepository;
        private IAbilityRepository _abilityRepository;


        public MainWindow()
        {
            InitializeComponent();

            _abilityRepository = new AbilityRepository(((App)Application.Current).abilityDbConnection);
            _characterRepository = new CharacterRepository(((App)Application.Current).characterDbConnection);
            _equipmentRepository = new EquipmentRepository(((App)Application.Current).equipmentDbConnection);

            ((EquipmentRepository)_equipmentRepository).AddDefaultEquipments();
            _abilityRepository.AddDefaultAbilities();

            OnDataChangedEvent += UpdateAvailableAbilities;
            OnDataChangedEvent += UpdateInventory;
            OnDataChangedEvent += UpdateExperienceView;
            OnDataChangedEvent += UpdateStatsView;
        }

        private void CharacterClassList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenCharacterName = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
            switch (chosenCharacterName)
            {
                case "Warrior":
                    _selectedCharacter = new Warrior();
                    break;
                case "Rogue":
                    _selectedCharacter = new Rogue();
                    break;
                case "Wizard":
                    _selectedCharacter = new Wizard();
                    break;
            }

            if (_selectedCharacter is null)
                return;

            OnDataChangedEvent?.Invoke();
        }

        private void CharactersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharactersList.Items.Count != 0 && CharactersList.SelectedIndex != -1)
            {
                _selectedCharacter = (Character)CharactersList.Items[CharactersList.SelectedIndex];
                OnDataChangedEvent?.Invoke();
            }
        }

        private void CharactersList_OnDropDownOpened(object? sender, EventArgs e)
        {
            if (CharacterClassList.SelectionBoxItem is not null)
                CharactersListUpdate(CharacterClassList.SelectionBoxItem.ToString());
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null)
                return;

            _characterRepository.Update(_selectedCharacter, _selectedCharacter.Id ?? "");

            MessageBox.Show("Done");
        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter != null)
            {
                _characterRepository.Delete(_selectedCharacter.Id);
                MessageBox.Show("Done");
            }
        }

        private void AddInventoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null)
                return;

            ItemStorage storage = new ItemStorage(_selectedCharacter);
            if (storage.ShowDialog() == false)
            {
                UpdateInventory();
            }
        }

        private void RemoveInventoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null || InventoryListBox.SelectedItem is null)
                return;

            _selectedCharacter.RemoveItemFromInventory((Equipment)InventoryListBox.SelectedItem);
            OnDataChangedEvent?.Invoke();
        }

        private void ExpUpBtn_OnCLick(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null)
                return;

            int experienceCount = int.Parse(((Button)e.Source).Content.ToString().Split('+')[1]);
            _selectedCharacter.Level.CurrentExperience += experienceCount;
            OnDataChangedEvent?.Invoke();
        }

        private void NameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_selectedCharacter is null)
                return;

            _selectedCharacter.Name = NameTextBox.Text;
        }

        private void AvailableAbilities_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ability chosenAbility = (Ability)((ComboBox)e.Source).SelectedItem;
            if (chosenAbility is null)
                return;
            RequiredLvlLabel.Content = chosenAbility.RequiredLevel + " lvl";
        }

        private void AddAbilityBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null)
                return;

            Ability chosenAbility = (Ability)AvailableAbilities.SelectedItem;

            if (!_selectedCharacter.AddAbility(chosenAbility))
            {
                MessageBox.Show("Слишком низкий уровень");
                return;
            }

            OnDataChangedEvent?.Invoke();
        }


        private void AddedAbilities_OnDropDownOpened(object sender, EventArgs e)
        {
            AddedAbilities.Items.Clear();
            foreach (Ability ability in _selectedCharacter!.Abilities)
            {
                AddedAbilities.Items.Add(ability);
            }

            AddedAbilities.DisplayMemberPath = "Name";
        }

        private void AvailableAbilities_OnDropDownOpened(object? sender, EventArgs e)
        {
            UpdateAvailableAbilities();
        }



        #region UpdateData

        private void UpdateAvailableAbilities()
        {
            AvailableAbilities.Items.Clear();
            
            if (_selectedCharacter!.Abilities.Count > 0)
            {
                foreach (Ability a in _abilityRepository.GetAllAbilities())
                {
                    if (_selectedCharacter!.Abilities.Any(x => x.Name == a.Name))
                        continue;

                    AvailableAbilities.Items.Add(a);
                }
            }
            else
            {
                foreach (var a in _abilityRepository.GetAllAbilities())
                {
                    AvailableAbilities.Items.Add(a);
                }
            }

            AvailableAbilities.DisplayMemberPath = "Name";
        }

        private void UpdateInventory()
        {
            InventoryListBox.ItemsSource = _selectedCharacter!.Inventory.ToArray();
            InventoryListBox.InvalidateVisual();
        }


        private void UpdateStatsView()
        {
            AvailableSkillPointsValueLabel.Content = _selectedCharacter.SkillPoints;
            NameTextBox.Text = _selectedCharacter.Name;
            StrengthValueLabel.Content = _selectedCharacter?.TotalStats.Strength;
            DexterityValueLabel.Content = _selectedCharacter?.TotalStats.Dexterity;
            ConstitutionValueLabel.Content = _selectedCharacter?.TotalStats.Constitution;
            IntelligenceValueLabel.Content = _selectedCharacter?.TotalStats.Intelligence;

            HPValueLabel.Content = _selectedCharacter?.TotalStats.HealthPoint;
            ManaValueLabel.Content = _selectedCharacter?.TotalStats.ManaPoint;
            PhysAttackValueLabel.Content = _selectedCharacter?.TotalStats.PhysAttack;
            PhysDefenseValueLabel.Content = _selectedCharacter?.TotalStats.PhysDefense;
            MagicalAttackValueLabel.Content = _selectedCharacter?.TotalStats.MagicalAttack;
        }

        private void UpdateExperienceView()
        {
            ExpValue.Content = _selectedCharacter.Level.CurrentExperience;
            NextLvlExpValue.Content = _selectedCharacter.Level.NextLevelExp;
            LvlValue.Content = _selectedCharacter.Level.CurrentLvl;
        }


        private void CharactersListUpdate(string className)
        {
            CharactersList.ItemsSource = ((CharacterRepository)_characterRepository).GetAllByClassName(className);
            CharactersList.DisplayMemberPath = "Name";
        }

        private void UpdateEquipments(ComboBox cb, EquipmentType et)
        {
            int selectedItemIndex = cb.SelectedIndex;
            
            cb.Items.Clear();
            BaseItem[] availableEquipments = _selectedCharacter.Inventory.FindAll(x => x.Type == et).ToArray();
            foreach (BaseItem item in availableEquipments)
            {
                cb.Items.Add(item);
            }
            
            cb.InvalidateVisual();
            
            cb.SelectedIndex = selectedItemIndex;
            cb.DisplayMemberPath = "Name";
        }

        #endregion

        #region StatChanges

        private void StrengthIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Strength += 1;
            OnDataChangedEvent?.Invoke();
        }

        private void StrengthDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Strength -= 1;
            OnDataChangedEvent?.Invoke();
        }

        private void DexterityIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Dexterity += 1;
            OnDataChangedEvent?.Invoke();
        }

        private void DexterityDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Dexterity -= 1;
            OnDataChangedEvent?.Invoke();
        }

        private void ConstitutionIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Constitution += 1;
            OnDataChangedEvent?.Invoke();
        }

        private void ConstitutionDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Constitution -= 1;
            OnDataChangedEvent?.Invoke();
        }

        private void IntelligenceIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Intelligence += 1;
            OnDataChangedEvent?.Invoke();
        }

        private void IntelligenceDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Intelligence -= 1;
            OnDataChangedEvent?.Invoke();
        }

        private void ChestplateChangeComboBox_OnDropDownOpened(object? sender, EventArgs e)
        {
            UpdateEquipments((ComboBox)sender, EquipmentType.Chestplate);
        }
        
        private void HelmetChangeComboBox_OnDropDownOpened(object? sender, EventArgs e)
        {
            ComboBox? cb = (ComboBox) sender;
            UpdateEquipments(cb, EquipmentType.Helmet);
        }

        private void WeaponChangeComboBox_OnDropDownOpened(object? sender, EventArgs e)
        {
            ComboBox? cb = (ComboBox) sender;
            UpdateEquipments(cb, EquipmentType.Weapon);
        }

        #endregion

        private void HelmetChangeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemBoxSelectionChanged((ComboBox) sender);
        }
        private void WeaponChangeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemBoxSelectionChanged((ComboBox) sender);
        }
        private void ChestplateChangeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemBoxSelectionChanged((ComboBox) sender);
        }

        public void ChangeIsEquipped(Equipment eq)
        {
            eq.IsEquipped = !eq.IsEquipped;
        }
        
        private delegate void OnDataChangedDelegate();
        private event OnDataChangedDelegate OnDataChangedEvent;


        

        private void ItemBoxSelectionChanged(ComboBox cb)
        {
            Equipment equipment = (Equipment) cb.SelectedItem;  
            
            if (equipment is null)
                return;

            if (!_selectedCharacter.CanEquip(equipment.Type))
            {
                cb.SelectedIndex = -1;
            }

            if (!_selectedCharacter.CheckItemConvergence(equipment))
            {
                MessageBox.Show("Предмет имеет высокие характеристики!");
                cb.SelectedIndex = -1;
                return;
            }
            
            ChangeIsEquipped(equipment);
            OnDataChangedEvent?.Invoke();
        }

        
    }
}