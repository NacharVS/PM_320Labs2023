using System.Windows;
using System.Windows.Controls;
using CharacterEditor.Core;

namespace CharacterEditor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CharacterBase? _currentCharacter;
        public MainWindow()
        {
            InitializeComponent();

            SelectClassComboBox.SelectionChanged +=
                SelectClassComboBox_SelectionChanged;
            foreach (CharacteristicSlider slider in SliderPanel.Children)
            {
                slider.CharacteristicName.Content =
                    CharacteristicSlider.GetCharName(slider);
                slider.PlusButton.Click += UpdateSliderView;
                slider.MinusButton.Click += UpdateSliderView;
            }
        }

        private void UpdateSkillPoints()
        {
            SkillPointsLabel.Content =
                _currentCharacter?.SkillPoints.ToString() ?? "0";
        }

        private void UpdateSliderView(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter is null)
                return;
            
            var slider = CharacteristicSlider.TryGetSliderByButton((Button)sender);
            if (slider is null)
                return;

            switch (slider.CharacteristicName.Content)
            {
                case "Strength":
                    _currentCharacter.Strength = slider.SliderValue;
                    slider.SliderValue = _currentCharacter.Strength;
                    break;
                case "Dexterity":
                    _currentCharacter.Dexterity = slider.SliderValue;
                    slider.SliderValue = _currentCharacter.Dexterity;
                    break;
                case "Constitution":
                    _currentCharacter.Constitution = slider.SliderValue;
                    slider.SliderValue = _currentCharacter.Constitution;
                    break;
                case "Intelligence":
                    _currentCharacter.Intelligence = slider.SliderValue;
                    slider.SliderValue = _currentCharacter.Intelligence;
                    break;
            }
            
            UpdateSkillPoints();
            slider.InvalidateVisual();
            UpdateStatDisplay();
        }

        private void SelectClassComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            var value = (combobox!.SelectedValue as ComboBoxItem)!.Content;

            switch (value)
            {
                case "Warrior":
                    _currentCharacter = new Warrior();
                    break;
                case "Wizard":
                    _currentCharacter = new Wizard();
                    break;
                case "Rogue":
                    _currentCharacter = new Rogue();
                    break;
            }
            
            if (_currentCharacter is null)
                return;
            
            StrengthSlider.SliderValue = _currentCharacter.Strength;
            DexteritySlider.SliderValue = _currentCharacter.Dexterity;
            ConstitutionSlider.SliderValue = _currentCharacter.Constitution;
            IntelligenceSlider.SliderValue = _currentCharacter.Intelligence;
            
            foreach (CharacteristicSlider slider in SliderPanel.Children)
                slider.InvalidateVisual();
            UpdateSkillPoints();
            UpdateStatDisplay();
        }

        private void UpdateStatDisplay()
        {
            if (_currentCharacter is null)
                return;

            CharacterStats.UpdateValues(_currentCharacter);
            CharacterStats.InvalidateVisual();
        }
    }
}