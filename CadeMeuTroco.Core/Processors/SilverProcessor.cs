using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Processors {
    public class SilverProcessor : AbstractProcessor {
        public SilverProcessor() {

        }

        public override List<int> GetAvailableValues() {
            return new List<int>() { 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000 };
        }

        public override string GetName() {
            return "Silver";
        }
    }
}
