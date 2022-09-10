using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Core.Enums
{
    public class WarriorStatBoundary : BaseStatBoundary
    {
        public new int MinStrength = 30;
        public new int MaxStrength = 250;
        public new int MinDexterity = 15;
        public new int MaxDexterity = 70;
        public new int MinConstitution = 20;
        public new int MaxConstitution = 100;
        public new int MaxIntelligence = 10;
        public new int MinIntelligence = 50;
    }
}
