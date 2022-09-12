
namespace CharacterEditorCore
{
    public class Wizard : BaseCharacteristics
    {
        public Wizard() : base(new Characteristics(10, 10, 45),
                               new Characteristics(20, 20, 70),
                               new Characteristics(15, 15, 60),
                               new Characteristics(35, 35, 250),
                               1, 3, 0.5, 0, 1,
                               3, 5, 2,
                               5)
        {

        }
    }
}
