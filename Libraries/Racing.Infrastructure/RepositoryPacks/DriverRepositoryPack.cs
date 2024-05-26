using Ado.Data.SqlServer;
using Races.Db.DriverRepository;

namespace Races.Db.RepositoryPacks
{
    public partial class DriverRepositoryPack : SqlServerTable
    {
        #region Properties
        public DriverQuery Query { get; set; }
        public DriverInsert Insert { get; set; }
        public DriverUpdate Update { get; set; }
        public DriverDelete Delete { get; set; }
        #endregion

        #region Ctor
        public DriverRepositoryPack(SqlServerDbAccess dbAccess) : base(dbAccess)
        {
            Query = new DriverQuery(this);
            Insert = new DriverInsert(this);
            Update = new DriverUpdate(this);
            Delete = new DriverDelete(this);
        }
        #endregion
    }
}
