using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CreateCharacterWarcraftWpf
{
    /// <summary>
    /// Логика взаимодействия для Match.xaml
    /// </summary>
    public partial class Match : Window
    {
        public delegate void OnCharacterAddDelegate();
        public event OnCharacterAddDelegate OnCharacterAdd;
        public Match()
        {
            InitializeComponent();
        }
        private void FillListBox()
        {
            lstBoxCharacters.Items.Clear();

            var collection = Mongo.GetCollection();

            var filter = new BsonDocument();
            var collect = collection.Find(filter);
            foreach (var doc in collect.ToList())
            {
                lstBoxCharacters.Items.Add(doc.name);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillListBox();
        }

        private void btnAddFirstTeam_Click(object sender, RoutedEventArgs e)
        {
            Character unit = Mongo.TakeUnit(lstBoxCharacters.SelectedValue.ToString());
            lstBoxFirstTeam.Items.Add(unit.name + " " + unit.level);
            lstBoxCharacters.Items.Remove(unit.name);
            OnCharacterAdd?.Invoke();
            checkBalanced();
        }

        private void btnAddSecondTeam_Click(object sender, RoutedEventArgs e)
        {
            Character unit = Mongo.TakeUnit(lstBoxCharacters.SelectedValue.ToString());
            lstBoxTwoTeam.Items.Add(unit.name + " " + unit.level);
            lstBoxCharacters.Items.Remove(unit.name);
            OnCharacterAdd?.Invoke();
            checkBalanced();
        }

        private void btnDeleteFirstTeam_Click(object sender, RoutedEventArgs e)
        {
            string line = parsMatch(lstBoxFirstTeam.SelectedValue.ToString());
            Character unit = Mongo.TakeUnit(line);
            lstBoxFirstTeam.Items.Remove(lstBoxFirstTeam.SelectedValue.ToString());
            lstBoxCharacters.Items.Add(unit.name);
            checkBalanced();
        }
        
        private void btnDeleteSecondTeam_Click(object sender, RoutedEventArgs e)
        {
            string line = parsMatch(lstBoxTwoTeam.SelectedValue.ToString());
            Character unit = Mongo.TakeUnit(line);
            lstBoxTwoTeam.Items.Remove(lstBoxTwoTeam.SelectedValue.ToString());
            lstBoxCharacters.Items.Add(unit.name);
            checkBalanced();
        }
        public void checkBalanced()
        {
            int[] one = new int[lstBoxFirstTeam.Items.Count];
            int[] two = new int[lstBoxTwoTeam.Items.Count];
            double oneNum = 0;
            double twoNum = 0;

            for (int i = 0; i < lstBoxFirstTeam.Items.Count; i++)
            {
                one[i] = Convert.ToInt32(parsLevel(lstBoxFirstTeam.Items[i].ToString()));
            }

            for (int i = 0; i < lstBoxTwoTeam.Items.Count; i++)
            {
                two[i] = Convert.ToInt32(parsLevel(lstBoxTwoTeam.Items[i].ToString()));
            }

            for (int i = 0; i < one.Length; i++)
            {
                oneNum = oneNum + one[i];
            }

            for (int i = 0; i < two.Length; i++)
            {
                twoNum = twoNum + two[i];
            }

            if(Math.Abs(oneNum-twoNum) > 5 || one.Length == 0 || two.Length ==  0)
            {
                lbIsBalanced.Background = Brushes.Red;
                lbIsBalanced.Content = "Imbalanced";
            }
            else
            {
                lbIsBalanced.Background = Brushes.Green;
                lbIsBalanced.Content = "Balanced";
            }
        }
        public string parsMatch(string name)
        {
            string[] subs = name.Split(' ');
            return subs[0];
        }
        public string parsLevel(string name)
        {
            string[] subs = name.Split(' ');
            return subs[1];
        }

        private void btnAutoGenerate_Click(object sender, RoutedEventArgs e)
        {
            lstBoxFirstTeam.Items.Clear();
            lstBoxTwoTeam.Items.Clear();
            lstBoxCharacters.Items.Clear();
            FillListBox();
            Random rnd = new Random();
            int i = 0;
            do
            {
                i = rnd.Next(1, 2);
                lstBoxCharacters.SelectedIndex = 0;
                if (lstBoxCharacters.Items.Count != 0)
                {
                    if (i == 1)
                    {
                        Character unit = Mongo.TakeUnit(parsMatch(lstBoxCharacters.Items[0].ToString()));
                        lstBoxFirstTeam.Items.Add(unit.name + " " + unit.level);
                        lstBoxCharacters.Items.Remove(unit.name);
                        OnCharacterAdd?.Invoke();
                        checkBalanced();
                    }
                    else
                    {
                        Character unit = Mongo.TakeUnit(parsMatch(lstBoxCharacters.Items[0].ToString()));
                        lstBoxTwoTeam.Items.Add(unit.name + " " + unit.level);
                        lstBoxCharacters.Items.Remove(unit.name);
                        OnCharacterAdd?.Invoke();
                        checkBalanced();
                    }
                }
                else
                {
                    lstBoxFirstTeam.Items.Clear();
                    lstBoxTwoTeam.Items.Clear();
                    lstBoxCharacters.Items.Clear();
                }
            }
            while (lbIsBalanced.Background == Brushes.Red);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int i = rnd.Next(0, lstBoxFirstTeam.Items.Count);
            Character oneCharachter = Mongo.TakeUnit(parsMatch(lstBoxFirstTeam.Items[i].ToString()));

            i = rnd.Next(0, lstBoxTwoTeam.Items.Count);
            Character twoCharachter = Mongo.TakeUnit(parsMatch(lstBoxTwoTeam.Items[i].ToString()));

            Thread myThread = new Thread(Fight);
            
            myThread.Start();

            while (oneCharachter.alive() && twoCharachter.alive())
            {
                tbInfoMatch.Text = tbInfoMatch.Text + (twoCharachter.name + " attack " + oneCharachter.name +
                    ", left " + oneCharachter.healthPoint);
                twoCharachter.Attack(oneCharachter);
                Thread.Sleep(1000);
            }

            void Fight()
            {
                while (oneCharachter.alive() && twoCharachter.alive())
                {
                    tbInfoMatch.Text = tbInfoMatch.Text + (oneCharachter.name + " attack " + twoCharachter.name +
                        ", left " + twoCharachter.healthPoint);
                    oneCharachter.Attack(twoCharachter);
                    Thread.Sleep(1000);
                }
            }

            if (oneCharachter.alive())
            {
                tbInfoMatch.Text =  (oneCharachter.name + " kill " + twoCharachter.name);
            }
            else
            {
                tbInfoMatch.Text =  (twoCharachter.name + " kill " + oneCharachter.name);
            }
        }
    }
}
