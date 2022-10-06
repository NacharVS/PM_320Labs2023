﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CharacterEditor.Core;
using CharacterEditor.Core.Classes;
using CharacterEditor.Core.Db;
using CharacterEditor.Core.Misc;
using CharacterEditor.WPF.Components;
using CharacterEditor.WPF.Windows;

namespace CharacterEditor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private CharacterBase? _currentCharacter;

        private readonly ICharacterRepository _repository;
        private readonly IAbilityRepository _abilityRepository;

        public event Action? AfterChangeCharacter;

        public MainWindow()
        {
            var app = (App)Application.Current;
            _repository = app.CharacterRepository;
            _abilityRepository = app.AbilityRepository;

            _abilityRepository.InitializeCollection();
            InitializeComponent();

            AbilityListBox.DisplayMemberPath = "Name";

            LevelInfo.AddXpButton.Click += AddXpButtonClick;

            Inventory.AddItemButton.Click += AddItemButton_Click;
            Inventory.RemoveItemButton.Click += RemoveItemButton_Click;

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
            AfterChangeCharacter += UpdateInventory;
            AfterChangeCharacter += UpdateLevel;
            AfterChangeCharacter += UpdateAbilities;

            foreach (CharacteristicSlider slider in SliderPanel.Children)
            {
                slider.CharacteristicName.Content =
                    CharacteristicSlider.GetCharName(slider);
                slider.PlusButton.Click += UpdateSliderView;
                slider.MinusButton.Click += UpdateSliderView;
            }
        }

        private void AddXpButtonClick(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter is null ||
                !int.TryParse(LevelInfo.XpTextBox.Text, out int val))
                return;

            _currentCharacter.Level.CurrentExperience += val;
            UpdateLevel();
            UpdateSkillPoints();
        }

        private void CreateNewButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewCharacter();
        }

        private void SelectClassComboBox_SelectionChanged(object sender,
            SelectionChangedEventArgs? e)
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

            _currentCharacter.OnAbilityGain += GiveAbility;
            CreatedCharactersComboBox.ItemsSource =
                _repository.GetAllCharacterNamesByClass((string)value);
            CreatedCharactersComboBox.DisplayMemberPath = "Name";

            AfterChangeCharacter?.Invoke();
        }

        private void CreatedCharactersComboBox_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            var value = combobox!.SelectedValue as CharacterTuple;

            if (value is null)
                return;

            _currentCharacter = _repository.GetCharacter(value.Id);
            _currentCharacter.OnAbilityGain += GiveAbility;
            AbilityListBox.ItemsSource = _currentCharacter.Abilities;
            Inventory.ItemListBox.ItemsSource = _currentCharacter.Inventory;
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

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter is null)
                return;

            var prompt = new TextPrompt();
            if (prompt.ShowDialog() == true)
            {
                var item = new Item { Name = prompt.ResponseTextBox.Text };
                _currentCharacter.AddToInventory(item);
                UpdateInventory();
            }
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCharacter is null ||
                Inventory.ItemListBox.SelectedItem is not Item item)
                return;

            _currentCharacter.DeleteFromInventory(item);
            UpdateInventory();
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

        private void UpdateInventory()
        {
            Inventory.ItemListBox.ItemsSource = _currentCharacter!.Inventory;
            Inventory.InvalidateVisual();
        }

        private void UpdateAbilities()
        {
            AbilityListBox.ItemsSource = _currentCharacter!.Abilities;
            AbilityListBox.InvalidateVisual();
        }

        private void GiveAbility()
        {
            var abilities = _abilityRepository.GetAllAbilities();
            var selectAbility =
                new SelectAbilityWindow(_currentCharacter!,
                    abilities.ToArray());
            if (selectAbility.ShowDialog() == true)
            {
                _currentCharacter!.AddAbility(selectAbility.SelectedAbility);
                UpdateStatDisplay();
                UpdateAbilities();
            }
        }

        private void UpdateName()
        {
            NameTextBox.Text = _currentCharacter!.Name ??
                               _currentCharacter.GetType().Name;
        }

        private void UpdateSkillPoints()
        {
            SkillPointsLabel.Content =
                _currentCharacter?.SkillPoints.ToString() ?? "0";
        }

        private void UpdateSlidersView()
        {
            StrengthSlider.SliderValue = _currentCharacter!.Strength;
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

        private void UpdateLevel()
        {
            LevelInfo.CurrentLevelTextBox.Text =
                _currentCharacter!.Level.CurrentLevel.ToString();
            LevelInfo.XpToGainLevelTextBox.Text =
                _currentCharacter.Level.ExperienceToGainLevel.ToString();
            LevelInfo.ExperienceLeftTextBox.Text =
                _currentCharacter.Level.ExperienceLeft.ToString();
        }


        private void CreateNewCharacter()
        {
            if (string.IsNullOrEmpty(SelectClassComboBox.Text))
                return;

            SelectClassComboBox_SelectionChanged(SelectClassComboBox, null);
        }
    }
}