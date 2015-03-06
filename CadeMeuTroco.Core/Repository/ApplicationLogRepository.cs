using CadeMeuTroco.Core.Repository.Entities;
using CadeMeuTroco.Core.Util;
using Dlp.Connectors;
using Dlp.Framework.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Repository {

    public sealed class ApplicationLogRepository : IApplicationLogRepository {

        public bool Insert(ApplicationLogEntity entity) {

            string query = @"INSERT INTO ApplicationLog (CategoryTypeId, MethodName, LogData)
                             VALUES (@CategoryTypeId, @MethodName, @LogData);";

            IConfigurationUtility utility = IocFactory.Resolve<IConfigurationUtility>();

            using (DatabaseConnector databaseConnector = new DatabaseConnector(utility.DatabaseConnection)) {

                return (databaseConnector.ExecuteNonQuery(query, entity) > 0);
            }
        }
    }
}
