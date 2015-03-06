using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Util {
    public class ConfigurationUtility : IConfigurationUtility {

        public string LogPath {
            get { return ConfigurationManager.AppSettings["LogPath"]; }
        }

        public string DatabaseConnection {
            get { return ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString; }
        }

        public Guid AccessKey {
            get { return Guid.Parse(ConfigurationManager.AppSettings["AccessKey"]); }
        }
    }
}
