using System.Windows;
using System.Windows.Controls;

namespace CharacterEditor.MVVM.Views;

public partial class MatchGenerator : Page
{
    public MatchGenerator()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.GoBack();
    }
}