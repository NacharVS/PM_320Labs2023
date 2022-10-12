using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditorLibrary;

namespace GameEditor
{
    public partial class SecondForm : Form
    {
        Match match;

        public SecondForm()
        {
            InitializeComponent();
        }

        public SecondForm(Main mainFrm, ListBox listBox)
        {
            InitializeComponent();
            foreach (var i in listBox.Items)
            {
                listBoxOfUnits.Items.Add(i);
            }
            ToolStripMenuItem firstMenuItem = new ToolStripMenuItem("Добавить в первую команду");
            ToolStripMenuItem secondMenuItem = new ToolStripMenuItem("Добавить во вторую команду");
            ToolStripMenuItem removeOneMenuItem = new ToolStripMenuItem("Удалить из первой команды");
            ToolStripMenuItem removeTwoMenuItem = new ToolStripMenuItem("Удалить из второй команды");
            ToolStripMenuItem openUnitMenuItem = new ToolStripMenuItem("Просмотреть персонажа");
            ToolStripMenuItem openUnitTwoMenuItem = new ToolStripMenuItem("Просмотреть персонажа");
            contextMenuStrip1.Items.AddRange(new[] { firstMenuItem, secondMenuItem });
            contextMenuStripTwo.Items.AddRange(new[] { removeOneMenuItem, openUnitTwoMenuItem });
            contextMenuStripTw.Items.AddRange(new[] { removeTwoMenuItem, openUnitMenuItem });
            listBoxOfUnits.ContextMenuStrip = contextMenuStrip1;
            listBoxTeamOne.ContextMenuStrip = contextMenuStripTwo;
            listBoxTeamTwo.ContextMenuStrip = contextMenuStripTw;
            firstMenuItem.Click += FirstMenuItem_Click;
            secondMenuItem.Click += SecondMenuItem_Click;
            removeOneMenuItem.Click += RemoveOneMenuItem_Click;
            removeTwoMenuItem.Click += RemoveTwoMenuItem_Click;
            openUnitMenuItem.Click += OpenUnitMenuItem_Click;
            openUnitTwoMenuItem.Click += OpenUnitMenuItem_Click;
            startBtn.Visible = false;

        }

        void SecondMenuItem_Click(object sender, EventArgs e)
        {
            listBoxTeamTwo.Items.Add(listBoxOfUnits.SelectedItem.ToString());
            SecondTeamChangedEvent();
        }

        void FirstMenuItem_Click(object sender, EventArgs e)
        {
            listBoxTeamOne.Items.Add(listBoxOfUnits.SelectedItem.ToString());
            FirstTeamChangedEvent();
        }

        void OpenUnitMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxTeamOne.SelectedItems.Count > 0)
            {
                Main mainFrm = new Main(listBoxTeamOne.SelectedItem.ToString());
                mainFrm.Show();
            }
            else
            {
                Main mainFrm = new Main(listBoxTeamTwo.SelectedItem.ToString());
                mainFrm.Show();
            }
        }

        void RemoveOneMenuItem_Click(object sender, EventArgs e)
        {
            listBoxOfUnits.Items.Add(listBoxTeamOne.SelectedItem.ToString());
            listBoxTeamOne.Items.Remove(listBoxTeamOne.SelectedItem);
            FirstTeamChangedEvent();
        }

        void RemoveTwoMenuItem_Click(object sender, EventArgs e)
        {
            listBoxOfUnits.Items.Add(listBoxTeamTwo.SelectedItem.ToString());
            listBoxTeamTwo.Items.Remove(listBoxTeamTwo.SelectedItem);
            SecondTeamChangedEvent();
        }

        void FirstTeamChangedEvent()
        {
            if (listBoxTeamOne.Items.Count > 0 && listBoxTeamOne.Items.Count < 7)
            {
                int lvls = 0;
                int count = 0;

                foreach (var i in listBoxTeamOne.Items)
                {
                    lvls += DBConnection.FindByName(i.ToString()).Level;
                    count++;
                }

                textBoxOne.Text = (lvls / count).ToString();
                listBoxOfUnits.Items.Remove(listBoxOfUnits.SelectedItem);
            }
            else if (listBoxTeamOne.Items.Count == 0)
            {
                textBoxOne.Text = "";
            }
        }

        void SecondTeamChangedEvent()
        {
            if (listBoxTeamTwo.Items.Count > 0 && listBoxTeamTwo.Items.Count < 7)
            {
                int lvls = 0;
                int count = 0;

                foreach (var i in listBoxTeamTwo.Items)
                {
                    lvls += DBConnection.FindByName(i.ToString()).Level;
                    count++;
                }

                textBoxTwo.Text = (lvls / count).ToString();
                listBoxOfUnits.Items.Remove(listBoxOfUnits.SelectedItem);
            }
            else if (listBoxTeamTwo.Items.Count == 0)
            {
                textBoxTwo.Text = "";
            }
        }

        private void TextBoxOne_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOne.Text != "" && textBoxTwo.Text != "" && Math.Abs(Convert.ToDouble(textBoxOne.Text) - Convert.ToDouble(textBoxTwo.Text)) <= 2)
            {
                startBtn.Visible = true;
            }
            else
            {
                startBtn.Visible = false;
            }
        }

        private void TextBoxTwo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOne.Text != "" && textBoxTwo.Text != "" && Math.Abs(Convert.ToDouble(textBoxOne.Text) - Convert.ToDouble(textBoxTwo.Text)) <= 2)
            {
                startBtn.Visible = true;
            }
            else
            {
                startBtn.Visible = false;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            foreach (var i in listBoxTeamOne.Items)
            {
                match.firstTeam.Add(i.ToString());
            }
            foreach (var i in listBoxTeamTwo.Items)
            {
                match.secondTeam.Add(i.ToString());
            }
            DBConnection.AddMatchToDataBase(match);
        }
    }
}
