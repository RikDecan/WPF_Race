using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.UserTypeRepository
{
    public partial class UserTypeUpdate
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public UserTypeUpdate(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        private void SetSqlCommandParameter(SqlCommand sqlCommand, UserType usertype)
        {
            sqlCommand.Parameters.AddWithValue("@UserTypeId", usertype.UserTypeId);
            sqlCommand.Parameters.AddWithValue("@Name", usertype.Name);
            sqlCommand.Parameters.AddWithValue("@IsDeleted", usertype.IsDeleted);
        }
        public virtual void ByPrimaryKey(UserType usertype)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [UserType] SET Name=@Name, IsDeleted=@IsDeleted WHERE UserTypeId=@UserTypeId;";
                SetSqlCommandParameter(sqlCommand, usertype);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByUserTypeId(UserType userType)
        {
            using (SqlCommand sqlCommand = new())
            { 
                sqlCommand.CommandText = "UPDATE [UserType] SET Name=@Name, IsDeleted=@IsDeleted WHERE UserTypeId=@UserTypeId;";
                SetSqlCommandParameter(sqlCommand, userType);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByName(UserType userType)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [UserType] SET IsDeleted=@IsDeleted WHERE Name=@Name;";
                SetSqlCommandParameter(sqlCommand, userType);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByIsDeleted(UserType userType)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [UserType] SET Name=@Name WHERE IsDeleted=@IsDeleted;";
                SetSqlCommandParameter(sqlCommand, userType);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void NameByPrimaryKey(string name, int userTypeId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [UserType] SET Name=@Name WHERE UserTypeId=@UserTypeId;";
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@UserTypeId", userTypeId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void IsDeletedByPrimaryKey(byte isDeleted, int userTypeId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [UserType] SET IsDeleted=@IsDeleted WHERE UserTypeId=@UserTypeId;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                sqlCommand.Parameters.AddWithValue("@UserTypeId", userTypeId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
