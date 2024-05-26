using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.UserRepository
{
    public partial class UserInsert
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public UserInsert(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        public virtual void NewRecord(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "INSERT INTO [User] (FirstName, LastName, CallSign, BirthDate, UserTypeId, Password, IsDeleted) VALUES (@FirstName, @LastName, @CallSign, @BirthDate, @UserTypeId, @Password, @IsDeleted); SELECT SCOPE_IDENTITY() AS INT;";
                sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
                sqlCommand.Parameters.AddWithValue("@CallSign", user.CallSign);
                sqlCommand.Parameters.AddWithValue("@BirthDate", user.BirthDate);
                sqlCommand.Parameters.AddWithValue("@UserTypeId", user.UserTypeId);
                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                sqlCommand.Parameters.AddWithValue("@IsDeleted", user.IsDeleted);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
