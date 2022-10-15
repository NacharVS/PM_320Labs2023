using CharacterEditorCore;
using CharacterEditorCore.DataBase;
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
        private readonly ICharacterRep _charContext;
        public MatchLoad(ICharacterRep charContext)
        {
            InitializeComponent();
            _matchContext = new();
            _charContext = charContext;
            lvMatchesList.ItemsSource = _matchContext.GetAllMatches();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedMatch = (MatchInfo)lvMatchesList.SelectedItem;
            if(selectedMatch is null)
            {
                return;
            }

            var match = _matchContext.GetMatch((selectedMatch.Id));
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
            CharacterIdName character;
            if (lbTeamAList.SelectedItem is null &&
                lbTeamBList.SelectedItem is null)
            {
                return;
            }

            if (lbTeamAList.SelectedItem is null &&
                lbTeamBList.SelectedItem is not null)
            {
                character = lbTeamBList.SelectedItem as CharacterIdName;
                NavigationService.Navigate(new MatchCharacterInfo(_charContext, character));
            }

            if (lbTeamBList.SelectedItem is null &&
                lbTeamAList.SelectedItem is not null)
            {
                character = lbTeamAList.SelectedItem as CharacterIdName;
                NavigationService.Navigate(new MatchCharacterInfo(_charContext, character));
            }

            if(lbTeamBList.SelectedItem is not null &&
                lbTeamAList.SelectedItem is not null)
            {
                lbTeamAList.SelectedItem = null;
                lbTeamBList.SelectedItem = null;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
