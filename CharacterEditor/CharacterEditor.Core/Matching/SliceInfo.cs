namespace CharacterEditor.Core.Matching;

internal class SliceInfo
{
    public int IndexFrom { get; init; }
    public int IndexTo { get; init; }
    public int Count => IndexTo - IndexFrom;
}