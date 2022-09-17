using System;
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

        private readonly ICharacterRepository _repository =
            ((App)Application.Current).CharacterRepository;

        public event Action? AfterChangeCharacter;

        public MainWindow()
        {
            InitializeComponent();

            CreateNewButton.Click += CreateNewButton_Click;
            SaveCharacterButton.Click += SaveCharacterButton_Click;
            CreatedCharactersComboBox.SelectionChanged +=
                CreatedCharactersComboBox_SelectionChanged;
            SelectClassComboBox.SelectionChanged +=
                SelectClassComboBox_SelectionChanged;
            AfterChangeCharacter += UpdateSkillPoints;
            AfterChangeCharacter += UpdateSlidersView;
            AfterChangeCharacter += UpdateStatDisplay;
            AfterChangeCharacter += UpdateName;
            foreach (CharacteristicSlider slider in SliderPanel.Children)
            {
                slider.CharacteristicName.Content =
                    CharacteristicSlider.GetCharName(slider);
                slider.PlusButton.Click += UpdateSliderView;
                slider.MinusButton.Click += UpdateSliderView;
            }
        }

        private void UpdateName()
        {
            NameTextBox.Text = _currentCharacter.Name ??
                               _currentCharacter.GetType().Name;
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

            var slider =
                CharacteristicSlider.TryGetSliderByButton((Button)sender);
            if (slider is null)
                return;

            var property = _currentCharacter
                .GetType()
                .GetProperty((string)slider.CharacteristicName.Content);
            property?.SetValue(_currentCharacter, slider.SliderValue);
            slider.SliderValue = (int)property?.GetValue(_currentCharacter)!;

            slider.InvalidateVisual();
            UpdateSkillPoints();
            UpdateStatDisplay();
        }

        private void SelectClassComboBox_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
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

            CreatedCharactersComboBox.ItemsSource =
                _repository.GetAllCharacterNamesByClass((string)value);
            CreatedCharactersComboBox.DisplayMemberPath = "Name";

            AfterChangeCharacter?.Invoke();
        }

        private void UpdateSlidersView()
        {
            StrengthSlider.SliderValue = _currentCharacter.Strength;
            DexteritySlider.SliderValue = _currentCharacter.Dexterity;
            ConstitutionSlider.SliderValue = _currentCharacter.Constitution;
            IntelligenceSlider.SliderValue = _currentCharacter.Intelligence;
            foreach (CharacteristicSlider slider in SliderPanel.Children)
                slider.InvalidateVisual();
        }

        private void UpdateStatDisplay()
        {
            if (_currentCharacter is null)
                return;

            CharacterStats.UpdateValues(_currentCharacter);
            CharacterStats.InvalidateVisual();
        }

        private void CreatedCharactersComboBox_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            var value = combobox!.SelectedValue as CharacterPair;

            if (value is null)
                return;

            _currentCharacter = _repository.GetCharacter(value.Id);
            AfterChangeCharacter?.Invoke();
        }

        private void SaveCharacterButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter is null)
                return;

            _currentCharacter.Name = NameTextBox.Text;
            if (_currentCharacter.Id is null)
                _repository.InsertCharacter(_currentCharacter);
            else
                _repository.UpdateCharacter(_currentCharacter.Id,
                    _currentCharacter);
            MessageBox.Show("Успешно!");
            CreateNewCharacter();
        }

        private void CreateNewCharacter()
        {
            if (string.IsNullOrEmpty(SelectClassComboBox.Text))
                return;
            
            SelectClassComboBox_SelectionChanged(SelectClassComboBox, null);
        }

        private void CreateNewButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewCharacter();
        }
    }
}