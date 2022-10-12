using EditUnit_Practic_WPF.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Units_Practic;
using Units_Practic.Characters;

namespace EditUnit_Practic_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Unit unit;

        public MainWindow()
        {
            InitializeComponent();

            EditPage.NavigationService.Navigate(new EditPage());
            MatchPage.NavigationService.Navigate(new MatchPage());
        }

        public void WarriorItem_Click(object sender, RoutedEventArgs e)
        {
            EditPage.NavigationService.Navigate(new WarriorPage());
            tabControl.SelectedIndex = 0;
        }

        public void RogueItem_Click(object sender, RoutedEventArgs e)
        {
            EditPage.NavigationService.Navigate(new RoguePage());
            tabControl.SelectedIndex = 0;
        }

        public void WizardItem_Click(object sender, RoutedEventArgs e)
        {
            EditPage.NavigationService.Navigate(new WizardPage());
            tabControl.SelectedIndex = 0;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            EditPage.NavigationService.Navigate(new EditPage());
            tabControl.SelectedIndex = 0;
        }
    }
}
