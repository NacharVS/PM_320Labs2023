using CharacterEditorCore;
using System.Windows;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for ItemRangSelectWindow.xaml
    /// </summary>
    public partial class ItemRangSelectWindow : Window
    {
        private Item _currentItem;

        public ItemRangSelectWindow(Item item)
        {
            InitializeComponent();

            for (int i = 1; i <= item.GetMaxRang(); ++i)
            {
                cbSelectRang.Items.Add(i);
            }

            _currentItem = item;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (cbSelectRang.SelectedItem == null)
            {
                MessageBox.Show("Select rang!");
                return;
            }

            if (_currentItem != null)
            {
                _currentItem.Rang = int.Parse(cbSelectRang.Text);
            }

            this.Close();
        }
    }
}