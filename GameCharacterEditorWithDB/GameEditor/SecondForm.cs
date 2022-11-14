﻿using System;
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
            List<Match> list = DBConnection.ImportAllMatchData();
            foreach (Match match in list)
            {
                listBoxOfMatches.Items.Add(match.number);
            }
            AddToolStrips();
            startBtn.Visible = false;
        }

        private void AddToolStrips()
        {
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
        }

        void SecondMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxTeamTwo.Items.Count < 6)
            {
                listBoxTeamTwo.Items.Add(listBoxOfUnits.SelectedItem.ToString());
                SecondTeamChangedEvent();
            }
        }

        void FirstMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxTeamOne.Items.Count < 6)
            {
                listBoxTeamOne.Items.Add(listBoxOfUnits.SelectedItem.ToString());
                FirstTeamChangedEvent();
            }
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
            listBoxOfUnits.SelectedIndex = -1;
            if (!(listBoxOfMatches.SelectedItems.Count > 0))
            {
                listBoxOfUnits.Items.Add(listBoxTeamOne.SelectedItem.ToString());
                listBoxTeamOne.Items.Remove(listBoxTeamOne.SelectedItem);
                FirstTeamChangedEvent();
            }
        }

        void RemoveTwoMenuItem_Click(object sender, EventArgs e)
        {
            listBoxOfUnits.SelectedIndex = -1;
            if (!(listBoxOfMatches.SelectedItems.Count > 0))
            {
                listBoxOfUnits.Items.Add(listBoxTeamTwo.SelectedItem.ToString());
                listBoxTeamTwo.Items.Remove(listBoxTeamTwo.SelectedItem);
                SecondTeamChangedEvent();
            }
        }

        void FirstTeamChangedEvent()
        {
            if (listBoxTeamOne.Items.Count > 0 && listBoxTeamOne.Items.Count < 7)
            {
                int lvls = 0;
                double count = 0;

                foreach (var i in listBoxTeamOne.Items)
                {
                    lvls += DBConnection.FindByName(i.ToString()).Level;
                    count++;
                }

                textBoxOne.Text = ((double)(lvls / count)).ToString();
                listBoxOfUnits.Items.Remove(listBoxOfUnits.SelectedItem);
            }
            else if (listBoxTeamOne.Items.Count == 0)
            {
                textBoxOne.Text = "";
            }
            if (listBoxTeamOne.Items.Count != 6 || listBoxTeamTwo.Items.Count != 6)
            {
                startBtn.Visible = false;
            }
            else if (Math.Abs(Convert.ToDouble(textBoxOne.Text) - Convert.ToDouble(textBoxTwo.Text)) < 2)
            {
                startBtn.Visible = true;
            }
        }

        void SecondTeamChangedEvent()
        {
            if (listBoxTeamTwo.Items.Count > 0 && listBoxTeamTwo.Items.Count < 7)
            {
                int lvls = 0;
                double count = 0;

                foreach (var i in listBoxTeamTwo.Items)
                {
                    lvls += DBConnection.FindByName(i.ToString()).Level;
                    count++;
                }

                textBoxTwo.Text = ((double)(lvls / count)).ToString();
                listBoxOfUnits.Items.Remove(listBoxOfUnits.SelectedItem);
            }
            else if (listBoxTeamTwo.Items.Count == 0)
            {
                textBoxTwo.Text = "";
            }
            if (listBoxTeamOne.Items.Count != 6 || listBoxTeamTwo.Items.Count != 6)
            {
                startBtn.Visible = false;
            }
            else if (Math.Abs(Convert.ToDouble(textBoxOne.Text) - Convert.ToDouble(textBoxTwo.Text)) < 2)
            {
                startBtn.Visible = true;
            }
        }

        private void TextBoxOne_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOne.Text != "" && textBoxTwo.Text != "" && Math.Abs(Convert.ToDouble(textBoxOne.Text) - Convert.ToDouble(textBoxTwo.Text)) < 2)
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
            if (textBoxOne.Text != "" && textBoxTwo.Text != "" && Math.Abs(Convert.ToDouble(textBoxOne.Text) - Convert.ToDouble(textBoxTwo.Text)) < 2)
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
            if (DBConnection.ImportMatchData(Convert.ToInt32(textBoxNumberMatch.Text)) is null)
            {
                match = new Match(textBoxNumberMatch.Text);
                foreach (var i in listBoxTeamOne.Items)
                {
                    match.firstTeam.Add(i.ToString());
                }
                foreach (var i in listBoxTeamTwo.Items)
                {
                    match.secondTeam.Add(i.ToString());
                }
                DBConnection.AddMatchToDataBase(match);
                listBoxOfMatches.Items.Add(match.number);
            }
            else
            {
                MessageBox.Show("Матч с таким номером существует");
            }
        }

        private void AutoBtn_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            while (listBoxTeamOne.Items.Count != 0)
            {
                listBoxOfUnits.Items.Add(listBoxTeamOne.Items[0]);
                listBoxTeamOne.Items.Remove(listBoxTeamOne.Items[0]);
            }
            while (listBoxTeamTwo.Items.Count != 0)
            {
                listBoxOfUnits.Items.Add(listBoxTeamTwo.Items[0]);
                listBoxTeamTwo.Items.Remove(listBoxTeamTwo.Items[0]);
            }

            while (listBoxTeamOne.Items.Count < 6)
            {
                int index = rnd.Next(0, listBoxOfUnits.Items.Count);
                listBoxTeamOne.Items.Add(listBoxOfUnits.Items[index]);
                FirstTeamChangedEvent();
                listBoxOfUnits.Items.Remove(listBoxOfUnits.Items[index]);
            }
            while (listBoxTeamTwo.Items.Count < 6)
            {
                int indexTwo = rnd.Next(0, listBoxOfUnits.Items.Count);
                listBoxTeamTwo.Items.Add(listBoxOfUnits.Items[indexTwo]);
                SecondTeamChangedEvent();
                listBoxOfUnits.Items.Remove(listBoxOfUnits.Items[indexTwo]);
            }
            if (!(Math.Abs(Convert.ToDouble(textBoxOne.Text) - Convert.ToDouble(textBoxTwo.Text)) < 2))
            {
                DeleteInfo();
                AutoBtn_Click(sender, e);
            }
        }

        private void ListBoxOfMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBoxOfMatches.SelectedItems.Count > 0)
            {
                if (listBoxTeamOne.Items.Count != 0 && listBoxTeamTwo.Items.Count != 0 && textBoxNumberMatch.Text != "")
                {
                    while (listBoxTeamOne.Items.Count != 0)
                    {
                        listBoxTeamOne.Items.Remove(listBoxTeamOne.Items[0]);
                    }
                    while (listBoxTeamTwo.Items.Count != 0)
                    {
                        listBoxTeamTwo.Items.Remove(listBoxTeamTwo.Items[0]);
                    }
                }
                else if ((listBoxTeamOne.Items.Count != 0 || listBoxTeamTwo.Items.Count != 0))
                {
                    while (listBoxTeamOne.Items.Count != 0)
                    {
                        listBoxOfUnits.Items.Add(listBoxTeamOne.Items[0]);
                        listBoxTeamOne.Items.Remove(listBoxTeamOne.Items[0]);
                    }
                    while (listBoxTeamTwo.Items.Count != 0)
                    {
                        listBoxOfUnits.Items.Add(listBoxTeamTwo.Items[0]);
                        listBoxTeamTwo.Items.Remove(listBoxTeamTwo.Items[0]);
                    }
                }
                int number = Convert.ToInt32(listBoxOfMatches.SelectedItem.ToString());
                match = DBConnection.ImportMatchData(number);

                foreach (var i in match.firstTeam)
                {
                    listBoxTeamOne.Items.Add(i.ToString());
                    FirstTeamChangedEvent();
                }
                foreach (var i in match.secondTeam)
                {
                    listBoxTeamTwo.Items.Add(i.ToString());
                    SecondTeamChangedEvent();
                }
                textBoxNumberMatch.Text = match.number.ToString();
                startBtn.Visible = false;
            }
        }

        private void DeleteInfo()
        {
            foreach (var i in listBoxTeamOne.Items)
            {
                listBoxOfUnits.Items.Add(i);
                listBoxTeamOne.Items.Remove(i);
            }
            foreach (var i in listBoxTeamTwo.Items)
            {
                listBoxOfUnits.Items.Add(i);
                listBoxTeamTwo.Items.Remove(i);
            }
            textBoxOne.Text = "";
            textBoxTwo.Text = "";
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (listBoxOfMatches.SelectedItems.Count > 0)
            {
                while (listBoxTeamOne.Items.Count != 0)
                {
                    listBoxTeamOne.Items.Remove(listBoxTeamOne.Items[0]);
                }
                while (listBoxTeamTwo.Items.Count != 0)
                {
                    listBoxTeamTwo.Items.Remove(listBoxTeamTwo.Items[0]);
                }
                textBoxNumberMatch.Text = "";
                textBoxOne.Text = "";
                textBoxTwo.Text = "";
                listBoxOfMatches.SelectedItems.Clear();
            }
            else
            {
                while (listBoxTeamOne.Items.Count != 0)
                {
                    listBoxOfUnits.Items.Add(listBoxTeamOne.Items[0]);
                    listBoxTeamOne.Items.Remove(listBoxTeamOne.Items[0]);
                }
                while (listBoxTeamTwo.Items.Count != 0)
                {
                    listBoxOfUnits.Items.Add(listBoxTeamTwo.Items[0]);
                    listBoxTeamTwo.Items.Remove(listBoxTeamTwo.Items[0]);
                }
                textBoxNumberMatch.Text = "";
                textBoxOne.Text = "";
                textBoxTwo.Text = "";
            }
        }
    }
}