namespace CharacterEditorCore
{
    public class Warrior : Character
    {
        public Warrior() : base(new Characterictic(30, 250), 5, 2,
                                new Characterictic(15, 70), 1, 1,
                                new Characterictic(20, 100), 10, 2,
                                new Characterictic(10, 50), 1, 1, 0, 0) {}

        public Warrior(int strength,
                       int dexterity,
                       int constitution,
                       int intellisense,
                       int experience,
                       int availableAbilityCount) : base(new Characterictic(30, strength, 250), 5, 2,
                                                new Characterictic(15, dexterity, 70), 1, 1,
                                                new Characterictic(20, constitution, 100), 10, 2,
                                                new Characterictic(10, intellisense, 50), 1, 1, 
                                                experience, availableAbilityCount)
        {
            Equipment = new Items.Equipment(3, 3, 3);
        }
    }
}