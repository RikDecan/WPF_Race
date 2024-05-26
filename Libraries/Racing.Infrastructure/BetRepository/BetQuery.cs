using Ado.Data.SqlServer;
using System.Data;
using System.Data.SqlClient;

namespace Races.Db.BetRepository
{
    public partial class BetQuery
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public BetQuery (SqlServerTable table)
        {
            this._table = table;
        }
        #endregion



        #region Methods
        private List<Bet> ToList(SqlCommand sqlCommand)
        {
            var dt = _table.DbAccess.GetDataTable(sqlCommand);

            List<Bet> list = [];
            foreach (DataRow dataRow in dt.Rows)
            {
                Bet bet = new()
                {
                    BetId = (int)dataRow["BetId"],
                    RaceId = (int)dataRow["RaceId"],
                    DriverId = (int)dataRow["DriverId"],
                    UserId = (int)dataRow["UserId"],
                    Amount = (int)dataRow["Amount"]
                };
                list.Add(bet);
            }
            return list;
        }

        public List<Bet> ToList(string sql)
        {
            return ToList(new SqlCommand(sql));
        }

        public int Count()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(*) FROM [Bet];";
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }

        //public int CountByKeyword(string keyword)
        //{
        //    using (SqlCommand sqlCommand = new())
        //    {
        //        sqlCommand.CommandText = "SELECT COUNT(BetId) FROM [Bet] WHERE (FirstName LIKE '%' + @Keyword + '%' OR LastName LIKE '%' + @Keyword + '%' OR CallSign LIKE '%' + @Keyword + '%');";
        //        sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
        //        return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
        //    }
        //}

        public List<Bet> All()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [BetId], [RaceId], [DriverId], [UserId], [Amount] FROM [Bet];";
                return ToList(sqlCommand);
            }
        }

        //public List<Driver> ByKeyword(string keyword, int start, int end, string orderByColumnName, string orderDirection = "ASC")
        //{
        //    using (SqlCommand sqlCommand = new())
        //    {
        //        sqlCommand.CommandText = $"SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM (SELECT ROW_NUMBER() OVER (ORDER BY {orderByColumnName} {orderDirection}) AS RowSequence, [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE (FirstName LIKE '%' + @Keyword + '%' OR LastName LIKE '%' + @Keyword + '%' OR CallSign LIKE '%' + @Keyword + '%')) AS [Driver] WHERE RowSequence BETWEEN @Start AND @End;";
        //        sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
        //        sqlCommand.Parameters.AddWithValue("@Start", start);
        //        sqlCommand.Parameters.AddWithValue("@End", end);
        //        return ToList(sqlCommand);
        //    }
        //}

        public Bet? ByPrimaryKey(int betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT TOP 1 [BetId], [RaceId], [DriverId], [UserId], [Amount] FROM [Bet] WHERE BetId=@BetId;";
                sqlCommand.Parameters.AddWithValue("@BetId", betId);
                var list = ToList(sqlCommand);
                if (list.Count > 0)
                {
                    return list[0];
                }
                return null;
            }
        }

        public List<Bet> ByBetId(int betId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [BetId], [RaceId], [DriverId], [UserId], [Amount] FROM [Bet] WHERE BetId=@BetId";
                sqlCommand.Parameters.AddWithValue("@DriverId", betId);
                return ToList(sqlCommand);
            }
        }
        public List<Bet> ByRaceId(int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE RaceId = @RaceId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                return ToList(sqlCommand);
            }
        }

        public List<Bet> ByDriverId(int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [BetId], [RaceId], [DriverId], [UserId], [Amount] FROM [Bet] WHERE DriverId=@DriverId";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                return ToList(sqlCommand);
            }
        }

        public List<Bet> ByUserId(int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [BetId], [RaceId], [DriverId], [UserId], [Amount] FROM [Bet] WHERE UserId=@UserId";
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                return ToList(sqlCommand);
            }
        }

        public List<Bet> ByAmount(int amount)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [BetId], [RaceId], [DriverId], [UserId], [Amount] FROM [Bet] WHERE Amount=@Amount";
                sqlCommand.Parameters.AddWithValue("@Amount", amount);
                return ToList(sqlCommand);
            }
        }
        
        #endregion



    }
}
