namespace CharacterEditorCore
{
    public static class LevelInfo
    {
        private static int levelUpValue = 1000;
        private static int currentLevelExperienceValue = 0;
        private static int level = 1;

        public static int GetLevel(int experience)
        {
            while (experience >= level * levelUpValue + currentLevelExperienceValue)
            {
                currentLevelExperienceValue = level * levelUpValue + currentLevelExperienceValue;
                level++;
            }

            return level;
        }
    }
}
