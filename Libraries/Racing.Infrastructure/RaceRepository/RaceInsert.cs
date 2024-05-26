using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.RaceRepository
{
    public partial class RaceInsert
    {
        private readonly SqlServerTable _table;

        public RaceInsert(SqlServerTable table)
        {
            this._table = table;
        }

        public void NewRecord(Race race)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "INSERT INTO [Race] (Name, StartTime, StopTime, DriverId) VALUES (@Name, @StartTime, @StopTime, @DriverId); SELECT SCOPE_IDENTITY() AS INT;";
                sqlCommand.Parameters.AddWithValue("@Name", race.Name);
                sqlCommand.Parameters.AddWithValue("@StartTime", race.StartTime);
                sqlCommand.Parameters.AddWithValue("@StopTime", race.StopTime ?? (object)DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@DriverId", race.DriverId ?? (object)DBNull.Value);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
    }
}
