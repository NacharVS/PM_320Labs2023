using CharacterEditorCore.Match;
using CharacterEditorMongoDataBase;
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

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for MatchLoad.xaml
    /// </summary>
    public partial class MatchLoad : Page
    {
        private readonly MatchInfoContext _matchContext;
        public MatchLoad()
        {
            InitializeComponent();
            _matchContext = new();
            lvMatchesList.ItemsSource = _matchContext.GetAllMatches();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var match = _matchContext.GetMatch(((MatchInfo)lvMatchesList.SelectedItem).Id);
            if(match is null)
            {
                return;
            }
            FillTeamsList(match);
        }

        private void FillTeamsList(MatchInfo match)
        {
            lbTeamAList.Items.Clear();
            lbTeamBList.Items.Clear();
            foreach (var character in match.FirstTeam)
            {
                lbTeamAList.Items.Add(character);
            }
            foreach (var character in match.SecondTeam)
            {
                lbTeamBList.Items.Add(character);
            }
        }

        private void btnShowCharacter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
