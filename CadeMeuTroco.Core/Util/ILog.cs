﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Util {

    public interface ILog {

        bool Save(string methodName, string logData, CategoryType categoryType);
    }
}
