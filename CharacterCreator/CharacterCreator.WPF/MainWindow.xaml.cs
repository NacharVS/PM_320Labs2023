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
        private ICharacterRepository _characterRepository;
        private IAbilityRepository _abilityRepository;

        public MainWindow()
        {
            InitializeComponent();
            
            _abilityRepository = new AbilityRepository(((App)Application.Current).abilityDbConnection);
            _characterRepository = new CharacterRepository(((App)Application.Current).characterDbConnection);
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

            _characterRepository.InsertOrUpdate(_selectedCharacter);

            MessageBox.Show("Done");
        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter != null)
            {
                _characterRepository.DeleteCharacter(_selectedCharacter.Id);
                MessageBox.Show("Done");
            }
        }

        private void AddInventoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null)
                return;


            Item item = new Item { Name = ItemNameTextBox.Text };
            _selectedCharacter.AddItemToInventory(item);
            UpdateInventory();
        }

        private void RemoveInventoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null || InventoryListBox.SelectedItem is null)
                return;

            _selectedCharacter.RemoveItemFromInventory((Item)InventoryListBox.SelectedItem);
            UpdateInventory();
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
            Ability chosenAbility = (Ability) ((ComboBox) e.Source).SelectedItem;
            if (chosenAbility is null)
                return;
            RequiredLvlLabel.Content = chosenAbility.RequiredLevel + " lvl";
        }

        private void AddAbilityBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null)
                return;
            
            Ability chosenAbility = (Ability) AvailableAbilities.SelectedItem;

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
        
        private delegate void OnDataChangedDelegate();
        private event OnDataChangedDelegate OnDataChangedEvent;


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
            StrengthValueLabel.Content = _selectedCharacter?.Strength;
            DexterityValueLabel.Content = _selectedCharacter?.Dexterity;
            ConstitutionValueLabel.Content = _selectedCharacter?.Constitution;
            IntelligenceValueLabel.Content = _selectedCharacter?.Intelligence;

            HPValueLabel.Content = _selectedCharacter?.HealthPoint;
            ManaValueLabel.Content = _selectedCharacter?.Mana;
            PhysAttackValueLabel.Content = _selectedCharacter?.PhysAttack;
            PhysDefenseValueLabel.Content = _selectedCharacter?.PhysDefense;
            MagicalAttackValueLabel.Content = _selectedCharacter?.MagicalAttack;
        }

        private void UpdateExperienceView()
        {
            ExpValue.Content = _selectedCharacter.Level.CurrentExperience;
            NextLvlExpValue.Content = _selectedCharacter.Level.NextLevelExp;
            LvlValue.Content = _selectedCharacter.Level.CurrentLvl;
        }
        
        
        private void CharactersListUpdate(string className)
        {
            CharactersList.ItemsSource = _characterRepository.GetAllByClassName(className);
            CharactersList.DisplayMemberPath = "Name";
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
        
        #endregion

    }
}