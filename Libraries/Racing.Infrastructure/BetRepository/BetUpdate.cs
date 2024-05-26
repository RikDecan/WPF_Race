using Ado.Data.SqlServer;
using Races.Db;
using System.Data.SqlClient;

namespace Races.Db.BetRepository
{
    public partial class BetUpdate
    {
        #region Properties
        private readonly SqlServerTable _table;
        
        #endregion

        #region Ctor
        public BetUpdate(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        private void SetSqlCommandParameter(SqlCommand sqlCommand, Bet bet)
        {
            sqlCommand.Parameters.AddWithValue("@BetId", bet.BetId);
            sqlCommand.Parameters.AddWithValue("@RaceId", bet.RaceId);
            sqlCommand.Parameters.AddWithValue("@DriverId", bet.DriverId);
            sqlCommand.Parameters.AddWithValue("@UserId", bet.UserId);
            sqlCommand.Parameters.AddWithValue("@Amount", bet.Amount);
        }

        public virtual void ByPrimaryKey(Bet betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET BetId=@BetId, RaceId=@RaceId, DriverId=@DriverId, UserId=@UserId, Amount=@Amount WHERE BetId=@BetId;";
                SetSqlCommandParameter(sqlCommand, betId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByBetId(Bet betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET BetId=@BetId, RaceId=@RaceId, DriverId=@DriverId, UserId=@UserId, Amount=@Amount WHERE BetId=@BetId;";
                SetSqlCommandParameter(sqlCommand, betId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }


        public virtual void ByRaceId(Bet raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET BetId=@BetId, RaceId=@RaceId, DriverId=@DriverId, UserId=@UserId, Amount=@Amount WHERE RaceId=@RaceId;";
                SetSqlCommandParameter(sqlCommand, raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByDriverId(Bet driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET BetId=@BetId, RaceId=@RaceId, DriverId=@DriverId, UserId=@UserId, Amount=@Amount WHERE DriverId=@DriverId;";
                SetSqlCommandParameter(sqlCommand, driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByUserId(Bet userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET BetId=@BetId, RaceId=@RaceId, DriverId=@DriverId, UserId=@UserId, Amount=@Amount WHERE UserId=@UserId;";
                SetSqlCommandParameter(sqlCommand, userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }


        public virtual void ByAmount(Bet amount)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET BetId=@BetId, RaceId=@RaceId, DriverId=@DriverId, UserId=@UserId, Amount=@Amount WHERE Amount=@Amount;";
                SetSqlCommandParameter(sqlCommand, amount);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        // ------------------------------------------------------------
        public virtual void RaceIdByPrimaryKey(int raceId, int betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET RaceId=@RaceId WHERE BetId=@BetId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                sqlCommand.Parameters.AddWithValue("@BetId", betId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void DriverIdByPrimaryKey(int driverId, int betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET DriverId=@DriverId WHERE BetId=@BetId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                sqlCommand.Parameters.AddWithValue("@BetId", betId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void UserIdByPrimaryKey(int userId, int betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET UserId=@UserId WHERE BetId=@BetId;";
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@BetId", betId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void AmountByPrimaryKey(int amount, int betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Bet] SET Amount=@Amount WHERE BetId=@BetId;";
                sqlCommand.Parameters.AddWithValue("@Amount", amount);
                sqlCommand.Parameters.AddWithValue("@BetId", betId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
