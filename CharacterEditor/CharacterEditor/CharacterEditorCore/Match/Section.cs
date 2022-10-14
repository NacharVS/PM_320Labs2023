namespace CharacterEditorCore.Match
{
    public class Section
    {
        public int IndexFrom { get; set; }
        public int IndexTo { get; set; }
        public int Count => IndexTo - IndexFrom;
    }
}