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
        private Character character;
        private List<Character> characters = new List<Character>();
        public MatchCreator()
        {
            InitializeComponent();
            ListUpdate();
        }

        private void ListUpdate()
        {
            var collection = DataBase.ImportData();

            foreach (var c in collection)
            {
                SavedCharactersBox.Items.Add(c.Name);
            }
        }

        private void SavedCharactersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CustomTeam_Button_Click(object sender, EventArgs e)
        {
            Hide();
            Display();
            Choos_Label.Visible = true;
            SavedCharactersBox.Enabled = true;
        }

       /* public void CreateList()
        {
            foreach (var character in SavedCharactersBox.Items)
            {
                characters.Add(character);
            }
        }*/

        private void AutoTeam_Button_Click(object sender, EventArgs e)
        {
            Hide();
            Display();
           /* Random rnd = new Random();
            int characterIndex = rnd.Next(0, SavedCharactersBox.Items.Count);
            character = SavedCharactersBox.Items.Skip(characterIndex).First();

            while (FirstTeam_ListBox.Items.Count < 6)
            {
                FirstTeam_ListBox.Items.Add(match.FirstTeam[characterIndex]);
            }*/
        }

        /*public void CustomTeam()
        {
            while (FirstTeam_ListBox.Items.Count < 6)
            {
                FirstTeam_ListBox.Items = SavedCharactersBox.SelectedItems;
            }
        }*/

        public void Hide()
        {
            TeamType_Label.Visible = false;
            CustomTeam_Button.Visible = false;
            AutoTeam_Button.Visible = false;
        }

        public void Display()
        {
            FirstTeam_ListBox.Visible = true;
            FirstTeam_Label.Visible = true;
            SecondTeam_ListBox.Visible = true;
            SecondTeam_Label.Visible = true;
            Generate_Button.Visible = true; 
        }
    }
}
