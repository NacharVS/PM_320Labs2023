// Turushkin Sergey, 320P, "EditUnit"

namespace Units_Practic.Characters
{
    public class Warrior : Unit
    {
        public Warrior()
        {
            characteristics = new Characteristics(Units.Warrior);
            UpdateHaracteristics();
        }
    }
}
