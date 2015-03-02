using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Processors {
    class BillProcessor : AbstractProcessor {

        /// <summary>
        /// Retorna a lista de valores de notas disponíveis
        /// </summary>
        /// <returns></returns>
        public override List<int> GetAvailableValues() {
            return new List<int>() { 10000, 5000, 2000, 1000, 500, 200 };
        }


        public override string GetName() {
            return "Bill";
        }
    }
}
