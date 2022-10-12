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
            Choos_Label.Visible = true;
            SavedCharactersBox.Enabled = true;
        }

        private void AutoTeam_Button_Click(object sender, EventArgs e)
        {
            Hide();
            Random rnd = new Random();
            int characterIndex = rnd.Next();

            if (match.FirstTeam.Count <= 6)
            {

            }
        }

        public void Hide()
        {
            TeamType_Label.Visible = false;
            CustomTeam_Button.Visible = false;
            AutoTeam_Button.Visible = false;
        }
    }
}
