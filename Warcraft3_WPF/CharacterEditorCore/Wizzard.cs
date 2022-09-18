namespace CharacterEditorCore
{
    public class Wizard : Character
    {
        public Wizard() : base(new Characterictic(10, 45), 3, 1,
                              new Characterictic(20, 70), 0, 0.5,
                              new Characterictic(15, 60), 3, 1,
                              new Characterictic(35, 250), 2, 5)
        { }
    }
}