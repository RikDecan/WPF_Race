using Ado.Data.SqlServer;
using Races.Db;
using System.Data.SqlClient;

namespace Races.Db.BetRepository 
{
    public partial class BetInsert
    {


        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public BetInsert(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods

        public void NewRecord(Bet bet)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "INSERT INTO [Bet] (BetId, RaceId, DriverId, UserId, Amount) VALUES (@BetId, @RaceId, @DriverId, @UserId, @Amount); SELECT SCOPE_IDENTITY() AS INT;";
                sqlCommand.Parameters.AddWithValue("@BetId", bet.BetId);
                sqlCommand.Parameters.AddWithValue("@RaceId", bet.RaceId);
                sqlCommand.Parameters.AddWithValue("@DriverId", bet.DriverId);
                sqlCommand.Parameters.AddWithValue("@UserId", bet.UserId);
                sqlCommand.Parameters.AddWithValue("@Amount", bet.Amount);

                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        #endregion


    }
}
