using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items
{
    public interface INecessaryCharacteristics
    {
        public int necessaryStrength { get; init; }
        public int necessaryDexterity { get; init; }
        public int necessaryConstitution { get; init; }
        public int necessaryIntelligence { get; init; }
    }
}
