using System.Windows;
using System.Windows.Input;

namespace CharacterEditor.MVVM.Views
{
    /// <summary>
    /// Interaction logic for TextPrompt.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
