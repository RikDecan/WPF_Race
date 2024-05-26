using Ado.Data.SqlServer;
using System.Data;
using System.Data.SqlClient;

namespace Races.Db.Race_DriverRepository
{
    public partial class Race_DriverQuery
    {
        private readonly SqlServerTable _table;

        public Race_DriverQuery(SqlServerTable table)
        {
            this._table = table;
        }

        private List<Race_Driver> ToList(SqlCommand sqlCommand)
        {
            var dt = _table.DbAccess.GetDataTable(sqlCommand);
            List<Race_Driver> list = [];
            foreach (DataRow dataRow in dt.Rows)
            {
                Race_Driver race_driver = new()
                {
                    RaceId = (int)dataRow["RaceId"],
                    DriverId = (int)dataRow["DriverId"],
                    IsDeleted = (byte)dataRow["IsDeleted"]
                };
                list.Add(race_driver);
            }
            return list;
        }

        public List<Race_Driver> ToList(string sql)
        {
            return ToList(new SqlCommand(sql));
        }

        public int Count()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(*) FROM [Race_Driver];";
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }

        public int CountByKeyword(string keyword)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(RaceId) FROM [Race_Driver] WHERE ();";
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }
        public List<Race_Driver> All()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [DriverId], [IsDeleted] FROM [Race_Driver];";
                return ToList(sqlCommand);
            }
        }

        public List<Race_Driver> ByKeyword(string keyword, int start, int end, string orderByColumnName, string orderDirection = "ASC")
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = $"SELECT [RaceId], [DriverId], [IsDeleted] FROM (SELECT ROW_NUMBER() OVER (ORDER BY {orderByColumnName} {orderDirection}) AS RowSequence, [RaceId], [DriverId], [IsDeleted] FROM [Race_Driver] WHERE ()) AS [Race_Driver] WHERE RowSequence BETWEEN @Start AND @End;"; 
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                sqlCommand.Parameters.AddWithValue("@Start", start);
                sqlCommand.Parameters.AddWithValue("@End", end);
                return ToList(sqlCommand);
            }
        }

        public Race_Driver? ByPrimaryKey(int raceId, int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT TOP 1 [RaceId], [DriverId], [IsDeleted] FROM [Race_Driver] WHERE RaceId=@RaceId AND DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                var list = ToList(sqlCommand);
                if (list.Count > 0)
                {
                    return list[0];
                }
                return null;
            }
        }

        public List<Race_Driver> ByRaceId(int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [DriverId], [IsDeleted] FROM [Race_Driver] WHERE RaceId = @RaceId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                return ToList(sqlCommand);
            }
        }

        public List<Race_Driver> ByDriverId(int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [DriverId], [IsDeleted] FROM [Race_Driver] WHERE DriverId = @DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                return ToList(sqlCommand);
            }
        }
        public List<Race_Driver> ByIsDeleted(byte isDeleted)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [RaceId], [DriverId], [IsDeleted] FROM [Race_Driver] WHERE IsDeleted = @IsDeleted;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                return ToList(sqlCommand);
            }
        }
    }
}
