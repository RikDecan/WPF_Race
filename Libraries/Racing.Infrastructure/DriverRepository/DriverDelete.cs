using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.DriverRepository
{
    public partial class DriverDelete
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public DriverDelete(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        public void ByPrimaryKey(int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Driver] WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByDriverId(int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Driver] WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByFirstName(string firstName)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Driver] WHERE FirstName=@FirstName;";
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByLastName(string lastName)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Driver] WHERE LastName=@LastName;";
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByCallSign(string callSign)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Driver] WHERE CallSign=@CallSign;";
                sqlCommand.Parameters.AddWithValue("@CallSign", callSign);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByIsDeleted(byte isDeleted)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Driver] WHERE IsDeleted=@IsDeleted;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
