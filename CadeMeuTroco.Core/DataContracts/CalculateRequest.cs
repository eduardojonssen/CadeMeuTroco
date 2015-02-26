using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.DataContracts {

    public sealed class CalculateRequest : AbstractRequest {

        public CalculateRequest() { }

        public long ProductAmountInCents { get; set; }

        public long PaidAmountInCents { get; set; }

        protected override void Validate() {

            // Verifica se o valor pago é menor que o valor do produto.
            if (this.PaidAmountInCents < this.ProductAmountInCents) {
                this.AddReport("PaidAmountInCents", "O valor pago deve ser maior ou igual ao valor do produto.");
            }

            // Verifica se foi especificado o valor do produto.
            if (this.ProductAmountInCents <= 0) {
                this.AddReport("ProductAmountInCents", "O valor do produto deve ser maior que 0.");
            }

            // Verifica se foi especificado o valor pago.
            if (this.PaidAmountInCents <= 0) {
                this.AddReport("PaidAmountInCents", "O valor pago deve ser maior que 0.");
            }
        }
    }
}
