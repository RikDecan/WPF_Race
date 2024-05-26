using Ado.Data.SqlServer;
using Races.Db.Race_DriverRepository;

namespace Races.Db.RepositoryPacks
{
    public partial class Race_DriverRepositoryPack : SqlServerTable
    {
        #region Properties
        public Race_DriverQuery Query { get; set; }
        public Race_DriverInsert Insert { get; set; }
        public Race_DriverUpdate Update { get; set; }
        public Race_DriverDelete Delete { get; set; }
        #endregion

        #region Ctor
        public Race_DriverRepositoryPack(SqlServerDbAccess dbAccess) : base(dbAccess)
        {
            Query = new Race_DriverQuery(this);
            Insert = new Race_DriverInsert(this);
            Update = new Race_DriverUpdate(this);
            Delete = new Race_DriverDelete(this);
        }
        #endregion
    }
}
