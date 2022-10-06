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
        public List<Unit> units;

        public MainWindow()
        {
            units = new List<Unit>() {new Warrior(), new Wizard(), new Rogue() };

            InitializeComponent();

            WarriorPage.NavigationService.Navigate(new WarriorPage());
            RoguePage.NavigationService.Navigate(new RoguePage());
            WizardPage.NavigationService.Navigate(new WizardPage());
        }

    }
}
