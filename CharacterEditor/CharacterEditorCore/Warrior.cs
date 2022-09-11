namespace CharacterEditorCore
{
    class Warrior : BaseCharacteristics
    {
        public Warrior() : base(new Characteristics(30, 30, 250),
                               new Characteristics(15, 15,70),
                               new Characteristics(20,20,100),
                               new Characteristics(10,10,50),
                               2,5,1,1,2,
                               10,1,1)
        {

        }
    }
}
