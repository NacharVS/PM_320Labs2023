using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
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

        public EditPage()
        {
            InitializeComponent();
            cbTypeUnits.SelectedIndex = 0;
        }

        private void btn_DeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            if (lbUnits.SelectedItem is null) MessageBox.Show("Select the unit.");

            else
            {
                MongoDb.DeleteFromDataBase((Unit)lbUnits.SelectedItem);
            }

            GetUnits();
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
            if (cbTypeUnits.SelectedIndex == 0) MessageBox.Show("Select the unit type.");
            
            else
            {
                switch (cbTypeUnits.SelectedIndex)
                {
                    case 1:
                        NavigationService.Navigate(new WarriorPage());
                        break;
                    case 2:
                        NavigationService.Navigate(new RoguePage());
                        break;
                    case 3:
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
                var cursor = MongoDb.collection.Find(new BsonDocument()).ToList();
                {
                    foreach (var doc in cursor)
                    {
                        lbUnits.Items.Add(doc);
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

        private void cbTypeUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbTypeUnits.SelectedIndex)
            {
                case 0:
                    GetUnits();
                    break;
                case 1:
                    lbUnits.Items.Clear();

                    try
                    {
                        var cursor = MongoDb.collection.Find(new BsonDocument());
                        {
                            foreach (var doc in cursor.ToList())
                            {
                                if (doc is Warrior) lbUnits.Items.Add(doc);
                            }
                        }
                    }
                    catch { }
                    break;

                case 2:
                    lbUnits.Items.Clear();

                    try
                    {
                        var cursor = MongoDb.collection.Find(new BsonDocument());
                        {
                            foreach (var doc in cursor.ToList())
                            {
                                if (doc is Rogue) lbUnits.Items.Add(doc);
                            }
                        }
                    }
                    catch { }
                    break;

                case 3:
                    lbUnits.Items.Clear();

                    try
                    {
                        var cursor = MongoDb.collection.Find(new BsonDocument());
                        {
                            foreach (var doc in cursor.ToList())
                            {
                                if (doc is Wizard) lbUnits.Items.Add(doc);
                            }
                        }
                    }
                    catch { }
                    break;
            }
        }
    }
}
