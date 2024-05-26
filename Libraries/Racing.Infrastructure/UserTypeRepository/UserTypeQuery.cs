using Ado.Data.SqlServer;
using System.Data;
using System.Data.SqlClient;

namespace Races.Db.UserTypeRepository
{
    public partial class UserTypeQuery
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public UserTypeQuery(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        private List<UserType> ToList(SqlCommand sqlCommand)
        {
            var dt = _table.DbAccess.GetDataTable(sqlCommand);
            // dt.AsDataView().AsQueryable();
            List<UserType> list = [];
            foreach (DataRow dataRow in dt.Rows)
            {
                UserType usertype = new()
                {
                    UserTypeId = (int)dataRow["UserTypeId"],
                    Name = (string)dataRow["Name"],
                    IsDeleted = (byte)dataRow["IsDeleted"]
                };
                list.Add(usertype);
            }
            return list;
        }

        public List<UserType> ToList(string sql)
        {
            return ToList(new SqlCommand(sql));
        }

        public int Count()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(*) FROM [UserType];";
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }

        public int CountByKeyword(string keyword)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT COUNT(UserTypeId) FROM [UserType] WHERE (Name LIKE '%' + @Keyword + '%');";
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                return Convert.ToInt32(_table.DbAccess.ExecuteScalar(sqlCommand));
            }
        }
        public List<UserType> All()
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserTypeId], [Name], [IsDeleted] FROM [UserType];";
                return ToList(sqlCommand);
            }
        }
        public List<UserType> ByKeyword(string keyword, int start, int end, string orderByColumnName, string orderDirection = "ASC")
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = $"SELECT [UserTypeId], [Name], [IsDeleted] FROM (SELECT ROW_NUMBER() OVER (ORDER BY {orderByColumnName} {orderDirection}) AS RowSequence, [UserTypeId], [Name], [IsDeleted] FROM [UserType] WHERE (Name LIKE '%' + @Keyword + '%')) AS [UserType] WHERE RowSequence BETWEEN @Start AND @End;"; 
                sqlCommand.Parameters.AddWithValue("@Keyword", keyword);
                sqlCommand.Parameters.AddWithValue("@Start", start);
                sqlCommand.Parameters.AddWithValue("@End", end);
                return ToList(sqlCommand);
            }
        }

        public UserType? ByPrimaryKey(int userTypeId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT TOP 1 [UserTypeId], [Name], [IsDeleted] FROM [UserType] WHERE UserTypeId=@UserTypeId;";
                sqlCommand.Parameters.AddWithValue("@UserTypeId", userTypeId);
                var list = ToList(sqlCommand);
                if (list.Count > 0)
                {
                    return list[0];
                }
                return null;
            }
        }

        public List<UserType> ByUserTypeId(int userTypeId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserTypeId], [Name], [IsDeleted] FROM [UserType] WHERE UserTypeId = @UserTypeId;";
                sqlCommand.Parameters.AddWithValue("@UserTypeId", userTypeId);
                return ToList(sqlCommand);
            }
        }

        public List<UserType> ByName(string name)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserTypeId], [Name], [IsDeleted] FROM [UserType] WHERE Name = @Name;";
                sqlCommand.Parameters.AddWithValue("@Name", name);
                return ToList(sqlCommand);
            }
        }

        public List<UserType> ByIsDeleted(byte isDeleted)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "SELECT [UserTypeId], [Name], [IsDeleted] FROM [UserType] WHERE IsDeleted = @IsDeleted;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                return ToList(sqlCommand);
            }
        }
        #endregion
    }
}
