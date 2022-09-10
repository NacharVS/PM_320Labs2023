using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Core.Enums
{
    public class WizardStatBoundary : BaseStatBoundary
    {
        public new int MinStrength = 10;
        public new int MaxStrength = 45;
        public new int MinDexterity = 20;
        public new int MaxDexterity = 70;
        public new int MinConstitution = 15;
        public new int MaxConstitution = 60;
        public new int MaxIntelligence = 35;
        public new int MinIntelligence = 250;
    }
}
