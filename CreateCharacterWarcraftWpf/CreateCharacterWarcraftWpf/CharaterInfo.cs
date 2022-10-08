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