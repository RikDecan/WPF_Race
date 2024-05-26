using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.RaceRepository
{
    public partial class RaceUpdate
    {
        private readonly SqlServerTable _table;

        public RaceUpdate(SqlServerTable table)
        {
            this._table = table;
        }

        private void SetSqlCommandParameter(SqlCommand sqlCommand, Race race)
        {
            sqlCommand.Parameters.AddWithValue("@RaceId", race.RaceId);
            sqlCommand.Parameters.AddWithValue("@Name", race.Name);
            sqlCommand.Parameters.AddWithValue("@StartTime", race.StartTime);
            sqlCommand.Parameters.AddWithValue("@StopTime", race.StopTime ?? (object)DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@DriverId", race.DriverId ?? (object)DBNull.Value);
        }

        public void ByPrimaryKey(Race race)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET Name=@Name, StartTime=@StartTime, StopTime=@StopTime, DriverId=@DriverId WHERE RaceId=@RaceId;";
                SetSqlCommandParameter(sqlCommand, race);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByRaceId(Race race)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET Name=@Name, StartTime=@StartTime, StopTime=@StopTime, DriverId=@DriverId WHERE RaceId=@RaceId;";
                SetSqlCommandParameter(sqlCommand, race);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByName(Race race)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET StartTime=@StartTime, StopTime=@StopTime, DriverId=@DriverId WHERE Name=@Name;";
                SetSqlCommandParameter(sqlCommand, race);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByStartTime(Race race)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET Name=@Name, StopTime=@StopTime, DriverId=@DriverId WHERE StartTime=@StartTime;";
                SetSqlCommandParameter(sqlCommand, race);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByStopTime(Race race)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET Name=@Name, StartTime=@StartTime, DriverId=@DriverId WHERE StopTime=@StopTime;";
                SetSqlCommandParameter(sqlCommand, race);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByDriverId(Race race)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET Name=@Name, StartTime=@StartTime, StopTime=@StopTime WHERE DriverId=@DriverId;";
                SetSqlCommandParameter(sqlCommand, race);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void NameByPrimaryKey(string name, int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET Name=@Name WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void StartTimeByPrimaryKey(DateTime startTime, int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET StartTime=@StartTime WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@StartTime", startTime);
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void StopTimeByPrimaryKey(Nullable<DateTime> stopTime, int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET StopTime=@StopTime WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@StopTime", stopTime ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void DriverIdByPrimaryKey(Nullable<int> driverId, int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race] SET DriverId=@DriverId WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
    }
}
