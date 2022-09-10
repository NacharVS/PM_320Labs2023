using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Core.Enums
{
    public class RogueStatBoundary : BaseStatBoundary
    {
        public new int MinStrength = 15;
        public new int MaxStrength = 55;
        public new int MinDexterity = 30;
        public new int MaxDexterity = 250;
        public new int MinConstitution = 20;
        public new int MaxConstitution = 80;
        public new int MaxIntelligence = 15;
        public new int MinIntelligence = 70;

    }
}
