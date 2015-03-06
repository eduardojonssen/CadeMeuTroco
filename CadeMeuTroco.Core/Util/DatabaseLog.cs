using CadeMeuTroco.Core.Repository;
using CadeMeuTroco.Core.Repository.Entities;
using Dlp.Framework.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Util {

    public class DatabaseLog : ILog {

        public bool Save(string methodName, string logData, CategoryType categoryType) {

            IApplicationLogRepository repository = IocFactory.Resolve<IApplicationLogRepository>();

            ApplicationLogEntity entity = new ApplicationLogEntity();

            entity.CategoryTypeId = (short)categoryType;
            entity.LogData = logData;
            entity.MethodName = methodName;

            return repository.Insert(entity);
        }
    }
}
