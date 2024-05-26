using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.UserRepository
{
    public partial class UserDelete
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public UserDelete(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        public virtual void ByPrimaryKey(int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByUserId(int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByFirstName(string firstName)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE FirstName=@FirstName;";
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByLastName(string lastName)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE LastName=@LastName;";
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByCallSign(string callSign)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE CallSign=@CallSign;";
                sqlCommand.Parameters.AddWithValue("@CallSign", callSign);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByBirthDate(DateTime birthDate)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE BirthDate=@BirthDate;";
                sqlCommand.Parameters.AddWithValue("@BirthDate", birthDate);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByUserTypeId(int userTypeId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE UserTypeId=@UserTypeId;";
                sqlCommand.Parameters.AddWithValue("@UserTypeId", userTypeId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByPassword(string password)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE Password=@Password;";
                sqlCommand.Parameters.AddWithValue("@Password", password);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByIsDeleted(byte isDeleted)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [User] WHERE IsDeleted=@IsDeleted;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
