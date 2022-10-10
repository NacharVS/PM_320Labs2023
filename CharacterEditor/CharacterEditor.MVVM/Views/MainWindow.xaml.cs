using System.Windows;

namespace CharacterEditor.MVVM.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MainFrame.Navigate(new MainPage());
    }
}