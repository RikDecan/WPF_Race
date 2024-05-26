using Ado.Data.SqlServer;
using Races.Db.RaceRepository;

namespace Races.Db.RepositoryPacks
{
    public partial class RaceRepositoryPack : SqlServerTable
    {
        #region Properties
        public RaceQuery Query { get; set; }
        public RaceInsert Insert { get; set; }
        public RaceUpdate Update { get; set; }
        public RaceDelete Delete { get; set; }
        #endregion

        #region Ctor
        public RaceRepositoryPack(SqlServerDbAccess dbAccess) : base(dbAccess)
        {
            Query = new RaceQuery(this);
            Insert = new RaceInsert(this);
            Update = new RaceUpdate(this);
            Delete = new RaceDelete(this);
        }
        #endregion
    }
}
