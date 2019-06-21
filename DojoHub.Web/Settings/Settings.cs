using System;
using System.Configuration;

namespace DojoHub.Web.Settings
{
    public static class Settings
    {
        public static string WebpackDevServerRoot => ConfigurationManager.AppSettings["WebpackDevServerRoot"];
        public static bool UseWebpackDevServer => "true".Equals(ConfigurationManager.AppSettings["UseWebpackDevServer"], StringComparison.InvariantCultureIgnoreCase);
    }
}