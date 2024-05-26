using Ado.Data.SqlServer;
using System.Data;
using System.Data.SqlClient;

namespace Races.Db.RaceRepository
{
    public partial class RaceQuery
    {
        private readonly SqlServerTable _table;

        public RaceQuery(SqlServerTable table)
        {
            this._table = table;
        }
        private List<Race> ToList(SqlCommand sqlCommand)
        {
            var dt = _table.DbAccess.GetDataTable(sqlCommand);
            List<Race> list = [];
            foreach (DataRow dataRow in dt.Rows)
            {
                Race race = new()
                {
                    RaceId = (int)dataRow["RaceId"],
                    Name = (string)dataRow["Name"],
                    StartTime = (DateTime)dataRow["StartTime"],
                    StopTime = (Nullable<DateTime>)(dataRow["StopTime"] == DBNull.Value ? null : dataRow["StopTime"]),
                    DriverId = (Nullable<int>)(dataRow["DriverId"] == DBNull.Value ? null : dataRow["DriverId"])
                };
                list.Add(race);
            }
            return list;
        }
        public List<Race> ToList(string sql)
        {
            return ToList(new SqlCommand(sql));
        }
        public int Count()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(*) FROM [Race];";
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }
        public int CountByKeyword(string keyword)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(RaceId) FROM [Race] WHERE (Name LIKE '%' + @Keyword + '%');";
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }

        public List<Race> All()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM [Race];";
                return ToList(sqlCommand);
            }
        }

        public List<Race> ByKeyword(string keyword, int start, int end, string orderByColumnName, string orderDirection = "ASC")
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = $"SELECT [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM (SELECT ROW_NUMBER() OVER (ORDER BY {orderByColumnName} {orderDirection}) AS RowSequence, [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM [Race] WHERE (Name LIKE '%' + @Keyword + '%')) AS [Race] WHERE RowSequence BETWEEN @Start AND @End;"; 
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                sqlCommand.Parameters.AddWithValue("@Start", start);
                sqlCommand.Parameters.AddWithValue("@End", end);
                return ToList(sqlCommand);
            }
        }
        public Race? ByPrimaryKey(int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT TOP 1 [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM [Race] WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                var list = ToList(sqlCommand);
                if (list.Count > 0)
                {
                    return list[0];
                }
                return null;
            }
        }
        public List<Race> ByRaceId(int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM [Race] WHERE RaceId = @RaceId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                return ToList(sqlCommand);
            }
        }
        public List<Race> ByName(string name)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM [Race] WHERE Name = @Name;";
                sqlCommand.Parameters.AddWithValue("@Name", name);
                return ToList(sqlCommand);
            }
        }

        public List<Race> ByStartTime(DateTime startTime)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM [Race] WHERE StartTime = @StartTime;";
                sqlCommand.Parameters.AddWithValue("@StartTime", startTime);
                return ToList(sqlCommand);
            }
        }
        public List<Race> ByStopTime(Nullable<DateTime> stopTime)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM [Race] WHERE StopTime = @StopTime;";
                sqlCommand.Parameters.AddWithValue("@StopTime", stopTime);
                return ToList(sqlCommand);
            }
        }

        public List<Race> ByDriverId(Nullable<int> driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [Name], [StartTime], [StopTime], [DriverId] FROM [Race] WHERE DriverId = @DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                return ToList(sqlCommand);
            }
        }
    }
}
