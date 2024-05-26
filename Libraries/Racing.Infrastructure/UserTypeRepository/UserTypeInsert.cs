using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.UserTypeRepository
{
    public partial class UserTypeInsert
    {
        #region Properties
        private SqlServerTable table;
        #endregion

        #region Ctor
        public UserTypeInsert(SqlServerTable table)
        {
            this.table = table;
        }
        #endregion

        #region Methods
        public virtual void NewRecord(UserType usertype)
        {
            using (SqlCommand sqlCommand = new())
            {
                sqlCommand.CommandText = "INSERT INTO [UserType] (Name, IsDeleted) VALUES (@Name, @IsDeleted); SELECT SCOPE_IDENTITY() AS INT;";
                sqlCommand.Parameters.AddWithValue("@Name", usertype.Name);
                sqlCommand.Parameters.AddWithValue("@IsDeleted", usertype.IsDeleted);
                table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        #endregion
    }
}
