﻿using CharacterEditorCore;
using CharacterEditorMongoDb;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _characterNames = new List<string>()
                                              {"Warrior", "Rogue", "Wizard"};
        private Character _currentCharacter;
        private ICharacterRepository _repository;
        private List<Ability> _abilities = new List<Ability>()
                                                            {new Ability("SpiderHit",10, 0, 5, 0),
                                                             new Ability("BrainStorming", 0, 10, 0, 10),
                                                             new Ability("MongooseReaction", 5, 10, 5, 0),
                                                             new Ability("HulkIntegration", 10, 10, 5, 0)};
        public delegate void CharactericticChangedDelegate();
        public event CharactericticChangedDelegate CharactericticChangedEvent;
        public delegate void CharacterUpdateDelegate();
        public event CharacterUpdateDelegate CharacterUpdateEvent;

        public MainWindow()
        {
            InitializeComponent();
            cbCharacters.ItemsSource = _characterNames;
            
            cbAbilities.DisplayMemberPath = "Name";
            CharactericticChangedEvent += UpdateCharacterInfo;
            CharacterUpdateEvent += UpdateExistingCharacters;
            try
            {
                _repository = new CharacterRepository("mongodb://localhost", "CharacterEditor");
            }
            catch
            {
                MessageBox.Show("Failed to connect to the database","Warning");
            }
        }

        private void UpdateExistingCharacters()
        {
            cbExestingCharacters.ItemsSource = _repository.GetCharacterNames();
        }

        private void UpdateCharacterInfo()
        {
            if (_currentCharacter == null)
            {
                tbCharacterName.Text = "";
                Attack.Content = 0;
                Health.Content = 0;
                PhysicalDefence.Content = 0;
                Mana.Content = 0;
                MagicalAttack.Content = 0;

                strength.Content = 0;
                dexterity.Content = 0;
                constitution.Content = 0;
                intellisense.Content = 0;
                return;
            }

            if (_currentCharacter.Name != null)
            {
                tbCharacterName.Text = _currentCharacter.Name;
            }
            Attack.Content = _currentCharacter.AttackDamage;
            Health.Content = _currentCharacter.Health;
            PhysicalDefence.Content = _currentCharacter.PhysicalDefense;
            Mana.Content = _currentCharacter.Mana;
            MagicalAttack.Content = _currentCharacter.MagicalAttackDamage;

            strength.Content = _currentCharacter.GetStrengthValue();
            dexterity.Content = _currentCharacter.GetDexterityValue();
            constitution.Content = _currentCharacter.GetConstitutionValue();
            intellisense.Content = _currentCharacter.GetIntellisenseValue();

            cbAbilities.ItemsSource = _abilities;  
            cbAbilities.DisplayMemberPath = "Name";
            cbAbilities.InvalidateVisual();
            lbCharacterAbilities.Items.Clear();
            foreach (var ability in _currentCharacter.Abilities)
            {
                lbCharacterAbilities.Items.Add(ability);
            }
            lbCharacterAbilities.DisplayMemberPath = "Name";

            Experience.Content = _currentCharacter.Experience;
            Level.Content = _currentCharacter.Level;
        }

        private void CharactericticChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter == null)
            {
                return;
            }

            var currentBtn = (Button)sender;
            int previousValue;

            switch (currentBtn.Name)
            {
                case "strengthMinusBtn":
                    previousValue = Convert.ToInt32(strength.Content);
                    _currentCharacter.SetStrengthValue(--previousValue);
                    break;
                case "strengthPlusBtn":
                    previousValue = Convert.ToInt32(strength.Content);
                    _currentCharacter.SetStrengthValue(++previousValue);
                    break;
                case "dexterityMinusBtn":
                    previousValue = Convert.ToInt32(dexterity.Content);
                    _currentCharacter.SetDexterityValue(--previousValue);
                    break;
                case "dexterityPlusBtn":
                    previousValue = Convert.ToInt32(dexterity.Content);
                    _currentCharacter.SetDexterityValue(++previousValue);
                    break;
                case "constitutionMinusBtn":
                    previousValue = Convert.ToInt32(constitution.Content);
                    _currentCharacter.SetConstitutionValue(--previousValue);
                    break;
                case "constitutionPlusBtn":
                    previousValue = Convert.ToInt32(constitution.Content);
                    _currentCharacter.SetConstitutionValue(++previousValue);
                    break;
                case "intellisenseMinusBtn":
                    previousValue = Convert.ToInt32(intellisense.Content);
                    _currentCharacter.SetIntellisenseValue(--previousValue);
                    break;
                case "intellisensePlusBtn":
                    previousValue = Convert.ToInt32(intellisense.Content);
                    _currentCharacter.SetIntellisenseValue(++previousValue);
                    break;
                default:
                    break;
            }

            CharactericticChangedEvent?.Invoke();
        }

        private void cbCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = cbCharacters.SelectedItem.ToString();

            if (selectedItem == "")
            {
                _currentCharacter = null;
            }
            else
            {
                _currentCharacter = CreateCharacter(selectedItem);
            }

            CharactericticChangedEvent?.Invoke();
        }

        private Character CreateCharacter(string className)
        {
            switch (className)
            {
                case "Warrior":
                    return new Warrior() { Name = tbCharacterName.Text};
                case "Rogue":
                    return new Rogue() { Name = tbCharacterName.Text };
                case "Wizard":
                    return new Wizard() { Name = tbCharacterName.Text };
            }

            return null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentCharacter == null)
                {
                    return;
                }

                if (cbCharacters.SelectedItem == null)
                {
                    MessageBox.Show("Characters type not selected!", "Warning");
                    return;
                }

                if (!IsCharacterNameCorrect())
                {
                    MessageBox.Show("Invalid Character name!","Warning");
                    return;
                }

                if (_repository.IsCharacterExist(tbCharacterName.Text))
                {
                    MessageBox.Show("Character with same name already exists!", "Warning");
                    return;
                }

                _repository.InsertCharacter(_currentCharacter);
                CharacterUpdateEvent?.Invoke();
                MessageBox.Show("Character successfully saved!");
            }
            catch
            {
                MessageBox.Show("Failed to save!","Warning");
            }
        }

        private bool IsCharacterNameCorrect()
        {
            var name = _currentCharacter.Name;

            if (name == "" || name == null)
            {
                return false;
            }
            return true;
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CharacterUpdateEvent?.Invoke();
            }
            catch
            {
                MessageBox.Show("Failed loading!", "Warning");
                this.Close();
            }         
        }

        private void cbExestingCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbExestingCharacters.SelectedItem?.ToString();
            var character = _repository.GetCharacterByName(item);       

            if (character == null)
            {
                return;
            }

            cbCharacters.SelectedItem = character.GetType().Name;
            _currentCharacter = character;
            CharactericticChangedEvent?.Invoke();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter == null)
            {
                return;
            }

            try
            {   
                if (_repository.ReplaceByName(tbCharacterName.Text, _currentCharacter))
                {
                    MessageBox.Show("Character successfully updated!");
                }
                else
                {
                    MessageBox.Show("Character not founded!", "Warning");
                }

            }
            catch
            {
                MessageBox.Show("Failed updating!", "Warning");
            }
        }

        private void tbCharacterName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_currentCharacter != null)
            {
                _currentCharacter.Name = tbCharacterName.Text;
            }
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter == null)
            {
                return;
            }

            var window = new InventoryWindow(_currentCharacter, _repository);
            window.Show();
        }

        private void Btn100_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter == null)
            {
                return;
            }

            _currentCharacter.Experience += 100;
            CharactericticChangedEvent?.Invoke();
        }

        private void Btn200_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter == null)
            {
                return;
            }

            _currentCharacter.Experience += 200;
            CharactericticChangedEvent?.Invoke();
        }

        private void Btn500_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter == null)
            {
                return;
            }

            _currentCharacter.Experience += 3000;
            CharactericticChangedEvent?.Invoke();
        }

        private void cbAbilities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_currentCharacter == null)
            {
                return;
            }

            var ability = cbAbilities.SelectedItem as Ability;

            if (_currentCharacter.AddAbility(ability))
            {
                MessageBox.Show("Ability added!");
                _abilities.Remove(ability);
                CharactericticChangedEvent?.Invoke();
            }
            else
            {
                MessageBox.Show("Failed to add ability!", "Warning!");
            }
        }
    }
}