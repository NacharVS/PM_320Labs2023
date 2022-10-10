namespace Editor.Core.Helpers
{
    public class StatChangeArgs : EventArgs
    {
        public bool Handled { get; set; }
        public bool IgnoreSkillPoints { get; set; }
        public int Difference { get; set; }

        public StatChangeArgs(int difference, bool ignoreSkillPoints=false)
        {
            Difference = difference;
            IgnoreSkillPoints = ignoreSkillPoints;
        }
    }
}
