using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.DataContracts {
    
    public sealed class CalculateResponse {

        public CalculateResponse() {
            this.ReportCollection = new List<Report>();
        }

        /// <summary>
        /// Obtém ou define a flag que indica se a operação foi concluída com sucesso.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Obtém ou define a lista de erros ocorridos durante o processamento.
        /// </summary>
        public List<Report> ReportCollection { get; set; }

        /// <summary>
        /// Obtém ou define o valor do troco calculado.
        /// </summary>
        public Nullable<long> ChangeAmount { get; set; }

        /// <summary>
        /// Dicionário com quantidade de moedas por tipo de moeda.
        /// </summary>
        public Dictionary<int, long> ChangeDictionary { get; set; }
    }
}
