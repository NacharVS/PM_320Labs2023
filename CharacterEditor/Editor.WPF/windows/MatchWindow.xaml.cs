using DataProvider;
using Editor.Core.Characters;
using Editor.Core.MatchHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Editor.WPF.windows
{
    /// <summary>
    /// Interaction logic for MatchWindow.xaml
    /// </summary>
    public partial class MatchWindow : Window
    {
        private List<Character> characters;
        private MongoProvider<Character> _provider;

        public MatchHistory MatchHistory { get; set; }

        public MatchWindow(MongoProvider<Character> provider)
        {
            InitializeComponent();
            _provider = provider;

            characters = _provider.LoadAll()?.ToList();

            teamDataGrid.ItemsSource = characters;
        }

        private void btnAddT1_Click(object sender, RoutedEventArgs e)
        {
            if (lbTeam1.Items.Count == 6)
            {
                MessageBox.Show("Team is full");
                return;
            }

            lbTeam1.Items.Add(teamDataGrid.SelectedItem as Character);
            characters.Remove(teamDataGrid.SelectedItem as Character);

            UpdateInfo();
        }

        private void btnAddT2_Click(object sender, RoutedEventArgs e)
        {
            if (lbTeam2.Items.Count == 6)
            {
                MessageBox.Show("Team is full");
                return;
            }

            lbTeam2.Items.Add(teamDataGrid.SelectedItem as Character);
            characters.Remove(teamDataGrid.SelectedItem as Character);

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            lbBalance.Content = CheckBalance() ? "Balanced" : "Not balanced";
        }

        private bool CheckBalance(bool checkCount = false)
        {
            double team1lvl = 0;
            double team2lvl = 0;

            if (lbTeam1.Items.Count == 0 || lbTeam2.Items.Count == 0)
            {
                return false;
            }
                
            foreach (Character character in lbTeam1.Items)
            {
                team1lvl += character.Level;
            }

            foreach (Character character in lbTeam2.Items)
            {
                team2lvl += character.Level;
            }

            if (checkCount)
            {
                return (lbTeam1.Items.Count == lbTeam2.Items.Count && lbTeam1.Items.Count == 6)
                    && (Math.Abs(team1lvl - team2lvl) <= 2);
            }

            lbT1Summary.Content = team1lvl;
            lbT2Summary.Content = team2lvl;

            return Math.Abs(team1lvl - team2lvl) <= 2;
        }

        private bool CheckBalance(List<Character> team1, List<Character> team2)
        {
            double team1lvl = 0;
            double team2lvl = 0;

            if (team1.Count == 0 || team2.Count == 0)
            {
                return false;
            }

            foreach (Character character in team1)
            {
                team1lvl += character.Level;
            }

            foreach (Character character in team2)
            {
                team2lvl += character.Level;
            }

            lbT1Summary.Content = team1lvl;
            lbT2Summary.Content = team2lvl;

            return Math.Abs(team1lvl - team2lvl) <= 2;
        }

        private void btnStartMatch_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBalance())
            {
                var playerRecords = new List<MatchPlayerRecord>();
                foreach (Character character in lbTeam1.Items)
                {
                    playerRecords.Add(new MatchPlayerRecord(Guid.NewGuid().ToString(), $"{character.Name} {DateTime.Now}", character.Name, tbTeam1Name.Text));
                }
                foreach (Character character in lbTeam2.Items)
                {
                    playerRecords.Add(new MatchPlayerRecord(Guid.NewGuid().ToString(), $"{character.Name} {DateTime.Now}", character.Name, tbTeam2Name.Text));
                }

                DialogResult = true;
                MatchHistory = new MatchHistory
                {
                    Date = DateTime.Now,
                    Name = $"Match by {DateTime.Now}",
                    PlayerRecords = playerRecords.ToArray(),
                    Teams = new string[] { tbTeam1Name.Text, tbTeam2Name.Text }
                };
            }
            else
            {
                MessageBox.Show("Teams not balanced");
            }
        }

        private void btnAutoBalance_Click(object sender, RoutedEventArgs e)
        {
            characters = _provider.LoadAll()?.OrderBy(x => x.Level).Reverse().ToList();

            List<Character> firstTeam = new();
            List<Character> secondTeam = new();

            lbTeam1.Items.Clear();
            lbTeam2.Items.Clear();

            for (int z = 0; z < 50; ++z)
            {
                firstTeam = new();
                secondTeam = new();
                var sl1 = Random.Shared.Next(characters.Count - 12 + 1);

                foreach (var i in characters.ToArray()[sl1..][..12])
                {
                    if (firstTeam.Sum(x => x.Level) < secondTeam.Sum(x => x.Level))
                    {
                        if (firstTeam.Count == 6)
                        {
                            continue;
                        }
                        firstTeam.Add(i);
                    }
                    else
                    {
                        if (secondTeam.Count == 6)
                        {
                            continue;
                        }
                        secondTeam.Add(i);
                    }

                }

                if ((firstTeam.Count == 6 && secondTeam.Count == 6) && CheckBalance(firstTeam, secondTeam))
                {
                    break;
                }
            }

            var team1sum = firstTeam.Sum(x => x.Level);
            var team2sum = secondTeam.Sum(x => x.Level);

            if (firstTeam.Count < 6)
            {
                while (firstTeam.Count != 6)
                {
                    var diff = Math.Abs(team2sum - team1sum);
                    firstTeam.Add(characters.Except(firstTeam.Union(secondTeam)).OrderBy(x => diff - x.Level).ToArray()[0]);
                    team1sum += secondTeam[^1].Level;
                }
            }

            if (secondTeam.Count < 6)
            {
                while (secondTeam.Count != 6)
                {
                    var diff = Math.Abs(team1sum - team2sum);
                    secondTeam.Add(characters.Except(firstTeam.Union(secondTeam)).OrderBy(x => diff - x.Level).ToArray()[0]);
                    team2sum += secondTeam[^1].Level;
                }
            }

            for (int i = 0; i < 6; ++i)
            {
                lbTeam1.Items.Add(firstTeam[i]);
                lbTeam2.Items.Add(secondTeam[i]);

                characters.Remove(firstTeam[i]);
                characters.Remove(secondTeam[i]);
            }

            UpdateInfo();

            if (!CheckBalance())
            {
                MessageBox.Show("Teams can't be balanced");
                return;
            }
        }
    }
}
