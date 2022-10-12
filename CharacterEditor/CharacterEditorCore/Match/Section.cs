using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Match
{
    internal class Section
    {
        public int SectionStartIndex { get; set; }
        public int SectionEndIndex { get; set; }
        public int Count => SectionEndIndex - SectionStartIndex;
    }
}
