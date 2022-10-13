namespace CharacterEditorCore
{
    public class Wizard : Character
    {
        public Wizard() : base(new Characterictic(10, 45), 3, 1,
                              new Characterictic(20, 70), 0, 0.5,
                              new Characterictic(15, 60), 3, 1,
                              new Characterictic(35, 250), 2, 5, 0, 0)
        {
            Equipment = new Items.Equipment(2, 1, 2);
        }

        public Wizard (int strength,
                       int dexterity,
                       int constitution,
                       int intellisense,
                       int experience,
                       int availableAbilityCount) : base(new Characterictic(10, strength, 45), 3, 1,
                                                new Characterictic(20, dexterity, 70), 0, 0.5,
                                                new Characterictic(15, constitution, 60), 3, 1,
                                                new Characterictic(35, intellisense, 250), 2, 5, 
                                                experience, availableAbilityCount)
        {
            Equipment = new Items.Equipment(2, 1, 2);
        }
    }
}