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
using WPFcharacterictic.Core;
using MongoDBwpf;
using WPFcharacterictic.Core.Extensions;

namespace WPFcharacterictic.WPF
{
    /// <summary>
    /// Логика взаимодействия для Competition.xaml
    /// </summary>
    public partial class Competition : Page
    {
        List<Entity> entities = MongoDBwpf<Entity>.GetAll("Units").ToList();
        public Competition()
        {
            InitializeComponent();

            ComboBox[] teamOne = new ComboBox[]
            {
                 userTeam1One,  userTeam2One,
                 userTeam3One,  userTeam4One,
                 userTeam5One,  userTeam6One
            };
            ComboBox[] teamTwo = new ComboBox[]
            {
                 userTeam1Two,  userTeam2Two,
                 userTeam3Two,  userTeam4Two,
                 userTeam5Two,  userTeam6Two
            };

            foreach (var user in teamOne) 
            {
                foreach (var entity in entities)
                {
                    user.Items.Add(entity);
                }
            }

            foreach (var user in teamTwo) 
            {
                foreach (var entity in entities)
                {
                    user.Items.Add(entity);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnAutoClick(object sender, RoutedEventArgs e)
        {
            averageLevelOne.Text = "0";
            averageLevelTwo.Text = "0";

            var rnd = new Random();

            List<Entity> enties = MongoDBwpf<Entity>.GetAll("Units").ToList();

            ComboBox[] teamOne = new ComboBox[]
            {
                 userTeam1One,  userTeam2One,
                 userTeam3One,  userTeam4One,
                 userTeam5One,  userTeam6One
            };
            ComboBox[] teamTwo = new ComboBox[]
            {
                 userTeam1Two,  userTeam2Two,
                 userTeam3Two,  userTeam4Two,
                 userTeam5Two,  userTeam6Two
            };

            foreach (var user in teamOne)
            {
                user.Items.Clear();
            }
            foreach (var user in teamTwo)
            {
                user.Items.Clear();
            }

            foreach (var user in teamOne)
            {
                int randomUser = rnd.Next(0, enties.Count);
                var entity = enties[randomUser];
                enties.RemoveAt(randomUser);
                user.Items.Add(entity);
                averageLevelOne.Text = (Convert.ToInt32(averageLevelOne.Text) + entity.Level).ToString();
            }

            List<Entity> _entities;

            while (Math.Abs(Convert.ToInt32(averageLevelOne.Text) - Convert.ToInt32(averageLevelTwo.Text)) > 2) 
            {
                _entities = enties.GetShallowCopy();

                averageLevelTwo.Text = "0";

                foreach (var user in teamTwo)
                {
                    user.Items.Clear();
                }

                foreach (var user in teamTwo)
                {
                    int randomUser = rnd.Next(0, _entities.Count);
                    var entity = _entities[randomUser];
                    _entities.RemoveAt(randomUser);
                    user.Items.Add(entity);
                    averageLevelTwo.Text = (Convert.ToInt32(averageLevelTwo.Text) + entity.Level).ToString();
                }
            }
        }

        private void ClickUserTeam1One(object sender, SelectionChangedEventArgs e)
        {
            var user = (Entity)e.AddedItems[0];

            averageLevelOne.Text = (Convert.ToInt32(averageLevelOne.Text) + user.Level).ToString();

            if (Math.Abs(Convert.ToInt32(averageLevelOne.Text) - Convert.ToInt32(averageLevelTwo.Text)) > 2)
            {
                averageLevelOne.Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
                averageLevelTwo.Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
            }
            else if (Math.Abs(Convert.ToInt32(averageLevelOne.Text) - Convert.ToInt32(averageLevelTwo.Text)) <= 2)
            {
                averageLevelOne.Background = new SolidColorBrush(Color.FromRgb(50, 200, 232));
                averageLevelTwo.Background = new SolidColorBrush(Color.FromRgb(50, 200, 232));
            }
        }
        private void ClickUserTeam1Two(object sender, SelectionChangedEventArgs e)
        {
            var user = (Entity)e.AddedItems[0];

            averageLevelTwo.Text = (Convert.ToInt32(averageLevelTwo.Text) + user.Level).ToString();

            if (Math.Abs(Convert.ToInt32(averageLevelOne.Text) - Convert.ToInt32(averageLevelTwo.Text)) > 2)
            {
                averageLevelOne.Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
                averageLevelTwo.Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
            }
            else if (Math.Abs(Convert.ToInt32(averageLevelOne.Text) - Convert.ToInt32(averageLevelTwo.Text)) <= 2)
            {
                averageLevelOne.Background = new SolidColorBrush(Color.FromRgb(50, 200, 232));
                averageLevelTwo.Background = new SolidColorBrush(Color.FromRgb(50, 200, 232));
            }
        }

    }
}
