using Ado.Data.SqlServer;
using Races.Db.UserTypeRepository;

namespace Races.Db.RepositoryPacks
{
    public partial class UserTypeRepositoryPack : SqlServerTable
    {
        #region Properties
        public UserTypeQuery Query { get; set; }
        public UserTypeInsert Insert { get; set; }
        public UserTypeUpdate Update { get; set; }
        public UserTypeDelete Delete { get; set; }
        #endregion

        #region Ctor
        public UserTypeRepositoryPack(SqlServerDbAccess dbAccess) : base(dbAccess)
        {
            Query = new UserTypeQuery(this);
            Insert = new UserTypeInsert(this);
            Update = new UserTypeUpdate(this);
            Delete = new UserTypeDelete(this);
        }
        #endregion
    }
}
