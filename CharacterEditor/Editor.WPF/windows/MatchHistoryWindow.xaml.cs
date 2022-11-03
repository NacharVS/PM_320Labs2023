using DataProvider;
using Editor.Core.Characters;
using Editor.Core.MatchHistory;
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
using System.Windows.Shapes;

namespace Editor.WPF.windows
{
    /// <summary>
    /// Interaction logic for MatchHistoryWindow.xaml
    /// </summary>
    public partial class MatchHistoryWindow : Window
    {
        private MongoProvider<MatchHistory> _matchProvider;
        private MongoProvider<Character> _characterProvider;
        public MatchHistoryWindow(MongoProvider<MatchHistory> matchProvider, MongoProvider<Character> characterProvider)
        {
            InitializeComponent();

            _matchProvider = matchProvider;
            _characterProvider = characterProvider;

            comboMatches.ItemsSource = _matchProvider.LoadAll();
        }

        private void comboMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var team1players = new List<Character>();
            var team2players = new List<Character>();

            var match = comboMatches.SelectedItem as MatchHistory;
            var team1 = match.Teams[0];
            var team2 = match.Teams[1];

            lbTeam1.Content = team1;
            lbTeam2.Content = team2;

            foreach (var i in match.PlayerRecords.Where(x => x.TeamName == team1))
            {
                team1players.Add(_characterProvider.Load(i.CharacterName));
            }

            foreach (var i in match.PlayerRecords.Where(x => x.TeamName == team2))
            {
                team2players.Add(_characterProvider.Load(i.CharacterName));
            }

            lbteam1players.ItemsSource = team1players;
            lbteam2players.ItemsSource = team2players;
        }
    }
}
