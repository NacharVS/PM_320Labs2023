using System;
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
        public MainWindow()
        {
            InitializeComponent();

            _characterRepository = new CharacterRepository(((App)Application.Current).connection);
            
            OnStatChangedEvent += delegate
            {
                FillData();
            };
        }

        private void CharacterClassList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenCharacterName = ((ComboBoxItem) e.AddedItems[0]).Content.ToString();
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
                default:
                    break;
            };
            
            if (_selectedCharacter is null)
                return;

            FillData();
        }

        private void CharactersListUpdate(string className)
        {
            CharactersList.ItemsSource = _characterRepository.GetAllByClassName(className);
            CharactersList.DisplayMemberPath = "Name";
        }
        
        private void CharactersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharactersList.Items.Count != 0 && CharactersList.SelectedIndex != -1)
            {
                _selectedCharacter = (Character) CharactersList.Items[CharactersList.SelectedIndex];
                FillData();
            }
        }
        
        private void CharactersList_OnDropDownOpened(object? sender, EventArgs e)
        {
            if (CharacterClassList.SelectionBoxItem is not null)
                CharactersListUpdate(CharacterClassList.SelectionBoxItem.ToString());
        }

        private void FillData()
        {
            NameTextBox.Text = _selectedCharacter.Name;
            AvailableSkillPointsValueLabel.Content = _selectedCharacter.SkillPoints;
            
            StrengthValueLabel.Content = _selectedCharacter?.Strength;
            DexterityValueLabel.Content = _selectedCharacter?.Dexterity;
            ConstitutionValueLabel.Content = _selectedCharacter?.Constitution;
            IntelligenceValueLabel.Content = _selectedCharacter?.Intelligence;

            HPValueLabel.Content = _selectedCharacter?.HealthPoint;
            ManaValueLabel.Content = _selectedCharacter?.Mana;
            PhysAttackValueLabel.Content = _selectedCharacter?.PhysAttack;
            PhysDefenseValueLabel.Content = _selectedCharacter?.PhysDefense;
            MagicalAttackValueLabel.Content = _selectedCharacter?.MagicalAttack;
            UpdateInventory();
        }

        private void StrengthIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Strength += 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void StrengthDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Strength -= 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void DexterityIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Dexterity += 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void DexterityDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Dexterity -= 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void ConstitutionIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Constitution += 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void ConstitutionDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Constitution -= 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void IntelligenceIncrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Intelligence += 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private void IntelligenceDecrementBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedCharacter.Intelligence -= 1;
            OnStatChangedEvent?.Invoke();
        }
        
        private delegate void OnStatChangedDelegate();

        private event OnStatChangedDelegate OnStatChangedEvent;
        
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null)
                return;

            _selectedCharacter.Name = NameTextBox.Text;
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
            

            Item item = new Item {Name = ItemNameTextBox.Text};
            _selectedCharacter.AddItemToInventory(item);
            UpdateInventory();
        }

        private void UpdateInventory()
        {
            InventoryListBox.ItemsSource = _selectedCharacter!.Inventory;
            InventoryListBox.InvalidateVisual();
        }

        private void RemoveInventoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacter is null || InventoryListBox.SelectedItem is null)
                return;
            
            _selectedCharacter.RemoveItemFromInventory((Item) InventoryListBox.SelectedItem);
            UpdateInventory();
        }
    }
}