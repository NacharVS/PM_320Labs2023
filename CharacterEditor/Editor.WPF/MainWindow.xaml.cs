using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using DataProvider;
using DataProvider.Interfaces;
using Editor.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Editor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MongoProvider _provider;

        private Character? _currentCharacter;
        private const int StartSkillPoints = 5;

        public MainWindow()
        {
            InitializeComponent();

            _provider = new MongoProvider("mongodb://localhost");
            
            OnSkillChange += delegate(Character? sender, string propName, int val)
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
                    _currentCharacter = new Warrior(StartSkillPoints);
                    break;
                case "Rogue":
                    _currentCharacter = new Rogue(StartSkillPoints);
                    break;
                case "Wizard":
                    _currentCharacter = new Wizard(StartSkillPoints);
                    break;
            };
            FillData();
        }

        private void FillData()
        {
            lbSkillPointsVal.Content = _currentCharacter?.AvailableSkillPoints;

            lbStrengthVal.Content = _currentCharacter?.Strength;
            lbDexterityVal.Content = _currentCharacter?.Dexterity;
            lbConstitutionVal.Content = _currentCharacter?.Constitution;
            lbIntelligenceVal.Content = _currentCharacter?.Intelligence;

            lbHPVal.Content = _currentCharacter?.HealthPoints;
            lbMPVal.Content = _currentCharacter?.ManaPoints;

            lbPAtkVal.Content = _currentCharacter?.PhysicalDamage;
            lbPDefVal.Content = _currentCharacter?.PhysicalDefense;
            lbMAtkVal.Content = _currentCharacter?.MagicDamage;
            lbMDefVal.Content = _currentCharacter?.MagicDefense;
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
                _provider.Save(_currentCharacter);
                MessageBox.Show("Successfully saved");
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter != null)
            {
                var dbCharacter = _provider.Load(_currentCharacter.GetType().ToString());
                if (dbCharacter is not null)
                {
                    _currentCharacter = dbCharacter;
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
                _provider.Delete(_currentCharacter);
                MessageBox.Show("Successfully deleted");
            }
        }
    }
}
