using CadeMeuTroco.Core.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Repository {

    public interface IApplicationLogRepository {

        bool Insert(ApplicationLogEntity entity);
    }
}
