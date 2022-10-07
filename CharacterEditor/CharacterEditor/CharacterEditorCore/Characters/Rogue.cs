namespace CharacterEditorCore
{
    public class Rogue : Character
    {
        public Rogue() : base(new Characterictic(15, 55), 2, 1,
                              new Characterictic(30, 250), 4, 1.5,
                              new Characterictic(20, 80), 6, 0,
                              new Characterictic(15, 70), 1.5, 2, 0, 0) { }

        public Rogue(int strength,
                       int dexterity,
                       int constitution,
                       int intellisense,
                       int experince,
                       int availableAbilityCount) : base(new Characterictic(15, strength, 55), 2, 1,
                                                new Characterictic(30, dexterity, 250), 4, 1.5,
                                                new Characterictic(20, constitution, 80), 6, 0,
                                                new Characterictic(15, intellisense, 70), 1.5, 2 , 
                                                experince, availableAbilityCount)
        {
            Equipment = new Items.Equipment(2, 2, 2);
        }
    }
}