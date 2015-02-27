using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Processors {
    class CoinProcessor : AbstractProcessor {

        
        /// <summary>
        /// Retorna a lista de moedas disponíveis
        /// </summary>
        /// <returns></returns>
        public override List<int> GetAvailableValues() {
            return new List<int>() { 100, 50, 25, 10, 5, 1 };
        }
    }
}
