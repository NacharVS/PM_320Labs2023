using System;
using System.Collections.Generic;
using System.Data.Common;

namespace CreateCharacterWarcraftWpf
{
    public class TeamMatch
    {
        public List<string> teamOne;
        public List<string> teamTwo;
        public string result;
        public DateTime dateMatch;

        public TeamMatch(List<string> teamOne, List<string> teamTwo, string teamWin, DateTime dateMatch)
        {
            this.teamOne = teamOne;
            this.teamTwo = teamTwo;
            this.result = teamWin;
            this.dateMatch = dateMatch;
        }
    }
}