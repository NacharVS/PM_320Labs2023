using CharacterEditorCore;
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
        private List<IItem> _items;

        public InventoryWindow(Character character, ICharacterRepository repos)
        {
            InitializeComponent();
            _character = character;
            _repos = repos;
            _items = new List<IItem>();
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

        private IItem CreateItem(string? type)
        {
            switch (type)
            {
                case "Armor":
                    return new Armor();
                case "Helmet":
                    return new Helmet();
                case "Rifle":
                    return new Rifle();
                case "Knife":
                    return new Knife();
                case "Bow":
                    return new Bow();
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
                _items.Remove(item as IItem);
                lbInventoryItems.Items.Remove(lbInventoryItems.SelectedItem);         
            }
        }
    }
}