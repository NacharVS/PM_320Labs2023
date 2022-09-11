using CharacterEditorCore;
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
        public delegate void CharactericticChangedDelegate();
        public event CharactericticChangedDelegate CharactericticChangedEvent;

        public MainWindow()
        {
            InitializeComponent();
            cbCharacters.ItemsSource = _characterNames;
            CharactericticChangedEvent += UpdateCharacterInfo;
        }

        private void UpdateCharacterInfo()
        {
            if (_currentCharacter == null)
            {
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

            Attack.Content = _currentCharacter.AttackDamage;
            Health.Content = _currentCharacter.Health;
            PhysicalDefence.Content = _currentCharacter.PhysicalDefense;
            Mana.Content = _currentCharacter.Mana;
            MagicalAttack.Content = _currentCharacter.MagicalAttackDamage;

            strength.Content = _currentCharacter.GetStrengthValue();
            dexterity.Content = _currentCharacter.GetDexterityValue();
            constitution.Content = _currentCharacter.GetConstitutionValue();
            intellisense.Content = _currentCharacter.GetIntellisenseValue();
        }

        private void CharactericticChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter == null)
            {
                return;
            }

            var currentBtn = (Button)sender;
            int previousValue;
            int currentValue;

            switch (currentBtn.Name)
            {
                case "strengthMinusBtn":
                    previousValue = Convert.ToInt32(strength.Content);
                    currentValue = --previousValue;
                    _currentCharacter.SetStrengthValue(currentValue);

                    strength.Content = _currentCharacter.GetStrengthValue();
                    break;
                case "strengthPlusBtn":
                    previousValue = Convert.ToInt32(strength.Content);
                    currentValue = ++previousValue;
                    _currentCharacter.SetStrengthValue(currentValue);

                    strength.Content = _currentCharacter.GetStrengthValue();
                    break;
                case "dexterityMinusBtn":
                    previousValue = Convert.ToInt32(dexterity.Content);
                    currentValue = --previousValue;
                    _currentCharacter.SetDexterityValue(currentValue);

                    dexterity.Content = _currentCharacter.GetDexterityValue();
                    break;
                case "dexterityPlusBtn":
                    previousValue = Convert.ToInt32(dexterity.Content);
                    currentValue = ++previousValue;
                    _currentCharacter.SetDexterityValue(currentValue);

                    dexterity.Content = _currentCharacter.GetDexterityValue();
                    break;
                case "constitutionMinusBtn":
                    previousValue = Convert.ToInt32(constitution.Content);
                    currentValue = --previousValue;
                    _currentCharacter.SetConstitutionValue(currentValue);

                    constitution.Content = _currentCharacter.GetConstitutionValue();
                    break;
                case "constitutionPlusBtn":
                    previousValue = Convert.ToInt32(constitution.Content);
                    currentValue = ++previousValue;
                    _currentCharacter.SetConstitutionValue(currentValue);

                    constitution.Content = _currentCharacter.GetConstitutionValue();
                    break;
                case "intellisenseMinusBtn":
                    previousValue = Convert.ToInt32(intellisense.Content);
                    currentValue = --previousValue;
                    _currentCharacter.SetIntellisenseValue(currentValue);

                    intellisense.Content = _currentCharacter.GetIntellisenseValue();
                    break;
                case "intellisensePlusBtn":
                    previousValue = Convert.ToInt32(intellisense.Content);
                    currentValue = ++previousValue;
                    _currentCharacter.SetIntellisenseValue(currentValue);

                    intellisense.Content = _currentCharacter.GetIntellisenseValue();
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

        private Character CreateCharacter(string name)
        {
            switch (name)
            {
                case "Warrior":
                    return new Warrior();
                case "Rogue":
                    return new Rogue();
                case "Wizard":
                    return new Wizard();
            }

            return null;
        }
    }
}