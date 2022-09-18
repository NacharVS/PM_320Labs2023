namespace CharacterEditorCore
{
    public class Rogue : Character
    {
        public Rogue() : base(new Characterictic(15, 55), 2, 1,
                              new Characterictic(30, 250), 4, 1.5,
                              new Characterictic(20, 80), 6, 0,
                              new Characterictic(15, 70), 1.5, 2)
        { }
    }
}