using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace CreateCharacterWarcraftWpf
{
    public class CharaterInfo
    {
        private int idCharaterinfo;
        public static List<Character> character = new List<Character>();
        public char[] delimiterChars = { ' ', '/', ':', ',' };

        public CharaterInfo(int idCharaterinfo)
        {
            this.idCharaterinfo = idCharaterinfo;
        }

        public void getInfo(TextBox tbInfo)
        {
            foreach (Character c in character)
            {
                tbInfo.Text += (c.getInfo() + Environment.NewLine);
            }
        }
        internal void Add(Character unit)
        {
            character.Add(unit);
        }

        public void clearInfo()
        {
            character.Clear();
        }

        public List<Character> returnList()
        {
            return character;
        }

        public void loadFile(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                string s;
                string[] data;
                while ((s = reader.ReadLine()) != null)
                {
                    Character unit;
                    data = s.Split(delimiterChars);
                    switch (data[6])
                    {
                        case "Warrior":
                            unit = new Warrior(data[2],
                                int.Parse(data[10]), int.Parse(data[14]),
                                int.Parse(data[18]), double.Parse(data[22]),
                                int.Parse(data[26]), int.Parse(data[30]),
                                250, int.Parse(data[34]),
                                70, int.Parse(data[38]),
                                100, int.Parse(data[42]), 50, 0, 1);
                            character.Add(unit);
                            break;
                        case "Rogue":

                            unit = new Rogue(data[2],
                                int.Parse(data[10]), int.Parse(data[14]),
                                int.Parse(data[18]), double.Parse(data[22]),
                                int.Parse(data[26]), int.Parse(data[30]),
                                55, int.Parse(data[34]),
                                250, int.Parse(data[38]),
                                80, int.Parse(data[42]), 70, 0, 1);
                            character.Add(unit);

                            break;
                        case "Wizard":

                            unit = new Wizard(data[2],
                                int.Parse(data[10]), int.Parse(data[14]),
                                int.Parse(data[18]), double.Parse(data[22]),
                                int.Parse(data[26]), int.Parse(data[30]),
                                45, int.Parse(data[34]),
                                70, int.Parse(data[38]),
                                60, int.Parse(data[42]), 250, 0, 1);
                            character.Add(unit);

                            break;
                        default:
                            break;
                    }
                }
            }

        }

        internal bool CheckName(string name)
        {
            if (character.Count != 0)
            {
                for (int i = 0; i < character.Count; i++)
                {
                    if (character[i].name == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Character TakeUnit(string name)
        {
            Character unit = new Character("",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
            for (int i = 0; i < character.Count; i++)
            {
                if (character[i].name == name)
                {
                    unit = character[i];
                }
            }
            return unit;
        }

        public void Change(Character unit, string name)
        {
            for (int i = 0; i < character.Count; i++)
            {
                if (character[i].name == name)
                {
                    character[i] = null;
                    character[i] = unit;
                }
            }
        }

        public List<string> returnListName()
        {
            List<string> listName = new List<string>();
            for (int i = 0; i < character.Count; i++)
            {
                listName.Add(character[i].name);
            }
            return listName; 
        }
    }
}