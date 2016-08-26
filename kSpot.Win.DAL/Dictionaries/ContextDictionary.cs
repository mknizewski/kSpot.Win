using kSpot.Win.DAL.Extensions;
using System.Configuration;

namespace kSpot.Win.DAL.Dictionaries
{
    public static class ContextDictionary
    {
        public static string kSpotConnectionString
        {
            get
            {
                var connectionStringSettings = ConfigurationManager.ConnectionStrings["kSpotCS"];
                var connectionString = connectionStringSettings.GetDecryptConnectionString();

                return connectionString;
            }
        }
    }
}
