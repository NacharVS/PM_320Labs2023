using System.Collections.Generic;
using System.Windows;
using CharacterEditor.Core;
using CharacterEditor.Core.Db;

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