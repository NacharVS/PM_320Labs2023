using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCharacterEditor
{
    public partial class MatchCreator : Form
    {
        private Match match;
        private Character character = new Character();
        private int numberTeam;
        public MatchCreator()
        {
            InitializeComponent();
            CharacterListUpdate();
            MatchListUpdate();
            //AddToolStrips();
        }

        private void CharacterListUpdate()
        {
            var collection = DataBase.ImportCharacterDataBase();

            foreach (var c in collection)
            {
                SavedCharactersBox.Items.Add(c.Name);
            }
        }

        private void MatchListUpdate()
        {
            var collection = DataBase.ImportMatchDataBase();

            foreach (var c in collection)
            {
                Match_ListBox.Items.Add(c.NumberMatch);
            }
        }
        
        public void Display()
        {
            TeamType_Label.Visible = false;
            CustomTeam_Button.Visible = false;
            AutoTeam_Button.Visible = false;
            Or_Lable.Visible = false;
            MatchInfo_Button.Visible = false;
            FirstTeam_ListBox.Visible = true;
            FirstTeam_Label.Visible = true;
            SecondTeam_ListBox.Visible = true;
            SecondTeam_Label.Visible = true;
            ClearFirst_Button.Visible = true;
            ClearSecond_Button.Visible = true;
            HoldMatch_Button.Visible = true;
            MatchNumber.Visible = true;
            Balance_Text.Visible = true;
        }

        private void AutoTeam_Button_Click(object sender, EventArgs e)
        {
            Display();
            AutoGenerate_Button.Visible = true;
        }

        private void AutoGenerate_Button_Click(object sender, EventArgs e)
        {
            match = new Match();
            Random rnd = new Random();
            int characterIndex = 0;

            if (FirstTeam_ListBox.Items.Count > 0 && 
                SecondTeam_ListBox.Items.Count > 0)
            {
                ClearFirst_Button_Click(sender, e);
                ClearSecond_Button_Click(sender, e);
            }
            
            while (FirstTeam_ListBox.Items.Count < 6)
            {
                numberTeam = 1;
                characterIndex = rnd.Next(0, SavedCharactersBox.Items.Count);
                FirstTeam_ListBox.Items.Add(SavedCharactersBox.Items[characterIndex]);
                SavedCharactersBox.Items.Remove(SavedCharactersBox.Items[characterIndex]);
            }

            while (SecondTeam_ListBox.Items.Count < 6)
            {
                numberTeam = 2;
                characterIndex = rnd.Next(0, SavedCharactersBox.Items.Count);
                SecondTeam_ListBox.Items.Add(SavedCharactersBox.Items[characterIndex]);
                SavedCharactersBox.Items.Remove(SavedCharactersBox.Items[characterIndex]);
            }
            AddingLists();
            Balance();
        }

        private void AddingLists()
        {
            foreach (var character in FirstTeam_ListBox.Items)
            {
                match.FirstTeam.Add(character.ToString());
            }

            foreach (var character in SecondTeam_ListBox.Items)
            {
                match.SecondTeam.Add(character.ToString());
            }
        }

        private void CustomTeam_Button_Click(object sender, EventArgs e)
        {
            Display();
            Choose_Label.Visible = true;
            SavedCharactersBox.Enabled = true;
        }

        private void SavedCharactersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstTeam_ListBox.Items.Count < 6)
            {
                FirstTeam_ListBox.Items.Add(SavedCharactersBox.Text);
                FirstTeam_ListBox.Items.Remove(FirstTeam_ListBox.Text);
            }
            else if (SecondTeam_ListBox.Items.Count < 6)
            {
                SecondTeam_ListBox.Items.Add(SavedCharactersBox.Text);
                SecondTeam_ListBox.Items.Remove(SecondTeam_ListBox.Text);
            }

            SavedCharactersBox.Items.Remove(SavedCharactersBox.Text);
            Balance();
        }

        private void ClearFirst_Button_Click(object sender, EventArgs e)
        {
            foreach (var item in FirstTeam_ListBox.Items)
            {
                SavedCharactersBox.Items.Add(item);
            }

            FirstTeam_ListBox.Items.Clear();
        }

        private void ClearSecond_Button_Click(object sender, EventArgs e)
        {
            foreach (var item in SecondTeam_ListBox.Items)
            {
                SavedCharactersBox.Items.Add(item);
            }

            SecondTeam_ListBox.Items.Clear();
        }

        private void FirstTeam_ListBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    var issue = MessageBox.Show("Do you want to remove a character from the team?",
                    "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                    if (issue == DialogResult.OK)
                    {
                        FirstTeam_ListBox.Items.Remove(FirstTeam_ListBox.Text);
                    }
                    break;
                case MouseButtons.Left:
                    GameCharacterEditor gameCharacterEditor = new GameCharacterEditor(FirstTeam_ListBox.SelectedItem.ToString());
                    gameCharacterEditor.Show();
                    break;
            }
        }

        private void SecondTeam_ListBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    var issue = MessageBox.Show("Do you want to remove a character from the team?",
                    "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

                    if (issue == DialogResult.OK)
                    {
                        SecondTeam_ListBox.Items.Remove(SecondTeam_ListBox.Text);
                    }
                    break;
                case MouseButtons.Left:
                    GameCharacterEditor gameCharacterEditor = new GameCharacterEditor(SecondTeam_ListBox.SelectedItem.ToString());
                    gameCharacterEditor.Show();
                    break;
            }
        }

        private void MatchInfo_Button_Click(object sender, EventArgs e)
        {
            Display();
            SavedCharacteers_Lable.Visible = false;
            HoldMatch_Button.Visible = false;
            Matches_Label.Visible = true;
            Match_ListBox.Visible = true;
        }

        private void Match_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            match = DataBase.FindMatchByNumber((int)Match_ListBox.SelectedItem);

            foreach (var character in match.FirstTeam)
            {
                FirstTeam_ListBox.Items.Add(character);
            }
            foreach (var character in match.SecondTeam)
            {
                SecondTeam_ListBox.Items.Add(character);
            }

            SavedCharactersBox.Items.Remove(SavedCharactersBox.Text);
            Balance();
        }

        private void HoldMatch_Button_Click(object sender, EventArgs e)
        {
            Match_ListBox.Items.Clear();
            Match_ListBox.Items.Add(match.NumberMatch);
            MatchListUpdate();
            DataBase.AddMatchToDataBase(match);
        }

        private void MatchNumber_ValueChanged(object sender, EventArgs e)
        {
            match.NumberMatch = (int)MatchNumber.Value;
        }

        public void Balance()
        {
            if (BalanceCheck())
            {
                Balance_Text.Text = "Balance";
            }
            else
            {
                Balance_Text.Text = "X";
            }
        }

        public bool BalanceCheck()
        {
            int lvlFirstTeam = 0;
            int lvlSecondTeam = 0;

            foreach (var character in FirstTeam_ListBox.Items)
            {
                lvlFirstTeam += DataBase.FindCharacterByName(character.ToString()).Lvl;
            }

            foreach (var character in SecondTeam_ListBox.Items)
            {
                lvlSecondTeam += DataBase.FindCharacterByName(character.ToString()).Lvl;
            }

            int balanceOne = lvlFirstTeam / FirstTeam_ListBox.Items.Count;
            int balanceTwo = lvlSecondTeam / SecondTeam_ListBox.Items.Count;

            return Math.Abs(balanceOne - balanceTwo) < 2;
        }

        /*public void AddToolStrips()
        {
            ToolStripMenuItem removeOneItem = new ToolStripMenuItem("Удалить");
            contextMenuStrip.Items.AddRange(new[] { removeOneItem });
            FirstTeam_ListBox.ContextMenuStrip = contextMenuStrip;
            removeOneItem.Click += FirstTeam_ListBox_SelectedIndexChanged;
        }*/
    }
}
