﻿using Microsoft.Win32;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CreateCharacterWarcraftWpf
{
    public partial class MainWindow : Window
    {
        CharaterInfo newInfo = new CharaterInfo(1);
        char[] delimiterChars = { ' ', '/' };
        string[] ability = { "Create fog", "Create snow", "Acceleration", "Night vision",
            "Ghost mode", "Resurrection"};
        List<string> activeAbility = new List<string>();
        int levelUp = 1000;
        int expUp = 0;
        List<string> inventory = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            BsonClassMap.RegisterClassMap<Warrior>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Wizard>();

            btnCng.Visibility = Visibility.Hidden;
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
            lstBoxInventory.Items.Clear();
            ClearAbility(activeAbility);
            Character unit;
            if (cmBxChooseCharacter.SelectedIndex == 0)
            {
                unit = new Warrior("", 25, 0, 25, 15, 777, 30, 250, 15, 70, 20, 100, 10, 50, 0, 1, activeAbility, inventory);
                pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Warrior.gif"));
                WriteInfo(unit);

            }
            else if (cmBxChooseCharacter.SelectedIndex == 1)
            {
                unit = new Rogue("", 20, 5, 15, 20, 888, 15, 55, 30, 250, 20, 80, 15, 70, 0, 1, activeAbility, inventory);
                pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Rogue.gif"));
                WriteInfo(unit);
            }
            else if (cmBxChooseCharacter.SelectedIndex == 2)
            {
                unit = new Wizard("", 30, 25, 30, 5, 666, 10, 45, 20, 70, 15, 60, 35, 250, 0, 1, activeAbility, inventory);
                pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Wizard.gif"));
                WriteInfo(unit);
            }
        }

        private void ClearAbility(List<string> activeAbility)
        {
            activeAbility.Clear();
        }

        public void WriteInfo(Character unit)
        {
            tbUntName.Text = unit.name;
            tbHpInfo.Text = Convert.ToString(unit.healthPoint);
            tbMpInfo.Text = Convert.ToString(unit.manaPoint);
            tbApInfo.Text = Convert.ToString(unit.attack);
            tbSpInfo.Text = Convert.ToString(unit.skillPoint);
            tbPrDetInfo.Text = Convert.ToString(unit.protDet);
            tbExpInfo.Text = Convert.ToString(unit.experience);
            tbLvlInfo.Text = Convert.ToString(unit.level);

            tbStrInfo.Text = Convert.ToString(unit.strength) + " / " + Convert.ToString(unit.strengthMax);
            tbDexInfo.Text = Convert.ToString(unit.dexterity) + " / " + Convert.ToString(unit.strengthMax);
            tbConInfo.Text = Convert.ToString(unit.constitution) + " / " + Convert.ToString(unit.constitutionMax);
            tbIntInfo.Text = Convert.ToString(unit.intelligence) + " / " + Convert.ToString(unit.intelligenceMax);

            tbExpInfo.Text = Convert.ToString(unit.experience);
            tbLvlInfo.Text = Convert.ToString(unit.level);

           foreach(var item in unit.inventory)
            {
                lstBoxInventory.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbUntName.Text == "")
            {
                MessageBox.Show("Write name");
            }
            else if (newInfo.CheckName(tbUntName.Text))
            {
                tbUntName.Clear();
                MessageBox.Show("Name is using. Please rename");
            }
            else
            {
                Character unit;
                if (cmBxChooseCharacter.SelectedIndex == 0)
                {
                    unit = new Warrior(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 250, takeNum(tbDexInfo.Text),
                        70, takeNum(tbConInfo.Text), 100, takeNum(tbIntInfo.Text), 50, takeNum(tbExpInfo.Text), takeNum(tbLvlInfo.Text), activeAbility, inventory);
                    newInfo.Add(unit);
                    Mongo.AddToDataBase(unit);
                    FillListBox();
                }
                else if (cmBxChooseCharacter.SelectedIndex == 1)
                {
                    unit = new Rogue(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 55, takeNum(tbDexInfo.Text),
                        250, takeNum(tbConInfo.Text), 80, takeNum(tbIntInfo.Text), 70, takeNum(tbExpInfo.Text), takeNum(tbLvlInfo.Text), activeAbility, inventory);
                    newInfo.Add(unit);
                    Mongo.AddToDataBase(unit);
                    FillListBox();
                }
                else if (cmBxChooseCharacter.SelectedIndex == 2)
                {
                    unit = new Wizard(tbUntName.Text, convInt(tbHpInfo.Text), convInt(tbMpInfo.Text), convInt(tbApInfo.Text),
                        convDbl(tbPrDetInfo.Text), convInt(tbSpInfo.Text), takeNum(tbStrInfo.Text), 45, takeNum(tbDexInfo.Text),
                        70, takeNum(tbConInfo.Text), 60, takeNum(tbIntInfo.Text), 250, takeNum(tbExpInfo.Text), takeNum(tbLvlInfo.Text), activeAbility, inventory);
                    newInfo.Add(unit);
                    Mongo.AddToDataBase(unit);
                    FillListBox();
                }
                levelUp = 1000;
                expUp = 0;
                inventory.Clear();
                lstBoxInventory.Items.Clear();
            }

            ClearAbility(activeAbility);
        }

        private void btnExp_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tbExpInfo.Text) < 21000)
            {
                tbExpInfo.Text = Convert.ToString(Convert.ToInt32(tbExpInfo.Text) + 500);

                if (expUp + levelUp == Convert.ToInt32(tbExpInfo.Text))
                {
                    tbLvlInfo.Text = Convert.ToString(Convert.ToInt32(tbLvlInfo.Text) + 1);
                    levelUp = levelUp + 1000;
                    expUp = Convert.ToInt32(tbExpInfo.Text);
                    activeAbility.Add(ability[Convert.ToInt32(tbLvlInfo.Text) - 2]);
                }
            }
        }

        private void btnSkill_Click(object sender, RoutedEventArgs e)
        {
            string line = "";
            for(int i = 0; i + 1 < Convert.ToInt32(tbLvlInfo.Text); i++)
            {
                line = line + ability[i] + "\n";
            }
            MessageBox.Show(line);
        }

        private void lstBoxCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBoxCharacters.Items.Count != 0)
            {
                var unit = TakeUnit(lstBoxCharacters.SelectedValue.ToString());

                if (cmBxChooseCharacter.SelectedIndex == 0)
                {
                    pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Warrior.gif"));

                }
                else if (cmBxChooseCharacter.SelectedIndex == 1)
                {
                    pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Rogue.gif"));
                }
                else if (unit.ToString() == "")
                {
                    pbCharacter.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Images/Wizard.gif"));
                }
                MessageBox.Show(unit.ToString());
                btnAdd.Visibility = Visibility.Hidden;
                btnCng.Visibility = Visibility.Visible;

                WriteInfo(unit);
                tbUntName.Text = unit.name;
                string type = Convert.ToString(unit.GetType()).Substring(27);
                cmBxChooseCharacter.Text = type;
            }
        }

        private string takeTypeCharacter(Type type)
        {
            return Convert.ToString(type).Substring(21);
        }

        private Character TakeUnit(string? name)
        {
            Character unit = new Character("", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, activeAbility, inventory);

            var collection = Mongo.GetCollection();

            var filter = new BsonDocument();
            var collect = collection.Find(filter).ToList();
            for(int i = 0; i < collect.Count; i++)
            {
                if (collect[i].name == name)
                {
                    unit = collect[i];
                }
            }

            return unit;
        }

        private void btnCng_Click(object sender, RoutedEventArgs e)
        {
            lstBoxInventory.Items.Clear();

            Character unit = Mongo.TakeUnit(lstBoxCharacters.SelectedValue.ToString());

            tbUntName.Text = unit.name;
            unit.intelligence = takeNum(tbIntInfo.Text);
            unit.healthPoint = takeNum(tbIntInfo.Text);
            unit.manaPoint = takeNum(tbMpInfo.Text);
            unit.attack = takeNum(tbApInfo.Text);
            unit.protDet = takeNum(tbPrDetInfo.Text);
            unit.skillPoint = takeNum(tbSpInfo.Text);
            unit.skillPoint = convInt(tbSpInfo.Text);
            unit.strength = takeNum(tbStrInfo.Text);
            unit.dexterity = takeNum(tbDexInfo.Text);
            unit.constitution = takeNum(tbConInfo.Text);
            unit.experience = takeNum(tbExpInfo.Text);
            unit.level = takeNum(tbLvlInfo.Text);
            unit.activeAbility = activeAbility;
            unit.inventory = unit.inventory.Concat(inventory).ToList();

            Mongo.ReplaceByName(unit.name, unit);
            FillListBox();

            levelUp = 1000;
            expUp = 0;
            inventory.Clear();

            btnAdd.Visibility = Visibility.Visible;
            btnCng.Visibility = Visibility.Hidden;

            ClearAbility(activeAbility);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillListBox();
        }

        private void FillListBox()
        {
            lstBoxCharacters.Items.Clear();

            var collection = Mongo.GetCollection();

            var filter = new BsonDocument();
            var collect = collection.Find(filter);
            foreach (var doc in collect.ToList())
            {
                lstBoxCharacters.Items.Add(doc.name);
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            inventory.Add(tbTitleItem.Text);
            lstBoxInventory.Items.Add(tbTitleItem.Text);
        }
    }
}
