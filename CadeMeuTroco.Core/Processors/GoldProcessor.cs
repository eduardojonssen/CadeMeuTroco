using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Processors {
    public class GoldProcessor : AbstractProcessor {

        public GoldProcessor() {

        }
        public override List<int> GetAvailableValues() {
            return new List<int>() { 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000 };
        }

        public override string GetName() {
            return "Gold";
        }
    }
}
