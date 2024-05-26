using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.RaceRepository
{
    public partial class RaceDelete
    {
        private readonly SqlServerTable _table;
        public RaceDelete(SqlServerTable table)
        {
            this._table = table;
        }
        public void ByPrimaryKey(int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race] WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByRaceId(int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race] WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByName(string name)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race] WHERE Name=@Name;";
                sqlCommand.Parameters.AddWithValue("@Name", name);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByStartTime(DateTime startTime)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race] WHERE StartTime=@StartTime;";
                sqlCommand.Parameters.AddWithValue("@StartTime", startTime);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByStopTime(Nullable<DateTime> stopTime)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race] WHERE StopTime=@StopTime;";
                sqlCommand.Parameters.AddWithValue("@StopTime", stopTime ?? (object)DBNull.Value);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByDriverId(Nullable<int> driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race] WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId ?? (object)DBNull.Value);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
    }
}
