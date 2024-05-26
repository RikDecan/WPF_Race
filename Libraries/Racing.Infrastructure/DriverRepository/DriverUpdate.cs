using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.DriverRepository
{
    public partial class DriverUpdate
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public DriverUpdate(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        private void SetSqlCommandParameter(SqlCommand sqlCommand, Driver driver)
        {
            sqlCommand.Parameters.AddWithValue("@DriverId", driver.DriverId);
            sqlCommand.Parameters.AddWithValue("@FirstName", driver.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", driver.LastName);
            sqlCommand.Parameters.AddWithValue("@CallSign", driver.CallSign);
            sqlCommand.Parameters.AddWithValue("@IsDeleted", driver.IsDeleted);
        }

        public virtual void ByPrimaryKey(Driver driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign, IsDeleted=@IsDeleted WHERE DriverId=@DriverId;";
                SetSqlCommandParameter(sqlCommand, driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByDriverId(Driver driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign, IsDeleted=@IsDeleted WHERE DriverId=@DriverId;";
                SetSqlCommandParameter(sqlCommand, driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByFirstName(Driver driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET LastName=@LastName, CallSign=@CallSign, IsDeleted=@IsDeleted WHERE FirstName=@FirstName;";
                SetSqlCommandParameter(sqlCommand, driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByLastName(Driver driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET FirstName=@FirstName, CallSign=@CallSign, IsDeleted=@IsDeleted WHERE LastName=@LastName;";
                SetSqlCommandParameter(sqlCommand, driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByCallSign(Driver driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET FirstName=@FirstName, LastName=@LastName, IsDeleted=@IsDeleted WHERE CallSign=@CallSign;";
                SetSqlCommandParameter(sqlCommand, driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void ByIsDeleted(Driver driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET FirstName=@FirstName, LastName=@LastName, CallSign=@CallSign WHERE IsDeleted=@IsDeleted;";
                SetSqlCommandParameter(sqlCommand, driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void FirstNameByPrimaryKey(string firstName, int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET FirstName=@FirstName WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void LastNameByPrimaryKey(string lastName, int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET LastName=@LastName WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void CallSignByPrimaryKey(string callSign, int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET CallSign=@CallSign WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@CallSign", callSign);
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public virtual void IsDeletedByPrimaryKey(byte isDeleted, int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Driver] SET IsDeleted=@IsDeleted WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
