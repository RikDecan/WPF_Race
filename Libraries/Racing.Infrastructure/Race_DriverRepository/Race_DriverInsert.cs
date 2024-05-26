using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.Race_DriverRepository
{
    public partial class Race_DriverInsert
    {
        private readonly SqlServerTable _table;
        public Race_DriverInsert(SqlServerTable table)
        {
            this._table = table;
        }

        public virtual void NewRecord(Race_Driver race_driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "INSERT INTO [Race_Driver] (RaceId, DriverId, IsDeleted) VALUES (@RaceId, @DriverId, @IsDeleted); SELECT SCOPE_IDENTITY() AS INT;";
                sqlCommand.Parameters.AddWithValue("@RaceId", race_driver.RaceId);
                sqlCommand.Parameters.AddWithValue("@DriverId", race_driver.DriverId);
                sqlCommand.Parameters.AddWithValue("@IsDeleted", race_driver.IsDeleted);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
    }
}
