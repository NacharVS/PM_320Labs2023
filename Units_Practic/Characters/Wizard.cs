// Turushkin Sergey, 320P, "EditUnit"

namespace Units_Practic.Characters
{
    public class Wizard : Unit
    {
        public Wizard()
        {
            characteristics = new Characteristics(Units.Wizard);
            UpdateHaracteristics();
        }
    }
}
