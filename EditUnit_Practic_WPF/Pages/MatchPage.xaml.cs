using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Units_Practic.Characters;
using Units_Practic.MongoDb;
using Match = Units_Practic.Match;

namespace EditUnit_Practic_WPF.Pages
{
    /// <summary>
    /// Interaction logic for MatchPage.xaml
    /// </summary>
    public partial class MatchPage : Page
    {
        Match match;
        List<Unit> units = new List<Unit>();
        List<ObjectId> firstTeam = new List<ObjectId>();
        List<ObjectId> secondTeam = new List<ObjectId>();
        bool balanced;

        public MatchPage()
        {
            InitializeComponent();
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            GetUnitsFromDb();
            UpdateCharacteristics();
        }

        public void UpdateCharacteristics()
        {
            FillTeam(firstTeam, lb_firstTeam);
            FillTeam(secondTeam, lb_secondTeam);
            FillMatchesFromDB();
            Fill_lb_allCharacters();
        }

        public void FillTeam(List<ObjectId> team, ListBox list)
        {
            list.Items.Clear();

            foreach (var id in team) list.Items.Add(MongoDb.FindById(id.ToString()));

            ChangeBalanceStatus();
            DisplayAverageLevel();
            UpdateBalanceStatus();
        }

        public void GetUnitsFromDb()
        {
            units.Clear();

            var collection = MongoDb.GetCollection();
            try
            {
                var filter = new BsonDocument();
                using var cursor = collection.FindSync(filter);
                {
                    while (cursor.MoveNext())
                    {
                        var docs = cursor.Current;

                        foreach (var doc in docs) units.Add(doc);
                    }
                }
            }
            catch { }
        }

        private void Fill_lb_allCharacters()
        {
            lb_allCharacters.Items.Clear();
            foreach (var unit in units) lb_allCharacters.Items.Add(unit);
        }

        public void AddUnitToTeam(List<ObjectId> team)
        {
            if (team.Count < 6)
            {
                var unit = (Unit)lb_allCharacters.SelectedItem;
                team.Add(unit._id);
                units.Remove(unit);

                UpdateCharacteristics();
            }
            else MessageBox.Show("Max size team!");
        }

        public void DeleteUnitFromTeam(List<ObjectId> team, ListBox box)
        {
            if (!lb_allCharacters.IsEnabled)
            {
                ClearCharFromTeams();
                UpdateCharacteristics();
                return;
            }

            var unit = (Unit)box.SelectedItem;
            team.Remove(unit._id);
            units.Add(unit);

            UpdateCharacteristics();
        }

        private void ChangeBalanceStatus()
        {
            if (CheckTeamBalance() && (!txt_FirstTeamAverLvl.Text.Equals("0") && !txt_SecondTeamAverLvl.Text.Equals("0"))) 
                balanced = true;

            else balanced = false;
        }

        private void UpdateBalanceStatus()
        {
            if (balanced) txt_Status.Text = "Teams is balanced.";
            else txt_Status.Text = "Teams are not balanced.";
        }

        private void DisplayAverageLevel()
        {
            txt_FirstTeamAverLvl.Text = CalcAverageLevel(firstTeam).ToString();
            txt_SecondTeamAverLvl.Text = CalcAverageLevel(secondTeam).ToString();
        }

        private bool CheckTeamBalance()
        {
            double firstTeamAverage = CalcAverageLevel(firstTeam);
            double secondTeamAverage = CalcAverageLevel(secondTeam);

            return Math.Abs(firstTeamAverage - secondTeamAverage) <= 1;
        }

        private double CalcAverageLevel(List<ObjectId> ids)
        {
            double avgLvl = 0;

            if (ids.Count != 0)
            {
                foreach (var id in ids) 
                    avgLvl += MongoDb.FindById(id.ToString()).lvl.lvl;

                return Math.Round(avgLvl / 6, 2);
            }
            else return 0;
        }

        private void btn_AutoFill_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            if (firstTeam.Count != 0 || secondTeam.Count != 0) ClearCharFromTeams();

            while (true)
            {
                var tempUnits = units;

                foreach (var unit in tempUnits)
                {
                    var temp = random.Next(1, 3);

                    if (temp == 1 && firstTeam.Count < 6) firstTeam.Add(unit._id);
                    else if (temp == 2 && secondTeam.Count < 6) secondTeam.Add(unit._id);
                }

                if (CheckTeamBalance() /*&& (firstTeam.Count == 6 && secondTeam.Count == 6)*/) break;
                else ClearCharFromTeams();
            }

            lb_allCharacters.IsEnabled = false;

            UpdateCharacteristics();
        }

        private void ClearCharFromTeams()
        {
            firstTeam.Clear();
            secondTeam.Clear();
            lb_allCharacters.IsEnabled = true;

            GetUnitsFromDb();
        }

        private void btn_StartMatch_Click(object sender, RoutedEventArgs e)
        {
            if (balanced)
            {
                match = new Match();
                match.firstTeam = firstTeam;
                match.secondTeam = secondTeam;
                match.date = DateTime.Now;
                MongoDb.AddMatchToDataBase(match);

                lb_allCharacters.Items.Clear();
                lb_firstTeam.Items.Clear();
                lb_secondTeam.Items.Clear();

                ClearCharFromTeams();
            }
            else MessageBox.Show("Teams are not balanced.");

            UpdateCharacteristics();
        }

        private void lb_firstTeam_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lb_firstTeam.SelectedItem is not null) DeleteUnitFromTeam(firstTeam, lb_firstTeam);
        }

        private void lb_secondTeam_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lb_secondTeam.SelectedItem is not null) DeleteUnitFromTeam(secondTeam, lb_secondTeam);
        }

        private void btn_AddToSecondTeam_Click(object sender, RoutedEventArgs e)
        {
            if (lb_allCharacters.SelectedItem is not null) AddUnitToTeam(secondTeam);
        }

        private void btn_AddToFirstTeam_Click(object sender, RoutedEventArgs e)
        {
            if (lb_allCharacters.SelectedItem is not null) AddUnitToTeam(firstTeam);
        }

        private void FillMatchesFromDB()
        {
            lb_allMatches.Items.Clear();

            var collection = MongoDb.matchCollection;
            try
            {
                var filter = new BsonDocument();
                using var cursor = collection.FindSync<Match>(filter);
                {
                    while (cursor.MoveNext())
                    {
                        var docs = cursor.Current;
                        foreach (var doc in docs) lb_allMatches.Items.Add(doc);
                    }
                }
            }
            catch { }
        }
    }
}
