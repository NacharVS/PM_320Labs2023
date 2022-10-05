using CharacterEditorCore;
using System.Windows;
using CharacterEditorCore.Items;
using System.Windows.Controls;
using CharacterEditorMongoDataBase;
using UnitsEditor;
using System.Linq;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        private BaseCharacteristics _selectedCharacter;
        private MainWindow _mainWindow;
        private delegate void ItemSelectedDelegate();

        public Inventory(BaseCharacteristics selectedCharacter, MainWindow mainWindow)
        {
            InitializeComponent();

            _selectedCharacter = selectedCharacter;
            _mainWindow = mainWindow;
            OnItemSelectedEvent += _mainWindow.FillCharacterInfo;
            FillInventory();
            FillItems();
        }

        private void FillItems()
        {
            lvItems.Items.Clear();
            var freeItemsList = ItemsList.ItemList
                .Where(x => _selectedCharacter.Inventory.FirstOrDefault
                (z => z.Name == x.Name) is null);

            foreach (var item in freeItemsList)
            {
                lvItems.Items.Add(item);
            }
            lvItems.InvalidateVisual();
        }

        private void FillInventory()
        {
            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
            lbInventory.DisplayMemberPath = "Name";
            lbInventory.Items.Clear();
            foreach (var item in _selectedCharacter.Inventory)
            {
                lbInventory.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void lbInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var deletedItem = (Item)lbInventory.SelectedItem;
            if (deletedItem is null)
            {
                return;
            }
            _selectedCharacter.RemoveItem(deletedItem);
            OnItemSelectedEvent?.Invoke();
            lbInventory.Items.Remove(deletedItem);
            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
            FillItems();
        }

        private void lvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Item)lvItems.SelectedItem;
            if(item is null)
            { 
                return;
            }
            _selectedCharacter.AddItem(item);
            if (_selectedCharacter.InventCapacity > lbInventory.Items.Count && _selectedCharacter.Lvl.CurrentLevel >= item.MinimumLevel)
            {
                lbInventory.Items.Add(item);
            }
            OnItemSelectedEvent?.Invoke();
            FillItems();

            lblInventoryCapacity.Content = $"{_selectedCharacter.Inventory.Count} / {_selectedCharacter.InventCapacity}";
            if(_mainWindow.tbCharacterName.Text == "")
            {
                return;
            }
            if(_mainWindow.cbNewCharacters.SelectedItem is null
                && _mainWindow.cbExistCharacters.SelectedItem is null)
            {
                return;
            }
            if(_mainWindow.cbExistCharacters.SelectedItem is null)
            {
                _mainWindow.CharContext.AddCharacterToDb(_selectedCharacter);
            }
            if(_mainWindow.cbNewCharacters.SelectedItem is null)
            {
                _mainWindow.CharContext.UpdateInventory(
            ((CharacterIdName)_mainWindow.cbExistCharacters.SelectedItem).Id,
            _selectedCharacter);
            }
        }
        private event ItemSelectedDelegate OnItemSelectedEvent;
    }
}
