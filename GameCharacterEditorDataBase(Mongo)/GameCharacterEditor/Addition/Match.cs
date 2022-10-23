using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace GameCharacterEditor
{
    class Match
    {
        /*public List<ObjectId> FirstTeam { get; set; } = new List<ObjectId> ();
        public List<ObjectId> SecondTeam { get; set; } = new List<ObjectId> ();*/
        
        public ObjectId Id;
        /*public List<Character> FirstTeam { get; set; } = new List<Character>();
        public List<Character> SecondTeam { get; set; } = new List<Character>();*/
        public List<string> FirstTeam { get; set; } = new List<string>();
        public List<string> SecondTeam { get; set; } = new List<string>();
        public int NumberMatch { get; set; }
        public DateTime Time { get; set; }


        /*public bool Balance()
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

            int balanceOne = lvlFirstTeam / FirstTeam.Count;
            int balanceTwo = lvlSecondTeam / SecondTeam.Count;    

            return Math.Abs(balanceOne - balanceTwo) < 2;
        }*/
    }
}
