using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Model
{
    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetProviderServices(MySqlProviderInvariantName.ProviderName, new MySqlProviderServices());
            SetDefaultConnectionFactory(new MySqlConnectionFactory());
        }
    }
} 