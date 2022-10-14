using CharacterEditorCore.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.DataBase
{
    public interface IMatchRep
    {
        public bool SaveMatch(MatchInfo match);
        public MatchInfo GetMatch(string Id);
    }
}
