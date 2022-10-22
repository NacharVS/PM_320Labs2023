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
        private Match match = new Match();
        private Character character;
        private List<Character> characters = new List<Character>();
        private int numberTeam;
        private int min = 1000000;
        private int max = 0;
        public MatchCreator()
        {
            InitializeComponent();
            ListUpdate();
            //AddToolStrips();
        }

        private void ListUpdate()
        {
            var collection = DataBase.ImportCharacterDataBase();

            foreach (var c in collection)
            {
                SavedCharactersBox.Items.Add(c.Name);
            }
        }

        /*public void AddToolStrips()
        {
            ToolStripMenuItem removeOneItem = new ToolStripMenuItem("Удалить");
            contextMenuStrip.Items.AddRange(new[] { removeOneItem });
            FirstTeam_ListBox.ContextMenuStrip = contextMenuStrip;
            removeOneItem.Click += FirstTeam_ListBox_SelectedIndexChanged;
        }*/

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
            MatchNumber.Value = int.Parse(Match_ListBox.Items.Count.ToString());
        }

        private void AutoTeam_Button_Click(object sender, EventArgs e)
        {
            Display();
            AutoGenerate_Button.Visible = true;
        }

        private void AutoGenerate_Button_Click(object sender, EventArgs e)
        {
            ClearFirst_Button_Click(sender, e);
            ClearSecond_Button_Click(sender, e);
            Random rnd = new Random();
            int characterIndex = 0;

            while (FirstTeam_ListBox.Items.Count < 6)
            {
                numberTeam = 1;
                match.AddCharacter(character, numberTeam);
                characterIndex = rnd.Next(0, SavedCharactersBox.Items.Count);
                FirstTeam_ListBox.Items.Add(SavedCharactersBox.Items[characterIndex]);
                SavedCharactersBox.Items.Remove(SavedCharactersBox.Items[characterIndex]);
            }

            while (SecondTeam_ListBox.Items.Count < 6)
            {
                numberTeam = 2;
                match.AddCharacter(character, numberTeam);
                characterIndex = rnd.Next(0, SavedCharactersBox.Items.Count);
                SecondTeam_ListBox.Items.Add(SavedCharactersBox.Items[characterIndex]);
                SavedCharactersBox.Items.Remove(SavedCharactersBox.Items[characterIndex]);
            }

            Balance();
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

        public void Balance()
        {
            if (match.Balance())
            {
                Balance_Text.Text = "Balance";
            }
            else
            {
                Balance_Text.Text = "X";
            }
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

        }

        private void HoldMatch_Button_Click(object sender, EventArgs e)
        {
            Match_ListBox.Items.Clear();
            //GetNumberMatch();
            if (Match_ListBox.Items.Count > 0)
            {
                Match_ListBox.Items.Add(MatchNumber.Value);
            }
            ListUpdate();
            DataBase.AddMatchToDataBase(match);
        }

        private void MatchNumber_ValueChanged(object sender, EventArgs e)
        {

        }



        /*public void GetNumberMatch()
        {
            for (int i = 0; i < Match_ListBox.Items.Count; i++)
            {
                if (int.Parse(Match_ListBox.Items[i].ToString()) > min)
                {
                    min = int.Parse(Match_ListBox.Items[i].ToString());
                    match.NumberMatch = min;
                }
            }
        }*/
    }
}
