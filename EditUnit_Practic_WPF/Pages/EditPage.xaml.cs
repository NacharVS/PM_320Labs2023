using MongoDB.Bson;
using MongoDB.Driver;
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
using System.Xml.Linq;
using Units_Practic.Characters;
using Units_Practic.MongoDb;

namespace EditUnit_Practic_WPF.Pages
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        //public Unit unit;

        public EditPage()
        {
            InitializeComponent();
        }

        private void btn_DeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            if (lbUnits.SelectedItem is null) MessageBox.Show("Select the unit.");

            else
            {
                MongoDb.DeleteFromDataBase((Unit)lbUnits.SelectedItem);
                GetUnits();
            }
        }

        private void btn_EditUnit_Click(object sender, RoutedEventArgs e)
        {
            if (lbUnits.SelectedItem is null) MessageBox.Show("Select the unit.");

            else
            {
                var unit = (Unit)lbUnits.SelectedItem;

                switch (unit.characteristics.type)
                {
                    case Units.Warrior:
                        NavigationService.Navigate(new WarriorPage(unit));
                        break;
                    case Units.Rogue:
                        NavigationService.Navigate(new RoguePage(unit));
                        break;
                    case Units.Wizard:
                        NavigationService.Navigate(new WizardPage(unit));
                        break;
                }
            }
        }

        private void btn_NewUnit_Click(object sender, RoutedEventArgs e)
        {
            if (cbTypeUnits.SelectedItem is null) MessageBox.Show("Select the unit type.");
            
            else
            {
                switch (cbTypeUnits.SelectedIndex)
                {
                    case 0:
                        NavigationService.Navigate(new WarriorPage());
                        break;
                    case 1:
                        NavigationService.Navigate(new RoguePage());
                        break;
                    case 2:
                        NavigationService.Navigate(new WizardPage());
                        break;
                }
            }
        }

        private void GetUnits()
        {
            lbUnits.Items.Clear();

            try
            {
                var cursor = MongoDb.collection.Find(new BsonDocument());
                {
                    foreach (var doc in cursor.ToList())
                    {
                        var unit = new Unit();
                        unit = doc;

                        lbUnits.Items.Add(unit);
                    }
                }
            }
            catch { }
        }

        private void lbUnits_Initialized(object sender, EventArgs e)
        {
            MongoDb.Connect_cbUnits();
            GetUnits();
        }
    }
}
