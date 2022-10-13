using System.Windows;

namespace CharacterEditor.MVVM.Views;

public partial class AddCharacterWindow : Window
{
    public AddCharacterWindow()
    {
        InitializeComponent();
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}