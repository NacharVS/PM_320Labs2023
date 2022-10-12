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
        public MatchInfo _match;
        private delegate void TeamCharactersChangeDelegate();

        public MathInfo(CharacterEditorContext charContext)
        {
            InitializeComponent();

            _charContext = charContext;
            
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
                lblTeamBalance.Background = new BrushConverter().ConvertFromString("Green") as Brush;
            }
            else
            {
                lblTeamBalance.Content = "DISBALANCED";
                lblTeamBalance.Background = new BrushConverter().ConvertFromString("Red") as Brush;
            }
        }

        private event TeamCharactersChangeDelegate OnTeamCharactersChange;

        private void btnAutoGeneration_Click(object sender, RoutedEventArgs e)
        {
            _match.AutoGenerate();
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
        }

        private void btnRemoveTeamB_Click(object sender, RoutedEventArgs e)
        {
            var deletedCharacter = (CharacterIdName)lbTeamAList.SelectedItem;

            if (deletedCharacter is null)
            {
                return;
            }
            _match.SecondTeam.Remove(deletedCharacter);
            lbTeamBList.Items.Remove(deletedCharacter);
        }
    }
}
