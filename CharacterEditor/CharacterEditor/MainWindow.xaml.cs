using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CharacterEditor;
using CharacterEditorCore;
using CharacterEditorMongoDataBase;

namespace UnitsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new MainPage());
        }
    }
}
