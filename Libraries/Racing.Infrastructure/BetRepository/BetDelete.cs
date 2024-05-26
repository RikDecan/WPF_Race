using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.BetRepository
{
    public partial class BetDelete
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion


        #region Ctor
        public BetDelete(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion


        #region Methods
        public void ByPrimaryKey(int betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Bet] WHERE BetId=@BetId;";
                sqlCommand.Parameters.AddWithValue("@BetId", betId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByRaceId(int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Bet] WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByDriverId(int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Bet] WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByUserId(int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Bet] WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByAmount(int amount)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Bet] WHERE Amount=@Amount;";
                sqlCommand.Parameters.AddWithValue("@Amount", amount);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        #endregion

    }
}
