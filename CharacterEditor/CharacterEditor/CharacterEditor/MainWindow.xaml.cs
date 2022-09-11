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
                                              {"Warrior", "Rogue", "Wizzard"};
        private Character _currentCharacter;
        public delegate void CharactericticChangedDelegate();
        public event CharactericticChangedDelegate CharactericticChangedEvent;

        public MainWindow()
        {
            InitializeComponent();
            cbCharacters.ItemsSource = _characterNames;
            _currentCharacter = new Warrior();
            CharactericticChangedEvent += UpdateCharacterInfo;
        }

        private void UpdateCharacterInfo()
        {
            if (_currentCharacter == null)
            {
                return;
            }

            Attack.Content = _currentCharacter.AttackDamage;
            Health.Content = _currentCharacter.Health;
            PhysicalDefence.Content = _currentCharacter.PhysicalDefence;
            Mana.Content = _currentCharacter.Mana;
            MagicalAttack.Content = _currentCharacter.MagicalAttackDamage;
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
    }
}