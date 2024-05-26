using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.UserRepository
{
    public partial class UserUpdate
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public UserUpdate(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        private void SetSqlCommandParameter(SqlCommand sqlCommand, User user)
        {
            sqlCommand.Parameters.AddWithValue("@UserId", user.UserId);
            sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
            sqlCommand.Parameters.AddWithValue("@CallSign", user.CallSign);
            sqlCommand.Parameters.AddWithValue("@BirthDate", user.BirthDate);
            sqlCommand.Parameters.AddWithValue("@UserTypeId", user.UserTypeId);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@IsDeleted", user.IsDeleted);
        }
        public virtual void ByPrimaryKey(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign, BirthDate=@BirthDate, UserTypeId=@UserTypeId, Password=@Password, IsDeleted=@IsDeleted WHERE UserId=@UserId;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByUserId(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign, BirthDate=@BirthDate, UserTypeId=@UserTypeId, Password=@Password, IsDeleted=@IsDeleted WHERE UserId=@UserId;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByFirstName(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET LastName=@LastName, CallSign=@CallSign, BirthDate=@BirthDate, UserTypeId=@UserTypeId, Password=@Password, IsDeleted=@IsDeleted WHERE FirstName=@FirstName;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByLastName(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName, CallSign=@CallSign, BirthDate=@BirthDate, UserTypeId=@UserTypeId, Password=@Password, IsDeleted=@IsDeleted WHERE LastName=@LastName;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByCallSign(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName, LastName=@LastName, BirthDate=@BirthDate, UserTypeId=@UserTypeId, Password=@Password, IsDeleted=@IsDeleted WHERE CallSign=@CallSign;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByBirthDate(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign, UserTypeId=@UserTypeId, Password=@Password, IsDeleted=@IsDeleted WHERE BirthDate=@BirthDate;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByUserTypeId(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign, BirthDate=@BirthDate, Password=@Password, IsDeleted=@IsDeleted WHERE UserTypeId=@UserTypeId;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByPassword(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign, BirthDate=@BirthDate, UserTypeId=@UserTypeId, IsDeleted=@IsDeleted WHERE Password=@Password;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByIsDeleted(User user)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign, BirthDate=@BirthDate, UserTypeId=@UserTypeId, Password=@Password WHERE IsDeleted=@IsDeleted;";
                SetSqlCommandParameter(sqlCommand, user);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void FirstNameByPrimaryKey(string firstName, int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET FirstName=@FirstName WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void LastNameByPrimaryKey(string lastName, int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET LastName=@LastName WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void CallSignByPrimaryKey(string callSign, int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET CallSign=@CallSign WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@CallSign", callSign);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void BirthDateByPrimaryKey(DateTime birthDate, int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET BirthDate=@BirthDate WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@BirthDate", birthDate);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void UserTypeIdByPrimaryKey(int userTypeId, int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET UserTypeId=@UserTypeId WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@UserTypeId", userTypeId);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void PasswordByPrimaryKey(string password, int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET Password=@Password WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@Password", password);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void IsDeletedByPrimaryKey(byte isDeleted, int userId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [User] SET IsDeleted=@IsDeleted WHERE UserId=@UserId;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
