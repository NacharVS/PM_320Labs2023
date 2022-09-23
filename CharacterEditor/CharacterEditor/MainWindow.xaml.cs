﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CharacterEditorCore;
using CharacterEditorMongoDataBase;

namespace UnitsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> _characterNames;
        private BaseCharacteristics _selectedCharacter;
        private readonly CharacterEditorContext _charContext;

        private delegate void CharacteristicChangeDelegate();
        private event CharacteristicChangeDelegate? CharacteristicChangeEvent;

        public MainWindow()
        {
            InitializeComponent();
            _charContext = new CharacterEditorContext();

            _characterNames = new List<string>
            { "Warrior", "Rogue", "Wizard"};

            cbNewCharacters.ItemsSource = _characterNames;
            cbExistCharacters.ItemsSource = _charContext.GetAllChars();
        }

        private void NewCharComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbNewCharacters.SelectedItem is null)
            {
                return;
            }
            var selectedCharacter = cbNewCharacters.SelectedItem.ToString();
            tbCharacterName.Text = "";
            cbExistCharacters.SelectedItem = null;

            switch (selectedCharacter)
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
                    throw new Exception("Not correct Character!");
            }
            CharacteristicChangeEvent += _selectedCharacter.CalcStats;
            CharacteristicChangeEvent += FillCharacterInfo;

            CharacteristicChangeEvent?.Invoke();
        }

        private void FillCharacterInfo()
        {
            if (_selectedCharacter == null)
            {
                lbStrengthValue.Content = 0;
                lbDexterityValue.Content = 0;
                lbConstitutionValue.Content = 0;
                lbIntelligenceValue.Content = 0;

                tbAttackDamageValue.Text = "0";
                tbHealthValue.Text = "0";
                tbManaValue.Text = "0";
                tbPhysicalDefValue.Text = "0";
                tbMagicAttackValue.Text = "0";
                tbCharacterName.Text = "";
                return;
            }
            try
            {
                lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value);
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);

                tbAttackDamageValue.Text = Convert.ToString(_selectedCharacter.AttackDamage);
                tbHealthValue.Text = Convert.ToString(_selectedCharacter.HealthPoint);
                tbManaValue.Text = Convert.ToString(_selectedCharacter.ManaPoint);
                tbPhysicalDefValue.Text = Convert.ToString(_selectedCharacter.PhysicalDef);
                tbMagicAttackValue.Text = Convert.ToString(_selectedCharacter.MagicAttack);
            }
            catch { }
        }

        private void BtnPlusStrength_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Strength.Value += 1;
                lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
            }
            catch { }
        }
        
        private void BtnMinusStrength_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Strength.Value -= 1;
                lbStrengthValue.Content = Convert.ToString(_selectedCharacter.Strength.Value);
            }
            catch { }
        }

        private void BtnPlusDexterity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Dexterity.Value += 1;
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value);
            }
            catch { }
        }

        private void BtnMinusDexterity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Dexterity.Value -= 1;
                lbDexterityValue.Content = Convert.ToString(_selectedCharacter.Dexterity.Value);;
            }
            catch{ }
        }

        private void BtnMinusConstitution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Constitution.Value -= 1;
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
            }
            catch{}
        }

        private void BtnPlusConstitution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Constitution.Value += 1;
                lbConstitutionValue.Content = Convert.ToString(_selectedCharacter.Constitution.Value);
            }
            catch { }
        }

        private void BtnPlusIntelligence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Intelligence.Value += 1;
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);
            }
            catch { }
        }

        private void BtnMinusIntelligence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _selectedCharacter.Intelligence.Value -= 1;
                lbIntelligenceValue.Content = Convert.ToString(_selectedCharacter.Intelligence.Value);
            }
            catch{}
        }

        private void CharacteristicChange(object sender, RoutedEventArgs e)
        {
            if(_selectedCharacter is null)
            {
                return;
            }
            CharacteristicChangeEvent?.Invoke();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbCharacterName.Text != "")
                {
                    _selectedCharacter.Name = tbCharacterName.Text;
                    if (_charContext.AddCharacterToDb(_selectedCharacter))
                    {
                        cbExistCharacters.ItemsSource = _charContext.GetAllChars();
                        cbNewCharacters.SelectedIndex = -1;
                        _selectedCharacter = null;
                        FillCharacterInfo();
                        MessageBox.Show("Save succesfull");
                    }
                }
            }
            catch { }
            
        }

        private void ExtCharComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var charInDb = (CharacterIdName)cbExistCharacters.SelectedItem;
            if( charInDb is not null)
            {
                tbCharacterName.Text = charInDb.Name;

                var findCharacter = _charContext.GetCharacter(charInDb.Id);
                if (findCharacter is not null)
                {
                    _selectedCharacter = findCharacter;
                    cbNewCharacters.SelectedItem = null;

                    CharacteristicChangeEvent += _selectedCharacter.CalcStats;
                    CharacteristicChangeEvent += FillCharacterInfo;

                    CharacteristicChangeEvent?.Invoke();
                }
            }
        }
    }
}