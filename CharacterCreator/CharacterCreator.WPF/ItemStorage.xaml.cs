using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CharacterCreator.Data.Repositories;

namespace CharacterCreator.Core;

public partial class ItemStorage : Window
{
    private readonly EquipmentRepository _equipmentRepository;
    private IEnumerable<Equipment> _storage;
    private readonly Character _selectedCharacter;
    
    public ItemStorage(Character character)
    {
        InitializeComponent();
        _equipmentRepository = new EquipmentRepository(((App)Application.Current).equipmentDbConnection);
        _storage = _equipmentRepository.GetAllEntities();
        _selectedCharacter = character;

        foreach (var eq in _storage)
        {
            ItemStorageList.Items.Add(eq);
        }

        ItemStorageList.DisplayMemberPath = "Name";
    }

    private void ItemStorageList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBox lb = (ListBox)sender;
        Equipment eq = (Equipment) lb.SelectedItem;
        
        if (eq is null)
            return;
        
        ChangeInfoLabel(eq.GetTotalInfo());
    }

    private void ChangeInfoLabel(string info)
    {
        ItemInfoLabel.Content = $"{info}";
    }

    private void AddItemBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Equipment? eq = ItemStorageList.SelectedIndex != -1 ? (Equipment) ItemStorageList.SelectedItem : null;
        if (eq is null)
            return;
        
        _selectedCharacter.AddItemToInventory(eq);
    }
}