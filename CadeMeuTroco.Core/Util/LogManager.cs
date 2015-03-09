using Dlp.Framework.Container;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Util {
    public sealed class LogManager {
        public LogManager() {
            Dlp.Framework.Container.IocFactory.Register(
                       Component.For<ILog>()
                       .ImplementedBy<EventViewerLog>("EventViewerLog")
                       .ImplementedBy<DatabaseLog>("DatabaseLog").IsDefault()
                       .ImplementedBy<FileLog>("FileLog"),
                       Component.FromThisAssembly("CadeMeuTroco.Core.Repository")
                   );
        }

        public bool Save(string methodName, string logData, CategoryType categoryType) {

            bool result = false;

            ILog log = Dlp.Framework.Container.IocFactory.Resolve<ILog>();

            try {
                result = log.Save(methodName, logData, categoryType);

                if (result == false) {
                    SaveFileLog(methodName, logData, categoryType);
                }
            }
            catch (SqlException sqlException) {
                SaveFileLog(methodName, sqlException.ToString(), CategoryType.Exception);
                result = SaveFileLog(methodName, logData, categoryType);
            }
            catch (Exception ex) { }

            return result;
        }

        private bool SaveFileLog(string methodName, string logData, CategoryType categoryType) {

            ILog log = Dlp.Framework.Container.IocFactory.ResolveByName<ILog>("FileLog");
            return log.Save(methodName, logData, categoryType);

        }
    }
}
