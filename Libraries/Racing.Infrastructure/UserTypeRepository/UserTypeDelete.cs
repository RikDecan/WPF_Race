using Ado.Data.SqlServer;
using System.Data.SqlClient;

namespace Races.Db.UserTypeRepository
{
    public partial class UserTypeDelete
    {
        private SqlServerTable table;
        public UserTypeDelete(SqlServerTable table)
        {
            this.table = table;
        }
        public virtual void ByPrimaryKey(int usertypeid)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "DELETE [UserType] WHERE UserTypeId=@UserTypeId;";
                sqlCommand.Parameters.AddWithValue("@UserTypeId", usertypeid);
                table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByUserTypeId(int usertypeid)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "DELETE [UserType] WHERE UserTypeId=@UserTypeId;";
                sqlCommand.Parameters.AddWithValue("@UserTypeId", usertypeid);
                table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByName(string name)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "DELETE [UserType] WHERE Name=@Name;";
                sqlCommand.Parameters.AddWithValue("@Name", name);
                table.DbAccess.Commands.Add(sqlCommand);
            }
        }
        public virtual void ByIsDeleted(byte isdeleted)
        {
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = "DELETE [UserType] WHERE IsDeleted=@IsDeleted;";
                sqlCommand.Parameters.AddWithValue("@IsDeleted", isdeleted);
                table.DbAccess.Commands.Add(sqlCommand);
            }
        }
    }
}
