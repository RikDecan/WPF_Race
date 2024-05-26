using Ado.Data.SqlServer;
using System.Data;
using System.Data.SqlClient;

namespace Races.Db.DriverRepository
{ 
    public partial class DriverQuery
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public DriverQuery(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        private List<Driver> ToList(SqlCommand sqlCommand)
        {
            var dt = _table.DbAccess.GetDataTable(sqlCommand);

            List<Driver> list = [];
            foreach (DataRow dataRow in dt.Rows)
            {
                Driver driver = new()
                {
                    DriverId = (int)dataRow["DriverId"],
                    FirstName = (string)dataRow["FirstName"],
                    LastName = (string)dataRow["LastName"],
                    CallSign = (string)dataRow["CallSign"],
                    IsDeleted = (byte)dataRow["IsDeleted"]
                };
                list.Add(driver);
            }
            return list;
        }

        public List<Driver> ToList(string sql)
        {
            return ToList(new SqlCommand(sql));
        }

        public int Count()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(*) FROM [Driver];";
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }

        public int CountByKeyword(string keyword)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(DriverId) FROM [Driver] WHERE (FirstName LIKE '%' + @Keyword + '%' OR LastName LIKE '%' + @Keyword + '%' OR CallSign LIKE '%' + @Keyword + '%');";
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }

        public List<Driver> All()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver];";
                return ToList(sqlCommand);
            }
        }

        public List<Driver> ByKeyword(string keyword, int start, int end, string orderByColumnName, string orderDirection = "ASC")
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = $"SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM (SELECT ROW_NUMBER() OVER (ORDER BY {orderByColumnName} {orderDirection}) AS RowSequence, [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE (FirstName LIKE '%' + @Keyword + '%' OR LastName LIKE '%' + @Keyword + '%' OR CallSign LIKE '%' + @Keyword + '%')) AS [Driver] WHERE RowSequence BETWEEN @Start AND @End;";
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                sqlCommand.Parameters.AddWithValue("@Start", start);
                sqlCommand.Parameters.AddWithValue("@End", end);
                return ToList(sqlCommand);
            }
        }

        public Driver? ByPrimaryKey(int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT TOP 1 [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                var list = ToList(sqlCommand);
                if (list.Count > 0)
                {
                    return list[0];
                }
                return null;
            }
        }
        public List<Driver> ByDriverId(int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE DriverId = @DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                return ToList(sqlCommand);
            }
        }

        public List<Driver> ByFirstName(string firstName)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE FirstName = @FirstName;";
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                return ToList(sqlCommand);
            }
        }

        public List<Driver> ByLastName(string lastName)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE LastName = @LastName;";
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                return ToList(sqlCommand);
            }
        }
        public List<Driver> ByCallSign(string callSign)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE CallSign = @CallSign;";
                sqlCommand.Parameters.AddWithValue("@CallSign", callSign);
                return ToList(sqlCommand);
            }
        }

        public List<Driver> ByIsDeleted(byte isDeleted)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [DriverId], [FirstName], [LastName], [CallSign], [IsDeleted] FROM [Driver] WHERE IsDeleted = @IsDeleted;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                return ToList(sqlCommand);
            }
        }
        #endregion
    }
}
