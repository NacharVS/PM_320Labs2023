using CharacterEditorCore;
using CharacterEditorCore.Items;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        private Character _character;
        private ICharacterRepository _repos;
        private List<Item> _items;

        public InventoryWindow(Character character, ICharacterRepository repos)
        {
            InitializeComponent();
            _character = character;
            _repos = repos;
            _items = new List<Item>();
            _items.Capacity = _character.Inventory.Items.Capacity;
        }

        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = (Button)sender;
                var character = CreateItem(btn.Content.ToString());

                if (_items.Count < _items.Capacity)
                {
                    var win = new ItemRangSelectWindow(character);
                    win.ShowDialog();
                    _items.Add(character);
                    lbInventoryItems.Items.Add(character);
                                 
                }
                else
                {
                    MessageBox.Show("Inventory is full!", "Warning");
                }

                lbInventoryItems.InvalidateVisual();
            }
            catch
            {
                MessageBox.Show("Failed to add an item!", "Warning");
            }
            
        }

        private Item CreateItem(string? type)
        {
            switch (type)
            {
                case "Breastplate - 1":
                    return new Breastplate(type, 2, 3, 5, 0);
                case "Helmet - 1":
                    return new Helmet(type, 2, 3, 5, 0);
                case "Ak - 74":
                    return new Rifle(type, 10, 3, 0, 0, 200);
                case "Knife - 1":
                    return new Knife(type, 7, 5, 3, 0, 100);
                case "Bow - 1":
                    return new Bow(type, 5, 3, 3, 0, 80);
                default:
                    return null;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _character.Inventory.Clear();

                foreach (var item in _items)
                {      
                    _character.Inventory.AddItem(item);
                    lbInventoryItems.InvalidateVisual();
                }

                _repos.UpdateInventory(_character.Name, _character);
                MessageBox.Show("Inventory successfully saved!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Failed to save!", "Warning");
            }
        }

        private void UpdateInventory()
        {
            if (_character != null)
            {
                lbInventoryItems.DisplayMemberPath = "Name";

                foreach (var item in _items)
                {
                    lbInventoryItems.Items.Add(item);
                }
            }
        }

        private void FillItems()
        {
            _items.Clear();

            foreach (var item in _character.Inventory.Items)
            {
                _items.Add(item);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillItems();
            UpdateInventory();
            lbInventoryItems.InvalidateVisual();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lbInventoryItems.SelectedItem != null)
            {
                var item = lbInventoryItems.SelectedItem;
                _items.Remove(item as Item);
                lbInventoryItems.Items.Remove(lbInventoryItems.SelectedItem);         
            }
        }
    }
}