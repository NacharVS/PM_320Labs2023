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