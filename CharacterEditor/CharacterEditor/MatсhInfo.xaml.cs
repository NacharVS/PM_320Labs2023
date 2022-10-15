using CharacterEditorCore;
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
    /// Interaction logic for MathInfo.xaml
    /// </summary>
    public partial class MathInfo : Page
    {
        private readonly CharacterEditorContext _charContext;
        private readonly MatchInfoContext _matchContext;
        public MatchInfo _match;
        private delegate void TeamCharactersChangeDelegate();

        public MathInfo(CharacterEditorContext charContext)
        {
            InitializeComponent();

            _charContext = charContext;
            _matchContext = new MatchInfoContext();

            lvCharactersList.ItemsSource = _charContext.GetAllChars();
            _match = new(new MatchInfoContext(), _charContext);
            OnTeamCharactersChange += FillBalanced;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAddTeamA_Click(object sender, RoutedEventArgs e)
        {
            var character = (CharacterIdName)lvCharactersList.SelectedItem;
            if (character is null)
            {
                return;
            }
            if (_match.FirstTeam.FirstOrDefault(x => 
            x.Id == character.Id) is null
            && _match.SecondTeam.FirstOrDefault(x =>
            x.Id == character.Id) is null)
            {
                _match.AddToTeam(_match.FirstTeam, character);
                lbTeamAList.Items.Add(character);
                OnTeamCharactersChange?.Invoke();
            }
        }

        private void btnAddTeamB_Click(object sender, RoutedEventArgs e)
        {
            var character = (CharacterIdName)lvCharactersList.SelectedItem;
            if (character is null)
            {
                return;
            }
            if(_match.SecondTeam.FirstOrDefault(x =>
            x.Id == character.Id) is null
            && _match.FirstTeam.FirstOrDefault(x =>
            x.Id == character.Id) is null)
            {
                _match.AddToTeam(_match.SecondTeam, character);
                lbTeamBList.Items.Add(character);
                OnTeamCharactersChange?.Invoke();
            }
        }

        private void FillBalanced()
        {
            if(_match.TeamsBlanceCheck())
            {
                lblTeamBalance.Content = "BALANCED";
                lblTeamBalance.Background = new BrushConverter()
                    .ConvertFromString("Green") as Brush;
            }
            else
            {
                lblTeamBalance.Content = "DISBALANCED";
                lblTeamBalance.Background = new BrushConverter()
                    .ConvertFromString("Red") as Brush;
            }
        }

        private void btnAutoGeneration_Click(object sender, RoutedEventArgs e)
        {
            lbTeamAList.Items.Clear();
            lbTeamBList.Items.Clear();
            _match.AutoGenerate();
            OnTeamCharactersChange?.Invoke();
            FillTeamsList();
        }

        private void FillTeamsList()
        {
            foreach (var character in _match.FirstTeam)
            {
                lbTeamAList.Items.Add(character);
            }
            foreach (var character in _match.SecondTeam)
            {
                lbTeamBList.Items.Add(character);
            }
        }

        private void btnRemoveTeamA_Click(object sender, RoutedEventArgs e)
        {
            var deletedCharacter = (CharacterIdName)lbTeamAList.SelectedItem;

            if(deletedCharacter is null)
            {
                return;
            }
            _match.FirstTeam.Remove(deletedCharacter);
            lbTeamAList.Items.Remove(deletedCharacter);
            OnTeamCharactersChange?.Invoke();
        }

        private void btnRemoveTeamB_Click(object sender, RoutedEventArgs e)
        {
            var deletedCharacter = (CharacterIdName)lbTeamBList.SelectedItem;

            if (deletedCharacter is null)
            {
                return;
            }
            _match.SecondTeam.Remove(deletedCharacter);
            lbTeamBList.Items.Remove(deletedCharacter);
            OnTeamCharactersChange?.Invoke();
        }

        private event TeamCharactersChangeDelegate OnTeamCharactersChange;

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            frameMatch.Navigate(new MatchLoad(_charContext));
        }

        private void btnStartMatch_Click(object sender, RoutedEventArgs e)
        {
            if (_match is null)
            {
                return;
            }
            if(_match.TeamsBlanceCheck())
            {
                _match.StartMatch();
                if(_matchContext.SaveMatch(_match))
                {
                    MessageBox.Show("Save succesfull!");
                }
            }
            _match = new MatchInfo(_matchContext, _charContext);
            lbTeamAList.Items.Clear();
            lbTeamBList.Items.Clear();
        }
    }
}
