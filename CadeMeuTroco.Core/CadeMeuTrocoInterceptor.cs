using Dlp.Framework.Container.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core {
    
    internal class CadeMeuTrocoInterceptor : IInterceptor {
        public void AfterCall(IInterceptorOutput interceptorOutput, object correlationState) {
            ;
        }

        public object BeforeCall(IInterceptorInput interceptorInput) {
            return DateTime.Now;
        }
    }
}
