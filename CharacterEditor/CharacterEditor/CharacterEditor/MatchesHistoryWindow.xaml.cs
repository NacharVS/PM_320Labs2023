using CharacterEditorCore;
using CharacterEditorMongoDb;
using System.Windows;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for MatchesHistoryWindow.xaml
    /// </summary>
    public partial class MatchesHistoryWindow : Window
    {
        private MatchRepository _repos;
        private ICharacterRepository _characterRepository;

        public MatchesHistoryWindow(DBConnection connection, ICharacterRepository characterRepository)
        {
            InitializeComponent();

            _characterRepository = characterRepository;

            try
            {
                _repos = new MatchRepository(connection);
            }
            catch
            {
                MessageBox.Show("Failed to connect to the database", "Warning");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCbMathes();
        }

        private void FillCbMathes()
        {
            var matches = _repos.GetAllMatches();

            cbMatches.Items.Clear();

            foreach(var match in matches)
            {
                match.StartDate = match.StartDate.AddHours(3);
                cbMatches.Items.Add(match);
            }
        }

        private void cbMatches_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbMatches.SelectedItem != null)
            {
                var match = (MatchDB)cbMatches.SelectedItem;
                var matchDb = _repos.GetMatchById(match.Id.ToString());
                FillTeamsCharactersData(match);
            }
        }

        private void FillTeamsCharactersData(MatchDB match)
        {
            if (match == null)
            {
                return;
            }

            var team = match.FirstTeam;

            lvFirstTeam.Items.Clear();
            foreach (var item in team)
            {
                lvFirstTeam.Items.Add(item);
            }

            team = match.SecondTeam;

            lvSecondTeam.Items.Clear();
            foreach (var item in team)
            {
                lvSecondTeam.Items.Add(item);
            }
        }

        private void lvFirstTeam_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (lvFirstTeam.SelectedItem != null)
                {
                    try
                    {
                        var character = (CharacterEditorCore.Match.MatchCharacterInfo)lvFirstTeam.SelectedItem;
                        var win = new MatchCharacterInfo(_characterRepository.GetCharacterById(character.Id));
                        win.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Character not founded!", "Warning");
                    }
                    
                }
            }
        }

        private void lvSecondTeam_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (lvSecondTeam.SelectedItem != null)
                {
                    try
                    {
                        var character = (CharacterEditorCore.Match.MatchCharacterInfo)lvSecondTeam.SelectedItem;
                        var win = new MatchCharacterInfo(_characterRepository.GetCharacterById(character.Id));
                        win.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Character not founded!", "Warning");
                    }

                }
            }
        }
    }
}