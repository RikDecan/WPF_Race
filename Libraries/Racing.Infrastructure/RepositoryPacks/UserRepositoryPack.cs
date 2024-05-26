using Ado.Data.SqlServer;
using Races.Db.UserRepository;

namespace Races.Db.RepositoryPacks
{
    public partial class UserRepositoryPack : SqlServerTable
    {
        #region Properties
        public UserQuery Query { get; set; }
        public UserInsert Insert { get; set; }
        public UserUpdate Update { get; set; }
        public UserDelete Delete { get; set; }
        #endregion

        #region Ctor
        public UserRepositoryPack(SqlServerDbAccess dbAccess) : base(dbAccess)
        {
            Query = new UserQuery(this);
            Insert = new UserInsert(this);
            Update = new UserUpdate(this);
            Delete = new UserDelete(this);
        }
        #endregion
    }
}
