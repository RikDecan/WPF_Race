using Ado.Data.SqlServer;
using System.Data;
using System.Data.SqlClient;

namespace Races.Db.UserRepository
{
    public partial class UserQuery
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public UserQuery(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        private List<User> ToList(SqlCommand sqlCommand)
        {
            var dt = _table.DbAccess.GetDataTable(sqlCommand);
            List<User> list = [];
            foreach (DataRow dataRow in dt.Rows)
            {
                User user = new()
                {
                    UserId = (int)dataRow["UserId"],
                    FirstName = (string)dataRow["FirstName"],
                    LastName = (string)dataRow["LastName"],
                    CallSign = (string)dataRow["CallSign"],
                    BirthDate = (DateTime)dataRow["BirthDate"],
                    UserTypeId = (int)dataRow["UserTypeId"],
                    Password = (string)dataRow["Password"],
                    IsDeleted = (byte)dataRow["IsDeleted"]
                };
                list.Add(user);
            }
            return list;
        }
        public List<User> ToList(string sql)
        {
            return ToList(new SqlCommand(sql));
        }
        public int Count()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(*) FROM [User];";
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }

        public int CountByKeyword(string keyword)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(UserId) FROM [User] WHERE (FirstName LIKE '%' + @Keyword + '%' OR LastName LIKE '%' + @Keyword + '%' OR CallSign LIKE '%' + @Keyword + '%' OR Password LIKE '%' + @Keyword + '%');";
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }

        public List<User> All()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User];";
                return ToList(sqlCommand);
            }
        }

        public List<User> ByKeyword(string keyword, int start, int end, string orderByColumnName, string orderDirection = "ASC")
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = $"SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM (SELECT ROW_NUMBER() OVER (ORDER BY {orderByColumnName} {orderDirection}) AS RowSequence, [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE (FirstName LIKE '%' + @Keyword + '%' OR LastName LIKE '%' + @Keyword + '%' OR CallSign LIKE '%' + @Keyword + '%' OR Password LIKE '%' + @Keyword + '%')) AS [User] WHERE RowSequence BETWEEN @Start AND @End;"; 
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                sqlCommand.Parameters.AddWithValue("@Start", start);
                sqlCommand.Parameters.AddWithValue("@End", end);
                return ToList(sqlCommand);
            }
        }
        public User? ByPrimaryKey(int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                // SELECT TOP 1 is "SQLServer" code voor LIMIT in MySQL
                sqlCommand.CommandText = "SELECT TOP 1 [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                var list = ToList(sqlCommand);
                if (list.Count > 0)
                {
                    return list[0];
                }
                return null;
            }
        }
        public List<User> ByUserId(int userId)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE UserId = @UserId;";
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                return ToList(sqlCommand);
            }
        }
        public virtual List<User> ByFirstName(string firstName)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE FirstName = @FirstName;";
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                return ToList(sqlCommand);
            }
        }
        public List<User> ByLastName(string lastName)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE LastName = @LastName;";
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                return ToList(sqlCommand);
            }
        }
        public List<User> ByCallSign(string callSign)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE CallSign = @CallSign;";
                sqlCommand.Parameters.AddWithValue("@CallSign", callSign);
                return ToList(sqlCommand);
            }
        }
        public List<User> ByBirthDate(DateTime birthDate)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE BirthDate = @BirthDate;";
                sqlCommand.Parameters.AddWithValue("@BirthDate", birthDate);
                return ToList(sqlCommand);
            }
        }

        public List<User> ByUserTypeId(int userTypeId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE UserTypeId = @UserTypeId;";
                sqlCommand.Parameters.AddWithValue("@UserTypeId", userTypeId);
                return ToList(sqlCommand);
            }
        }
        public List<User> ByPassword(string password)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE Password = @Password;";
                sqlCommand.Parameters.AddWithValue("@Password", password);
                return ToList(sqlCommand);
            }
        }
        public List<User> ByIsDeleted(byte isDeleted)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserId], [FirstName], [LastName], [CallSign], [BirthDate], [UserTypeId], [Password], [IsDeleted] FROM [User] WHERE IsDeleted = @IsDeleted;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                return ToList(sqlCommand);
            }
        }
        #endregion
    }
}
