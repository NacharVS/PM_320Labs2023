﻿using CharacterEditorCore;
using System.Windows;
using CharacterEditorCore.Items;
using System.Windows.Controls;
using CharacterEditorMongoDataBase;
using UnitsEditor;
using System.Linq;
using System;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    
    public partial class Inventory : Window
    {
        private BaseCharacteristics _selectedCharacter;
        private MainPage _mainWindow;
        private delegate void ItemSelectedDelegate(int operationType, Item item);

        public Inventory(BaseCharacteristics selectedCharacter, MainPage mainWindow)
        {
            InitializeComponent();

            _selectedCharacter = selectedCharacter;
            _mainWindow = mainWindow;
            OnItemSelectedEvent += FillItemsBuffs;
            FillInventory();
            FillItems();
        }

        private void FillItems()
        {
            lvItems.Items.Clear();
            var freeItemsList = ItemsList.ItemList
                .Where(x => _selectedCharacter.Inventory.FirstOrDefault
                (z => z.Name == x.Name) is null);

            foreach (var item in freeItemsList)
            {
                lvItems.Items.Add(item);
            }
            lvItems.InvalidateVisual();
        }

        private void FillInventory()
        {
            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
            lbInventory.DisplayMemberPath = "Name";
            lbInventory.Items.Clear();
            foreach (var item in _selectedCharacter.Inventory)
            {
                lbInventory.Items.Add(item);
            }
        }

        private void FillItemsBuffs(int operationType, Item item)
        {
            _mainWindow.lbStrengthValue.Content = (int.Parse((string)_mainWindow.lbStrengthValue.Content) + item.StrengthChange * operationType).ToString();
            _mainWindow.lbDexterityValue.Content = (int.Parse((string)_mainWindow.lbDexterityValue.Content) + item.DexterityChange * operationType).ToString();
            _mainWindow.lbConstitutionValue.Content = (int.Parse((string)_mainWindow.lbConstitutionValue.Content) + item.ConstitutionChange * operationType).ToString();
            _mainWindow.lbIntelligenceValue.Content = (int.Parse((string)_mainWindow.lbIntelligenceValue.Content) + item.IntelligenceChange * operationType).ToString();

            _mainWindow.tbAttackDamageValue.Text = (int.Parse(_mainWindow.tbAttackDamageValue.Text) + operationType * item.AttackChange).ToString();
            _mainWindow.tbHealthValue.Text = (int.Parse(_mainWindow.tbHealthValue.Text) + operationType * item.HPChange).ToString();
            _mainWindow.tbManaValue.Text = (Convert.ToDouble(_mainWindow.tbManaValue.Text) + operationType * item.ManaChange).ToString();
            _mainWindow.tbMagicAttackValue.Text = (int.Parse(_mainWindow.tbMagicAttackValue.Text) + operationType * item.MagicalAttackChange).ToString();
            _mainWindow.tbPhysicalDefValue.Text = (Convert.ToDouble(_mainWindow.tbPhysicalDefValue.Text) + operationType * item.PdefChange).ToString();

            switch (_selectedCharacter.GetType().Name)
            {
                case "Warrior":
                    _mainWindow.tbAttackDamageValue.Text = (int.Parse(_mainWindow.tbAttackDamageValue.Text) + operationType * (5 * item.StrengthChange + item.DexterityChange)).ToString();
                    _mainWindow.tbHealthValue.Text = (int.Parse(_mainWindow.tbHealthValue.Text) + operationType * (2 * item.StrengthChange + 10 * item.ConstitutionChange)).ToString();
                    _mainWindow.tbManaValue.Text = (Convert.ToDouble(_mainWindow.tbManaValue.Text) + operationType * (5 * item.IntelligenceChange)).ToString();
                    _mainWindow.tbMagicAttackValue.Text = (int.Parse(_mainWindow.tbMagicAttackValue.Text) + operationType * (item.IntelligenceChange)).ToString();
                    _mainWindow.tbPhysicalDefValue.Text = (Convert.ToDouble(_mainWindow.tbPhysicalDefValue.Text) + operationType * (item.DexterityChange + 2 * item.ConstitutionChange)).ToString();
                    break;
                case "Rogue":
                    _mainWindow.tbAttackDamageValue.Text = (int.Parse(_mainWindow.tbAttackDamageValue.Text) + operationType * (2 * item.StrengthChange + 4 * item.DexterityChange)).ToString();
                    _mainWindow.tbHealthValue.Text = (int.Parse(_mainWindow.tbHealthValue.Text) + operationType * (item.StrengthChange + 6 * item.ConstitutionChange)).ToString();
                    _mainWindow.tbManaValue.Text = (Convert.ToDouble(_mainWindow.tbManaValue.Text) + operationType * (1.5 * item.IntelligenceChange)).ToString();
                    _mainWindow.tbMagicAttackValue.Text = (int.Parse(_mainWindow.tbMagicAttackValue.Text) + operationType * (2 * item.IntelligenceChange)).ToString();
                    _mainWindow.tbPhysicalDefValue.Text = (Convert.ToDouble(_mainWindow.tbPhysicalDefValue.Text) + operationType * (1.5 * item.DexterityChange + 0 * item.ConstitutionChange)).ToString();
                    break;
                case "Wizzard":
                    _mainWindow.tbAttackDamageValue.Text = (int.Parse(_mainWindow.tbAttackDamageValue.Text) + operationType * (3 * item.StrengthChange + 0 * item.DexterityChange)).ToString();
                    _mainWindow.tbHealthValue.Text = (int.Parse(_mainWindow.tbHealthValue.Text) + operationType * (item.StrengthChange + 3 * item.ConstitutionChange)).ToString();
                    _mainWindow.tbManaValue.Text = (Convert.ToDouble(_mainWindow.tbManaValue.Text) + operationType * (2 * item.IntelligenceChange)).ToString();
                    _mainWindow.tbMagicAttackValue.Text = (int.Parse(_mainWindow.tbMagicAttackValue.Text) + operationType * (5 * item.IntelligenceChange)).ToString();
                    _mainWindow.tbPhysicalDefValue.Text = (Convert.ToDouble(_mainWindow.tbPhysicalDefValue.Text) + operationType * (0.5 * item.DexterityChange + 1 * item.ConstitutionChange)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void lbInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var deletedItem = (Item)lbInventory.SelectedItem;
            if (deletedItem is null)
            {
                return;
            }
            OnItemSelectedEvent?.Invoke(-1, deletedItem);
            _selectedCharacter.RemoveItem(deletedItem);
            lbInventory.Items.Remove(deletedItem);
            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
            FillItems();
            if (_mainWindow.tbCharacterName.Text == "")
            {
                return;
            }
            if (_mainWindow.cbNewCharacters.SelectedItem is null
                && _mainWindow.cbExistCharacters.SelectedItem is null)
            {
                return;
            }
            if (_mainWindow.cbNewCharacters.SelectedItem is null)
            {
                _mainWindow.CharContext.UpdateInventory(
            ((CharacterIdName)_mainWindow.cbExistCharacters.SelectedItem).Id,
            _selectedCharacter);
            }
        }

        private void lvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Item)lvItems.SelectedItem;
            if(item is null)
            { 
                return;
            }
            if (_selectedCharacter.InventCapacity > lbInventory.Items.Count && _selectedCharacter.Lvl.CurrentLevel >= item.MinimumLevel
                && _selectedCharacter.Inventory.FirstOrDefault(x => x.ItemType == item.ItemType) is null)
            {
                _selectedCharacter.AddItem(item);
                lbInventory.Items.Add(item);
                OnItemSelectedEvent?.Invoke(1, item);
            }

            FillItems();
            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
            if(_mainWindow.tbCharacterName.Text == "")
            {
                return;
            }
            if(_mainWindow.cbNewCharacters.SelectedItem is null
                && _mainWindow.cbExistCharacters.SelectedItem is null)
            {
                return;
            }
            if(_mainWindow.cbNewCharacters.SelectedItem is null)
            {
                _mainWindow.CharContext.UpdateInventory(
            ((CharacterIdName)_mainWindow.cbExistCharacters.SelectedItem).Id,
            _selectedCharacter);
            }
        }
        private event ItemSelectedDelegate OnItemSelectedEvent;
    }
}
