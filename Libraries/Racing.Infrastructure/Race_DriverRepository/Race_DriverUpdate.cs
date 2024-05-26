using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.Race_DriverRepository
{
    public partial class Race_DriverUpdate
    {
        private readonly SqlServerTable _table;

        public Race_DriverUpdate(SqlServerTable table)
        {
            this._table = table;
        }

        private void SetSqlCommandParameter(SqlCommand sqlCommand, Race_Driver race_driver)
        {
            sqlCommand.Parameters.AddWithValue("@RaceId", race_driver.RaceId);
            sqlCommand.Parameters.AddWithValue("@DriverId", race_driver.DriverId);
            sqlCommand.Parameters.AddWithValue("@IsDeleted", race_driver.IsDeleted);
        }

        public void ByPrimaryKey(Race_Driver race_driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race_Driver] SET IsDeleted=@IsDeleted WHERE RaceId=@RaceId AND DriverId=@DriverId;";
                SetSqlCommandParameter(sqlCommand, race_driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByRaceId(Race_Driver race_driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race_Driver] SET IsDeleted=@IsDeleted WHERE RaceId=@RaceId;";
                SetSqlCommandParameter(sqlCommand, race_driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByDriverId(Race_Driver race_driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race_Driver] SET IsDeleted=@IsDeleted WHERE DriverId=@DriverId;";
                SetSqlCommandParameter(sqlCommand, race_driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void ByIsDeleted(Race_Driver race_driver)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race_Driver] SET IsDeleted=@IsDeleted WHERE IsDeleted=@IsDeleted;";
                SetSqlCommandParameter(sqlCommand, race_driver);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public void IsDeletedByPrimaryKey(byte isDeleted, int raceId, int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "UPDATE [Race_Driver] SET IsDeleted=@IsDeleted WHERE RaceId=@RaceId AND DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isDeleted);
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
    }
}
