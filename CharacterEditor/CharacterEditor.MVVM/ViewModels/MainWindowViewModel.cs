using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CharacterEditor.Core;
using CharacterEditor.Core.Classes;
using CharacterEditor.Core.Db;
using CharacterEditor.MVVM.Utils;
using CharacterEditor.MVVM.Utils.Commands;
using CharacterEditor.MVVM.Utils.Parameters;
using CharacterEditor.MVVM.ViewModels.Base;
using CharacterEditor.MVVM.Views;

// ReSharper disable ValueParameterNotUsed

namespace CharacterEditor.MVVM.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly ICharacterRepository _repository;
    private readonly IAbilityRepository _abilityRepository;

    private CharacterBase? _currentCharacter;

    private ContentControl? _selectedClass;
    private CharacterTuple? _selectedCharacterInfo;

    #region Properties

    public ContentControl? SelectedClass
    {
        get => _selectedClass;
        set
        {
            if (_selectedClass == value)
                return;
            _selectedClass = value;
            CreateNewCharacter();
            ExistingCharacters =
                _repository.GetAllCharacterNamesByClass(
                    _selectedClass?.Content as string ?? "");
            OnPropertyChanged(nameof(ExistingCharacters));
        }
    }

    public Item? SelectedItem { get; set; }

    public CharacterTuple? SelectedCharacterInfo
    {
        get => _selectedCharacterInfo;
        set
        {
            if (_selectedCharacterInfo == value)
                return;
            _selectedCharacterInfo = value;
            LoadCharacter();
        }
    }

    public IEnumerable<CharacterTuple>? ExistingCharacters { get; private set; }

    #endregion

    # region Character property wrappers

    [CharacterProperty]
    [CharacterLevel]
    public int Level => _currentCharacter?.Level.CurrentLevel ?? 0;

    [CharacterProperty]
    [CharacterLevel]
    public int XpLeft => _currentCharacter?.Level.ExperienceLeft ?? 0;

    [CharacterProperty]
    [CharacterLevel]
    public int XpToGain => _currentCharacter?.Level.ExperienceToGainLevel ?? 0;

    [CharacterProperty]
    public string Name
    {
        get => _currentCharacter?.Name ?? "Name";
        set
        {
            _currentCharacter!.Name = value;
            OnPropertyChanged();
        }
    }

    [CharacterProperty]
    [CharacterCharacteristic]
    public int Strength
    {
        get => _currentCharacter?.Strength ?? 0;
        set
        {
            _currentCharacter!.Strength = value;
            OnPropertyChanged();
        }
    }

    [CharacterProperty]
    [CharacterCharacteristic]
    public int Dexterity
    {
        get => _currentCharacter?.Dexterity ?? 0;
        set
        {
            _currentCharacter!.Dexterity = value;
            OnPropertyChanged();
        }
    }

    [CharacterProperty]
    [CharacterCharacteristic]
    public int Constitution
    {
        get => _currentCharacter?.Constitution ?? 0;
        set
        {
            _currentCharacter!.Constitution = value;
            OnPropertyChanged();
        }
    }

    [CharacterProperty]
    [CharacterCharacteristic]
    public int Intelligence
    {
        get => _currentCharacter?.Intelligence ?? 0;
        set
        {
            _currentCharacter!.Intelligence = value;
            OnPropertyChanged();
        }
    }

    [CharacterProperty]
    [CharacterStat]
    public int SkillPoints => _currentCharacter?.SkillPoints ?? 0;

    [CharacterProperty]
    [CharacterStat]
    public double Health => _currentCharacter?.Health ?? 0;

    [CharacterProperty]
    [CharacterStat]
    public double Attack => _currentCharacter?.AttackDamage ?? 0;

    [CharacterProperty]
    [CharacterStat]
    public double MagicalAttack => _currentCharacter?.MagicalAttackDamage ?? 0;

    [CharacterProperty]
    [CharacterStat]
    public double PhysicalResist => _currentCharacter?.PhysicalResistance ?? 0;

    [CharacterProperty]
    [CharacterStat]
    public double Mana => _currentCharacter?.Mana ?? 0;

    [CharacterProperty]
    public Item[] Inventory =>
        _currentCharacter?.Inventory ?? Array.Empty<Item>();

    [CharacterProperty]
    public Ability[] Abilities =>
        _currentCharacter?.Abilities ?? Array.Empty<Ability>();

    #endregion

    #region Commands

    #region AddXp

    public ICommand AddXp { get; }
    private bool CanAddXpExecute(object p) => _currentCharacter is not null;

    private void OnAddXpExecuted(object p)
    {
        if (p is not TextBox param || !int.TryParse(param.Text, out var val))
            return;

        _currentCharacter!.Level.CurrentExperience += val;
        UpdateFields(UpdateFieldValues.Level);
    }

    #endregion

    #region RemoveFromInventory

    public ICommand RemoveItemFromInventory { get; }

    private bool CanRemoveItemFromInventoryExecute(object p) =>
        _currentCharacter is not null && SelectedItem is not null;

    private void OnRemoveItemFromInventoryExecuted(object p)
    {
        _currentCharacter!.DeleteFromInventory(SelectedItem!);
        OnPropertyChanged(nameof(Inventory));
    }

    #endregion

    #region AddItemToInventory

    public ICommand AddItemToInventory { get; }

    private bool CanAddItemToInventoryExecute(object p) =>
        _currentCharacter is not null;

    private void OnAddItemToInventoryExecuted(object p)
    {
        var prompt = new TextPrompt();
        if (prompt.ShowDialog() == true)
        {
            var item = new Item { Name = prompt.ResponseTextBox.Text };
            _currentCharacter!.AddToInventory(item);
            OnPropertyChanged(nameof(Inventory));
        }
    }

    #endregion

    #region SaveCharacter

    public ICommand SaveCharacter { get; }

    private bool CanSaveCharacterCommandExecute(object p) =>
        _currentCharacter is not null;

    private void OnSaveCharacterCommandExecuted(object p)
    {
        SaveCurrentCharacter();
    }

    #endregion

    #region CreateNewCharacter

    public ICommand CreateNewCharacterCommand { get; }

    private bool CanCreateNewCharacterCommandExecute(object p) =>
        _selectedClass is not null;

    private void OnCreateNewCharacterCommandExecuted(object p)
    {
        CreateNewCharacter();
    }

    #endregion

    #region UpdateCharacteristicValue

    public ICommand UpdateCharacteristicValue { get; }
    private bool CanUpdateCharacteristicValueExecute(object p) => true;

    private void OnUpdateCharacteristicValueExecuted(object p)
    {
        var param = p as CharacteristicSliderParameters;
        if (param is null)
            return;

        var prop = GetType().GetProperty(param.Characteristic);
        prop?.SetValue(this,
            (int)(prop.GetValue(this) ?? 0) + param.ChangeValue);

        UpdateFields(UpdateFieldValues.Stat);
    }

    #endregion

    #endregion

    #region Character manipulation

    private void CreateNewCharacter()
    {
        switch (_selectedClass!.Content)
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

        UpdateFields(UpdateFieldValues.All);
        _selectedCharacterInfo = null;
        OnPropertyChanged(nameof(SelectedCharacterInfo));
    }

    private void LoadCharacter()
    {
        _currentCharacter =
            _repository.GetCharacter(_selectedCharacterInfo!.Id);
        _currentCharacter.OnAbilityGain += GiveAbility;
        UpdateFields(UpdateFieldValues.All);
    }
    
    private void SaveCurrentCharacter()
    {
        if (_currentCharacter!.Id is null)
            _repository.InsertCharacter(_currentCharacter);
        else
            _repository.UpdateCharacter(_currentCharacter.Id,
                _currentCharacter);
        MessageBox.Show("Успешно!");
        CreateNewCharacter();
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
            UpdateFields(UpdateFieldValues.Stat);
            OnPropertyChanged(nameof(Abilities));
        }
    }

    #endregion

    private void UpdateFields(UpdateFieldValues value)
    {
        var attributes = UpdateFieldProperties.GetAttributes(value);
        var props = GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => attributes.All(z => Attribute.IsDefined(x, z)));
        foreach (var prop in props)
        {
            OnPropertyChanged(prop.Name);
        }
    }

    public MainWindowViewModel()
    {
        var app = (App)Application.Current;
        _repository = app.CharacterRepository;
        _abilityRepository = app.AbilityRepository;

        UpdateCharacteristicValue = new LambdaCommand(OnUpdateCharacteristicValueExecuted,
            CanUpdateCharacteristicValueExecute);
        CreateNewCharacterCommand = new LambdaCommand(
            OnCreateNewCharacterCommandExecuted,
            CanCreateNewCharacterCommandExecute);
        SaveCharacter = new LambdaCommand(OnSaveCharacterCommandExecuted,
            CanSaveCharacterCommandExecute);
        AddItemToInventory = new LambdaCommand(OnAddItemToInventoryExecuted,
            CanAddItemToInventoryExecute);
        RemoveItemFromInventory = new LambdaCommand(
            OnRemoveItemFromInventoryExecuted,
            CanRemoveItemFromInventoryExecute);
        AddXp = new LambdaCommand(OnAddXpExecuted, CanAddXpExecute);

        _abilityRepository.InitializeCollection();
    }
}