using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ado.Data.SqlServer;
using Races.Db.BetRepository;


namespace Races.Db.RepositoryPacks
{
    public partial class BetRepositoryPack : SqlServerTable
    {
        #region Properties
        public BetQuery Query { get; set; }
        public BetInsert Insert { get; set; }
        public BetUpdate Update { get; set; }
        public BetDelete Delete { get; set; }
        #endregion

        #region Ctor
        public BetRepositoryPack(SqlServerDbAccess dbAccess) : base(dbAccess)
        {
            Query = new BetQuery(this);
            Insert = new BetInsert(this);
            Update = new BetUpdate(this);
            Delete = new BetDelete(this);
        }
        #endregion
    }

}
