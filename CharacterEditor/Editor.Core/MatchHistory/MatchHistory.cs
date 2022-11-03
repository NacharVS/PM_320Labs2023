using Editor.Core.Characters.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Core.MatchHistory
{
    public class MatchHistory : IHaveName
    {
        public string Name { get; set; }
        public string[] Teams { get; set; }
        public MatchPlayerRecord[] PlayerRecords { get; set; }
        public DateTime Date { get; set; }
    }
}
