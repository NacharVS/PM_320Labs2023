// Turushkin Sergey, 320P, "EditUnit"

using MongoDB.Bson.Serialization.Attributes;

namespace Units_Practic.Characters
{
    [BsonDiscriminator("Rogue")]
    public class Rogue : Unit
    {
        public Rogue()
        {
            characteristics = new Characteristics(Units.Rogue);
            UpdateHaracteristics();
        }
    }
}
