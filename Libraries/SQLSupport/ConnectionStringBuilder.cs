using System.Configuration.Internal;

namespace Ado.Data.SqlServer
{
    public class ConnectionStringBuilder
    {
        private string _connectionStringName;

        public string MasterConnectionString
        {
            get
            {
                if (IntegratedSecurity)
                    return $"data source={DataSource};initial catalog=master;integrated security={IntegratedSecurity};";
                return $"data source={DataSource};initial catalog=master;persist security info=True;user id={UserId};password={Password};";
            }
        }
        public string DataSource { get; set; }
        public string DatabaseName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        public string _connectionString;

        public string ConnectionString
        {
            get
            {
                {
                    if (string.IsNullOrEmpty(_connectionStringName))
                    {
                        if (!string.IsNullOrEmpty(_connectionString))
                        {
                            return _connectionString;
                        }
                        throw new ArgumentException("Connection string must not empty.");
                    } else if (!string.IsNullOrEmpty(_connectionStringName))
                    {
                        var connectionStringObject = System.Configuration.ConfigurationManager.ConnectionStrings[_connectionStringName];
                        if (connectionStringObject == null)
                            throw new ArgumentException($"Connection string named '{_connectionStringName}' not found");
                        return connectionStringObject.ConnectionString;
                    }

                    if (IntegratedSecurity)
                        return $"data source={DataSource};initial catalog={DatabaseName};integrated security={IntegratedSecurity};";
                    return $"data source={DataSource};initial catalog={DatabaseName};persist security info=True;user id={UserId};password={Password};";
                }
            }

            set { _connectionString = value; }
        }

        public ConnectionStringBuilder(string dataSource, string databaseName, string userId, string password, bool integratedSecurity = true)
        {
            DataSource = dataSource;
            DatabaseName = databaseName;
            UserId = userId;
            Password = password;
            IntegratedSecurity = integratedSecurity;
        }

        public ConnectionStringBuilder() { }

        public ConnectionStringBuilder(string connectionStringName)
        {
            this._connectionStringName = connectionStringName;
        }
    }
}
