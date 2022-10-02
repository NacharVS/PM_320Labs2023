// Turushkin Sergey, 320P, "EditUnit"

namespace Units_Practic.Characters
{
    public class Rogue : Unit
    {
        public Rogue()
        {
            characteristics = new Characteristics(Units.Rogue);
            UpdateHaracteristics();
        }
    }
}
