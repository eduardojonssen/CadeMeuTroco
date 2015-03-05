using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Util {

    public sealed class EventViewerLog : ILog {

        public bool Save(string data) {

            try {

                EventLog eventLog = new EventLog();
                eventLog.Source = "CadeMeuTroco";

                eventLog.WriteEntry(data, EventLogEntryType.Information);

                return true;
            }
            catch (Exception ex) {
                // TODO: logar no arquivo
                return false;
            }
        }
    }
}
