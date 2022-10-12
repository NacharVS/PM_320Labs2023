// Turushkin Sergey, 320P, "EditUnit"

using MongoDB.Bson.Serialization.Attributes;

namespace Units_Practic.Characters
{
    [BsonDiscriminator("Wizard")]
    public class Wizard : Unit
    {
        public Wizard()
        {
            characteristics = new Characteristics(Units.Wizard);
            UpdateHaracteristics();
        }
    }
}
