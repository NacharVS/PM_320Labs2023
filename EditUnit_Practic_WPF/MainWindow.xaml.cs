using EditUnit_Practic_WPF.Pages;
using MongoDB.Bson.Serialization;
using System.Windows;
using Units_Practic;
using Units_Practic.Characters;

namespace EditUnit_Practic_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BsonClassMap.RegisterClassMap<Unit>();
            BsonClassMap.RegisterClassMap<Warrior>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Wizard>();
            BsonClassMap.RegisterClassMap<Equipment>();

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

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            EditPage.NavigationService.Navigate(new EditPage());
            tabControl.SelectedIndex = 0;
        }

        /*private void TbItMatch_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MatchPage.NavigationService.Navigate(new MatchPage());
        }*/
    }
}
