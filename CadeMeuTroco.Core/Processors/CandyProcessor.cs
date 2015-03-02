using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Processors {
    public class CandyProcessor : AbstractProcessor {

        public CandyProcessor() {

        }

        public override List<int> GetAvailableValues() {
            return new List<int>() { 1 };
        }

        public override string GetName() {
            return "Candy";
        }
    }
}
