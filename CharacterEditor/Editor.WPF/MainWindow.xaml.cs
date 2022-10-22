using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataProvider;
using DataProvider.Domain.Impl;
using DataProvider.Migrations;
using DataProvider.Models;
using Editor.Core.Abilities;
using Editor.Core.Characters;
using Editor.Core.Inventory;

namespace Editor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MongoProvider<Character> _characterProvider;
        private MongoProvider<Ability> _abilityProvider;
        private MongoProvider<Equipment> _equipmentProvider;

        private Character? _currentCharacter;
        private const int StartSkillPoints = 5;

        private IEnumerable<Ability?>? _starterAbilities;
        public MainWindow()
        {
            InitializeComponent();
            InitializeProviders();
            
            _starterAbilities = _abilityProvider?.LoadAll();
            InitializeAbilitiesList(_starterAbilities);

            OnSkillChange += delegate (Character? sender, string propName, int val)
            {
                if (sender != null)
                {
                    var property = sender
                        .GetType()
                        .GetProperty(propName);

                    var currVal = property?.GetValue(sender);

                    property?.SetValue(sender, (int)(currVal ?? 0) + val);
                    FillData();
                }
            };
        }

        private void comboCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenCharacterName = ((ComboBoxItem)e.AddedItems[0]!)?.Content.ToString();
            switch (chosenCharacterName)
            {
                case "Warrior":
                    _currentCharacter = new Warrior(StartSkillPoints, 0, _starterAbilities, null, 
                        new List<InventoryItem?>(_equipmentProvider.LoadAll()));
                    InitializeEvents();
                    break;
                case "Rogue":
                    _currentCharacter = new Rogue(StartSkillPoints, 0, _starterAbilities, null, 
                        new List<InventoryItem?>(_equipmentProvider.LoadAll()));
                    InitializeEvents();
                    break;
                case "Wizard":
                    _currentCharacter = new Wizard(StartSkillPoints, 0, _starterAbilities, null, 
                        new List<InventoryItem?>(_equipmentProvider.LoadAll()));
                    InitializeEvents();
                    break;
            }

            FillData();
            InitializeInventory();
        }

        private void FillData()
        {
            var stats = _currentCharacter.GetStats();

            lbSkillPointsVal.Content = _currentCharacter?.AvailableSkillPoints;

            lbStrengthVal.Content = stats.Strength;
            lbDexterityVal.Content = stats.Dexterity;
            lbConstitutionVal.Content = stats.Constitution;
            lbIntelligenceVal.Content = stats.Intelligence;

            lbHPVal.Content = stats.Health;
            lbMPVal.Content = stats.Mana;

            lbPAtkVal.Content = stats.PhysicalDamage;
            lbPDefVal.Content = stats.PhysicalDefense;
            lbMAtkVal.Content = stats.MagicDamage;
            lbMDefVal.Content = stats.MagicDefense;

            tbName.Text = _currentCharacter?.Name;

            lbExpPoints.Content = _currentCharacter.Experience;
            lbLevel.Content = _currentCharacter.Level;

            lbHelmet.Content = _currentCharacter?.GetEquipment()
                .FirstOrDefault(x => x.IsEquipped && x.Slot == EquipmentSlot.Helmet)
                ?.Name;
            lbBody.Content = _currentCharacter?.GetEquipment()
                .FirstOrDefault(x => x.IsEquipped && x.Slot == EquipmentSlot.Body)
                ?.Name;
            lbWeapon.Content = _currentCharacter?.GetEquipment()
                .FirstOrDefault(x => x.IsEquipped && x.Slot == EquipmentSlot.RightHand)
                ?.Name;

            InitializeAbilitiesList(_currentCharacter?.Abilities?.Where(x => x?.IsApplied == false));
        }

        private void btnDecrStrength_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Strength", -1);

        }

        private void btnDecrDexterity_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Dexterity", -1);
        }

        private void btnDecrConstitution_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Constitution", -1);
        }

        private void btnDecrIntelligence_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Intelligence", -1);
        }

        private void btnIncrStrength_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Strength", 1);
        }

        private void btnIncrDexterity_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Dexterity", 1);
        }

        private void btnIncrConstitution_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Constitution", 1);
        }

        private void btnIncrIntelligence_Click(object sender, RoutedEventArgs e)
        {
            OnSkillChange?.Invoke(_currentCharacter, "Intelligence", 1);
        }

        public delegate void HandleSkillChange(Character? character, string propertyName, int val);
        public event HandleSkillChange? OnSkillChange;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter != null)
            {
                if (tbName.Text == "")
                {
                    MessageBox.Show("Enter the correct name");
                    return;
                }

                _currentCharacter.Name = tbName.Text;

                _characterProvider.Save(_currentCharacter);
                MessageBox.Show("Successfully saved");
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter != null)
            {
                var dbCharacter = _characterProvider.Load(tbName.Text);
                if (dbCharacter is not null)
                {
                    _currentCharacter = dbCharacter;
                    InitializeEvents();
                    InitializeInventory();
                    MessageBox.Show("Successfully loaded");
                    FillData();
                }
                else
                {
                    MessageBox.Show("No saved copies found");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter != null)
            {
                _characterProvider.Delete(_currentCharacter);
                MessageBox.Show("Successfully deleted");
            }
        }

        private void btnAddExp_Click(object sender, RoutedEventArgs e)
        {
            int exp;

            if (int.TryParse(tbExpAmount.Text, out exp))
            {
                if (_currentCharacter != null)
                {
                    _currentCharacter.Experience += exp;
                }
            }
            
        }

        private void InitializeEvents()
        {
            if (_currentCharacter != null)
            {
                _currentCharacter.OnExperienceChange += (sender, _) =>
                {
                    lbExpPoints.Content = sender.Experience;
                    lbLevel.Content = sender.Level;
                };

                _currentCharacter.OnLevelChange += (sender, _) =>
                {
                    if (sender.Level % 3 == 0)
                    {
                        btnChooseAbility.IsEnabled = true;
                    }
                    lbSkillPointsVal.Content = _currentCharacter.AvailableSkillPoints;
                };
            }
        }

        private void InitializeProviders()
        {
            _characterProvider = new MongoProvider<Character>(new CharacterRepository(new
                MongoConnection<CharacterDb>("mongodb://localhost", "Characters", "Characters")));

            _abilityProvider = new MongoProvider<Ability>(new AbilityRepository(new
                MongoConnection<AbilityDb>("mongodb://localhost", "Characters", "Abilities")));

            _equipmentProvider = new MongoProvider<Equipment>(new EquipmentRepository(
                new MongoConnection<EquipmentDb>("mongodb://localhost", "Characters", "Equipment")));
        }

        private void InitializeAbilitiesList(IEnumerable<Ability> abilities)
        {
            comboAbilities.Items.Clear();
            foreach (var i in abilities)
            {
                comboAbilities.Items.Add(i.Name);
            }
        }

        private void InitializeInventory()
        {
            comboInventory.Items.Clear();
            foreach (var i in _currentCharacter.Inventory)
            {
                comboInventory.Items.Add(i.Name);
            }

            lbInvCapacity.Content = (_currentCharacter.InventoryCapacity - _currentCharacter.Inventory.Count);
        }

        private void btnChooseAbility_Click(object sender, RoutedEventArgs e)
        {
            string? value = (string?)comboAbilities.SelectedItem;

            if (_currentCharacter != null)
            {
                _currentCharacter.Abilities!.FirstOrDefault(x => x?.Name == value)?.Apply(_currentCharacter);

                if (_currentCharacter.Abilities != null)
                    InitializeAbilitiesList(_currentCharacter.Abilities.Where(x => x != null && !x.IsApplied)!);

                btnChooseAbility.IsEnabled = false;
                FillData();
            }
        }

        private void btnAddInvItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentCharacter?.AddItemToInventory(new InventoryItem(tbInvItem.Text));
                comboInventory.Items.Add(tbInvItem.Text);
                lbInvCapacity.Content = (_currentCharacter?.InventoryCapacity - _currentCharacter?.Inventory.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveInvItem_Click(object sender, RoutedEventArgs e)
        {
            string? value = (string?)comboInventory.SelectedItem;

            if (_currentCharacter != null && value != null)
            {
                _currentCharacter.RemoveItemFromInventory(value);
                comboInventory.Items.Remove(comboInventory.SelectionBoxItem);
                tbInvItem.Text = "";
                lbInvCapacity.Content = (_currentCharacter?.InventoryCapacity - _currentCharacter?.Inventory.Count);
            }
        }

        private void btnEquip_Click(object sender, RoutedEventArgs e)
        {
            string? value = (string?)comboInventory.SelectedItem;
            if (value != null)
            {
                try
                {
                    _currentCharacter?.EquipItem(value);
                    FillData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Choose item to equip");
            }
            
        }

        private void btnunequip_Click(object sender, RoutedEventArgs e)
        {
            string? value = (string?)comboInventory.SelectedItem;
            if (value != null)
            {
                try
                {
                    _currentCharacter?.UnequipItem(value);
                    FillData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Choose item to unequip");
            }
        }

        private void Inventory_Selection_changed(object sender, SelectionChangedEventArgs e)
        {
            textItemDescr.Text = _currentCharacter?.GetInventoryItem(comboInventory.SelectedItem?.ToString() ?? string.Empty)?.GetDescription();
        }

        private void btn_Up_Migrations_Click(object sender, RoutedEventArgs e)
        {
            new InitAbilities().Up();
            new InitEquipment().Up();
        }
    }
}
