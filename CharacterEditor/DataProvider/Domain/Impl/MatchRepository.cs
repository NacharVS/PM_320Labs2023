using DataProvider.Models;
using Editor.Core.MatchHistory;


namespace DataProvider.Domain.Impl
{
    public class MatchRepository : BaseRepository<MatchHistory, MatchHistoryDb>
    {
        public MatchRepository(MongoConnection<MatchHistoryDb> connection) : base(connection)
        {

        }

        protected override MatchHistory? CastToEntity(MatchHistoryDb model)
        {
            return InitializeEntity(model);
        }

        protected override MatchHistory? InitializeEntity(MatchHistoryDb model)
        {
            return new MatchHistory
            {
                Name = model.Name,
                Date = model.Date,
                PlayerRecords = model.PlayerRecords,
                Teams = model.Teams,
            };
        }
    }
}
