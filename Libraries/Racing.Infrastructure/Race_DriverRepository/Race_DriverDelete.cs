using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.Race_DriverRepository
{
    public partial class Race_DriverDelete
    {
        private readonly SqlServerTable _table;

        public Race_DriverDelete(SqlServerTable table)
        {
            this._table = table;
        }

        public void ByPrimaryKey(int raceId, int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race_Driver] WHERE RaceId=@RaceId AND DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByRaceId(int raceId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race_Driver] WHERE RaceId=@RaceId;";
                sqlCommand.Parameters.AddWithValue("@RaceId", raceId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByDriverId(int driverId)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race_Driver] WHERE DriverId=@DriverId;";
                sqlCommand.Parameters.AddWithValue("@DriverId", driverId);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }

        public void ByIsDeleted(byte isdeleted)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "DELETE [Race_Driver] WHERE IsDeleted=@IsDeleted;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isdeleted);
                _table.DbAccess.Commands.Add(sqlCommand);
            }
        }
    }
}
