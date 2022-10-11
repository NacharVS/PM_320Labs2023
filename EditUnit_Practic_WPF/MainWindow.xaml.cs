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

        private void WarriorItem_Click(object sender, RoutedEventArgs e)
        {
            EditPage.NavigationService.Navigate(new WarriorPage());
        }

        private void RogueItem_Click(object sender, RoutedEventArgs e)
        {
            EditPage.NavigationService.Navigate(new RoguePage());
        }

        private void WizardItem_Click(object sender, RoutedEventArgs e)
        {
            EditPage.NavigationService.Navigate(new WizardPage());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
