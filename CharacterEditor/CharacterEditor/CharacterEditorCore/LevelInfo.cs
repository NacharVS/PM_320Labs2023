namespace CharacterEditorCore
{
    public static class LevelInfo
    {
        private static int levelUpValue = 1000;

        public static int GetLevel(int experience)
        {
            var level = 1;
            var currentLevelExperienceValue = 0;

            while (experience >= level * levelUpValue + currentLevelExperienceValue)
            {
                currentLevelExperienceValue = level * levelUpValue + currentLevelExperienceValue;
                level++;
            }

            return level;
        }
    }
}
