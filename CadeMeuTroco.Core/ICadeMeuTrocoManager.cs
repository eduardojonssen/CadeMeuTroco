using CadeMeuTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core {

    public interface ICadeMeuTrocoManager {

        CalculateResponse Calculate(CalculateRequest request);
    }
}
