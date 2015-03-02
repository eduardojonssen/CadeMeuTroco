using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.DataContracts {

    public sealed class ChangeData {

        public ChangeData() {
            this.ChangeDictionary = new Dictionary<int, long>();
        }

        public string Name { get; set; }

        public Dictionary<int, long> ChangeDictionary { get; set; }
    }
}
