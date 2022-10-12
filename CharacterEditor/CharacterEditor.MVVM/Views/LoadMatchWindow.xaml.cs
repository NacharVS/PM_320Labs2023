using System.Windows;

namespace CharacterEditor.MVVM.Views;

public partial class LoadMatchWindow : Window
{
    public LoadMatchWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}