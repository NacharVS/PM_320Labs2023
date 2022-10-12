using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Match
    {
        public List<Character> FirstTeam { get; set; } = new List<Character> ();
        public List<Character> SecondTeam { get; set; } = new List<Character> ();

        public void  AddCharacter(Character character, int team)
        {
            switch (team)
            {
                case 1:
                    FirstTeam.Add(character);
                    break;
                case 2:
                    SecondTeam.Add(character);
                    break;
            }
        }

        private bool Balance()
        {
            int lvlFirstTeam = 0;
            int lvlSecondTeam = 0;

            foreach (var character in FirstTeam)
            {
                lvlFirstTeam += character.Lvl;
            }

            foreach (var character in SecondTeam)
            {
                lvlSecondTeam += character.Lvl;
            }

            return Math.Abs((lvlFirstTeam - lvlSecondTeam) / 
                (FirstTeam.Count + SecondTeam.Count)) < 2;
        }
    }
}
