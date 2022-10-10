using Editor.Core.MatchHistory;

namespace DataProvider.Models;

public class MatchHistoryDb : BaseModel
{
    public string[] Teams { get; set; }
    public MatchPlayerRecord[] PlayerRecords { get; set; }
    public DateTime Date { get; set; }
}