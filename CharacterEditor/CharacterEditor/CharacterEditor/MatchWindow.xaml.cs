using CharacterEditorCore;
using CharacterEditorCore.Match;
using CharacterEditorMongoDb;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CharacterEditor
{
    /// <summary>
    /// Interaction logic for MatchWindow.xaml
    /// </summary>
    public partial class MatchWindow : Window
    {
        private ICharacterRepository _characterRepos;
        private MatchRepository _matchRepository;
        private Match _currentMatch;
        private List<CharacterEditorCore.Match.MatchCharacterInfo> _characters;
        public delegate void OnCharacterAddDelegate();
        public event OnCharacterAddDelegate OnCharacterAdd;

        public MatchWindow(ICharacterRepository repos, DBConnection connection)
        {
            InitializeComponent();

            _characterRepos = repos;

            try
            {
                _matchRepository = new MatchRepository(connection);
            }
            catch
            {
                MessageBox.Show("Failed to connect to the database", "Warning");
            }

            _currentMatch = new Match(_characterRepos);
            OnCharacterAdd += CheckTeamsBalanced;

            if (_matchRepository != null)
            {
                _characters = _characterRepos.GetAllCharacters();
                FillCharactersCb();
            }
        }

        private void CheckTeamsBalanced()
        {
            if (_currentMatch.IsTeamsBalanced())
            {
                lbIsBalanced.Content = "Balanced";
                lbIsBalanced.Background = Brushes.Green;
            }
            else
            {
                lbIsBalanced.Content = "Disbalanced";
                lbIsBalanced.Background = Brushes.Red;
            }
        }

        private void FillCharactersCb()
        {
            cbCharacters.Items.Clear();

            foreach (var character in _characters)
            {
                cbCharacters.Items.Add(character);
            }
        }

        private void btnAddFirstTeam_Click(object sender, RoutedEventArgs e)
        {
            if (cbCharacters.SelectedItem != null)
            {
                var character = cbCharacters.SelectedItem as CharacterEditorCore.Match.MatchCharacterInfo;
                _currentMatch.AddCharacter(_currentMatch.FirstTeam, character);
                lvFirstTeam.Items.Add(character);
                cbCharacters.Items.Remove(character);
                OnCharacterAdd?.Invoke();
            }
        }

        private void btnAddSecondTeam_Click(object sender, RoutedEventArgs e)
        {
            if (cbCharacters.SelectedItem != null)
            {
                var character = cbCharacters.SelectedItem as CharacterEditorCore.Match.MatchCharacterInfo;
                _currentMatch.AddCharacter(_currentMatch.SecondTeam, character);
                lvSecondTeam.Items.Add(character);
                cbCharacters.Items.Remove(character);
                OnCharacterAdd?.Invoke();
            }
        }

        private void btnDeleteFirstTeam_Click(object sender, RoutedEventArgs e)
        {
            if (lvFirstTeam.SelectedItem == null)
            {
                return;
            }

            var character = lvFirstTeam.SelectedItem as CharacterEditorCore.Match.MatchCharacterInfo;
            _currentMatch.FirstTeam.Remove(character);
            lvFirstTeam.Items.Remove(character);
            cbCharacters.Items.Add(character);
            OnCharacterAdd?.Invoke();
        }

        private void btnDeleteSecondTeam_Click(object sender, RoutedEventArgs e)
        {
            if (lvSecondTeam.SelectedItem == null)
            {
                return;
            }

            var character = lvSecondTeam.SelectedItem as CharacterEditorCore.Match.MatchCharacterInfo;
            _currentMatch.SecondTeam.Remove(character);
            lvSecondTeam.Items.Remove(character);
            cbCharacters.Items.Add(character);
            OnCharacterAdd?.Invoke();
        }

        private void btnAutoGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (_currentMatch.GetTeamCharactersCount() * 2 > _characters.Count)
            {
                MessageBox.Show("Not enough characters!");
            }

            _currentMatch.AutoGenerate();
            FillTeamData(_currentMatch.FirstTeam, lvFirstTeam);
            FillTeamData(_currentMatch.SecondTeam, lvSecondTeam);

            cbCharacters.Items.Clear();

            foreach (var character in _characters)
            {
                if (_currentMatch.FirstTeam.FirstOrDefault(x => x.Id == character.Id) == null
                    && _currentMatch.SecondTeam.FirstOrDefault(x => x.Id == character.Id) == null)
                {
                    cbCharacters.Items.Add(character);
                }
            }
            OnCharacterAdd?.Invoke();
        }

        private void FillTeamData(List<CharacterEditorCore.Match.MatchCharacterInfo> characters, ListView list)
        {
            list.Items.Clear();

            foreach (var character in characters)
            {
                list.Items.Add(character);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (_currentMatch.StartMatch())
            {
                _matchRepository.InsertMatchInfo(_currentMatch);
                MessageBox.Show("Match successfully started!");
            }
            else
            {
                MessageBox.Show("Teams are not balanced!");
            }
        }
    }
}