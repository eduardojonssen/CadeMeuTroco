using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Repository.Entities {

    public sealed class ApplicationLogEntity {

        public ApplicationLogEntity() { }

        public string MethodName { get; set; }

        public string LogData { get; set; }

        public short CategoryTypeId { get; set; }
    }
}
