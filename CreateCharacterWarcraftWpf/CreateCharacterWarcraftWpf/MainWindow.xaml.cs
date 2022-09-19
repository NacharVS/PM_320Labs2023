﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using static System.Net.Mime.MediaTypeNames;

namespace CreateCharacterWarcraftWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CharaterInfo newInfo = new CharaterInfo(1);
        char[] delimiterChars = { ' ', '/' };

        //Image Rogue = Image.FromFile("Rogue.gif");
        //Image Wizard = Image.FromFile("Wizard.gif");
        //Image Warrior = Image.FromFile("Warrior.gif");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pbAvatar.ImageLocation = "https://www.digiseller.ru/preview/887475/p1_3326088_78b1003d.gif";

        }

        public void tbUntName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbUntName.Text == "")
            {
                MessageBox.Show("WriteName");
                cmBxChooseCharacter.Text = ("Warrior");
            }
            else
            {
                Character unit;
                if (cmBxChooseCharacter.SelectedIndex == 0)
                {
                    unit = new Warrior(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 250, takeNum(tbDexInfo.Text),
                        70, takeNum(tbConInfo.Text), 100, takeNum(tbIntInfo.Text), 50);
                    newInfo.Add(unit);
                    tbInfo.Text += ("Add: " + unit.getInfo() + Environment.NewLine);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 1)
                {
                    unit = new Rogue(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 55, takeNum(tbDexInfo.Text),
                        250, takeNum(tbConInfo.Text), 80, takeNum(tbIntInfo.Text), 70);
                    newInfo.Add(unit);
                    tbInfo.Text += ("Add: " + unit.getInfo() + Environment.NewLine);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 2)
                {
                    unit = new Wizard(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 45, takeNum(tbDexInfo.Text),
                        70, takeNum(tbConInfo.Text), 60, takeNum(tbIntInfo.Text), 250);
                    newInfo.Add(unit);
                    tbInfo.Text += ("Add: " + unit.getInfo() + Environment.NewLine);
                }
            }
        }

        public int convInt(string num)
        {
            return Convert.ToInt32(num);
        }
        public double convDbl(string num)
        {
            return Convert.ToDouble(num);
        }

        public int takeNum(string line)
        {
            var lineNum = line.Split(delimiterChars);
            return convInt(lineNum[0]);
        }

        private void btnDex_Click(object sender, RoutedEventArgs e)
        {
            var str = tbDexInfo.Text.Split(delimiterChars);
            if (str[0] != str[3])
            {
                tbDexInfo.Text = Convert.ToString(Convert.ToInt32(str[0]) + 5) + " / " + str[3];
                tbSpInfo.Text = Convert.ToString(Convert.ToInt32(tbSpInfo.Text) - 1);
                if (cmBxChooseCharacter.SelectedIndex == 0)
                {
                    tbApInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 1);
                    tbPrDetInfo.Text = Convert.ToString(Convert.ToInt32(tbHpInfo.Text) + 1);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 1)
                {
                    tbApInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 4);
                    tbPrDetInfo.Text = Convert.ToString(Convert.ToInt32(tbHpInfo.Text) + 1);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 2)
                {
                    tbPrDetInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 1);
                }
            }
        }

        private void btnStr_Click(object sender, RoutedEventArgs e)
        {
            var str = tbStrInfo.Text.Split(delimiterChars);
            if (str[0] != str[3])
            {
                tbStrInfo.Text = Convert.ToString(Convert.ToInt32(str[0]) + 5) + " / " + str[3];
                tbSpInfo.Text = Convert.ToString(Convert.ToInt32(tbSpInfo.Text) - 1);
                if (cmBxChooseCharacter.SelectedIndex == 0)
                {
                    tbApInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 5);
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbHpInfo.Text) + 2);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 1)
                {
                    tbApInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 2);
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbHpInfo.Text) + 1);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 2)
                {
                    tbApInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 2);
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbHpInfo.Text) + 1);
                }
            }
        }

        private void btnCon_Click(object sender, RoutedEventArgs e)
        {
            var str = tbConInfo.Text.Split(delimiterChars);
            if (str[0] != str[3])
            {
                tbConInfo.Text = Convert.ToString(Convert.ToInt32(str[0]) + 5) + " / " + str[3];
                tbSpInfo.Text = Convert.ToString(Convert.ToInt32(tbSpInfo.Text) - 1);
                if (cmBxChooseCharacter.SelectedIndex == 0)
                {
                    tbPrDetInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 2);
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbHpInfo.Text) + 10);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 1)
                {
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 6);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 2)
                {
                    tbPrDetInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 1);
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 3);
                }
            }
        }

        private void btnInt_Click(object sender, RoutedEventArgs e)
        {
            var str = tbIntInfo.Text.Split(delimiterChars);
            if (str[0] != str[3])
            {
                tbIntInfo.Text = Convert.ToString(Convert.ToInt32(str[0]) + 5) + " / " + str[3];
                tbSpInfo.Text = Convert.ToString(Convert.ToInt32(tbSpInfo.Text) - 1);
                if (cmBxChooseCharacter.SelectedIndex == 0)
                {
                    tbMpInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 1);
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbHpInfo.Text) + 1);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 1)
                {
                    tbMpInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 2);
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbHpInfo.Text) + 2);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 2)
                {
                    tbMpInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 2);
                    tbHpInfo.Text = Convert.ToString(Convert.ToInt32(tbApInfo.Text) + 5);
                }
            }
        }

        private void cmBxChooseCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character unit;
            if (cmBxChooseCharacter.SelectedIndex == 0)
            {
                unit = new Warrior("", 25, 0, 25, 15, 777, 30, 250, 15, 70, 20, 100, 10, 50);
                pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Warrior.gif"));
                writeInfo(unit);

            }
            else if (cmBxChooseCharacter.SelectedIndex == 1)
            {
                unit = new Rogue("", 20, 5, 15, 20, 888, 15, 55, 30, 250, 20, 80, 15, 70);
                pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Rogue.gif"));
                writeInfo(unit);
            }
            else if (cmBxChooseCharacter.SelectedIndex == 2)
            {
                unit = new Wizard("", 30, 25, 30, 5, 666, 10, 45, 20, 70, 15, 60, 35, 250);
                pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Wizard.gif"));
                writeInfo(unit);
            }
        }
        public void writeInfo(Character unit)
        {
            tbHpInfo.Text = Convert.ToString(unit.healthPoint);
            tbMpInfo.Text = Convert.ToString(unit.manaPoint);
            tbApInfo.Text = Convert.ToString(unit.attack);
            tbSpInfo.Text = Convert.ToString(unit.skillPoint);
            tbPrDetInfo.Text = Convert.ToString(unit.protDet);

            tbStrInfo.Text = Convert.ToString(unit.strength) + " / " + Convert.ToString(unit.strengthMax);

            tbDexInfo.Text = Convert.ToString(unit.dexterity) + " / " + Convert.ToString(unit.strengthMax);

            tbConInfo.Text = Convert.ToString(unit.constitution) + " / " + Convert.ToString(unit.constitutionMax);

            tbIntInfo.Text = Convert.ToString(unit.intelligence) + " / " + Convert.ToString(unit.intelligenceMax);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, tbInfo.Text);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                tbInfo.Text = File.ReadAllText(openFileDialog.FileName);
            loadCharaters(openFileDialog.FileName);
            MessageBox.Show("Файл открыт");
        }
        public void loadCharaters(string filename)
        {
            newInfo.clearInfo();
            newInfo.loadFile(filename);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbUntName.Text == "")
            {
                MessageBox.Show("Write name");
            }
            else
            {
                Character unit;
                if (cmBxChooseCharacter.SelectedIndex == 0)
                {
                    unit = new Warrior(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 250, takeNum(tbDexInfo.Text),
                        70, takeNum(tbConInfo.Text), 100, takeNum(tbIntInfo.Text), 50);
                    newInfo.Add(unit);
                    tbInfo.Text += ("Add: " + unit.getInfo() + Environment.NewLine);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 1)
                {
                    unit = new Rogue(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 55, takeNum(tbDexInfo.Text),
                        250, takeNum(tbConInfo.Text), 80, takeNum(tbIntInfo.Text), 70);
                    newInfo.Add(unit);
                    tbInfo.Text += ("Add: " + unit.getInfo() + Environment.NewLine);
                }
                else if (cmBxChooseCharacter.SelectedIndex == 2)
                {
                    unit = new Wizard(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 45, takeNum(tbDexInfo.Text),
                        70, takeNum(tbConInfo.Text), 60, takeNum(tbIntInfo.Text), 250);
                    newInfo.Add(unit);
                    tbInfo.Text += ("Add: " + unit.getInfo() + Environment.NewLine);
                }
            }
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            newInfo.getInfo(tbInfo);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbInfo.Clear();
        }
    }
}
