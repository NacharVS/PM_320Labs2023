using Editor.Core.MatchHistory;

namespace DataProvider.Models;

public class MatchHistoryDb : BaseModel
{
    public string[] Teams { get; set; }
    public MatchPlayerRecord[] PlayerRecords { get; set; }
    public DateTime Date { get; set; }

    public MatchHistoryDb(string id, MatchHistory entity)
    {
        Id = id;
        Teams = entity.Teams;
        PlayerRecords = entity.PlayerRecords;
        Date = entity.Date;
    }
}