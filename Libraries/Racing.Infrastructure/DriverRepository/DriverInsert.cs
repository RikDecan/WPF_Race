using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.DriverRepository
{
    public partial class DriverInsert
    {
        #region Properties
        private readonly SqlServerTable _table;
        #endregion

        #region Ctor
        public DriverInsert(SqlServerTable table)
        {
            this._table = table;
        }
        #endregion

        #region Methods
        public void NewRecord(Driver driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "INSERT INTO [Driver] (FirstName, LastName, CallSign, IsDeleted) VALUES (@FirstName, @LastName, @CallSign, @IsDeleted); SELECT SCOPE_IDENTITY() AS INT;";
                sqlCommand.Parameters.AddWithValue("@FirstName", driver.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", driver.LastName);
                sqlCommand.Parameters.AddWithValue("@CallSign", driver.CallSign);
                sqlCommand.Parameters.AddWithValue("@IsDeleted", driver.IsDeleted);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
