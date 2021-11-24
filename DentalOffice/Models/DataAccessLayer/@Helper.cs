using System.Configuration;
using System.Data.SqlClient;

namespace DentalOffice.Models.DataAccesslayer
{
    public static class Helper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        internal static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

    }
}