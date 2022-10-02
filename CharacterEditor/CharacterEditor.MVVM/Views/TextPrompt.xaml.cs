using System.Windows;
using System.Windows.Input;

namespace CharacterEditor.MVVM.Views
{
    /// <summary>
    /// Interaction logic for TextPrompt.xaml
    /// </summary>
    public partial class TextPrompt : Window
    {
        public TextPrompt()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ResponseTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                DialogResult = true;
            }
        }
    }
}
