using CadeMeuTroco.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTrocoTeste.CadeMeuTroco.Core.Mocks {

    public class ConfigurationUtilityMock : IConfigurationUtility {

        public string LogPath { get; set; }

        public string DatabaseConnection {
            get { throw new NotImplementedException(); }
        }

        public Guid AccessKey {
            get { throw new NotImplementedException(); }
        }
    }
}
