// Turushkin Sergey, 320P, "EditUnit"

using MongoDB.Bson.Serialization.Attributes;

namespace Units_Practic.Characters
{
    [BsonDiscriminator("Warrior")]
    public class Warrior : Unit
    {
        public Warrior()
        {
            characteristics = new Characteristics(Units.Warrior);
            UpdateHaracteristics();
        }
    }
}
