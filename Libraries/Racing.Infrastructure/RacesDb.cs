using Ado.Data.SqlServer;
using Races.Db.RepositoryPacks;

namespace Races.Db
{
    public partial class RacesDb : SqlServerDbAccess
    {
        #region Properties
        public DriverRepositoryPack Driver { get; set; }
        public RaceRepositoryPack Race { get; set; }
        public Race_DriverRepositoryPack Race_Driver { get; set; }
        public UserRepositoryPack User { get; set; }
        public UserTypeRepositoryPack UserType { get; set; }
        #endregion

        #region Ctor
        public RacesDb(string cs) : base(new ConnectionStringBuilder() { ConnectionString = cs })
        {
            Driver = new DriverRepositoryPack(this);
            Race = new RaceRepositoryPack(this);
            Race_Driver = new Race_DriverRepositoryPack(this);
            User = new UserRepositoryPack(this);
            UserType = new UserTypeRepositoryPack(this);
        }
    }
    #endregion
}
