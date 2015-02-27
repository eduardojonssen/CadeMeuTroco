using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Processors {

    public static class ProcessorFactory {

        /// <summary>
        /// Cria um novo processor baseado no valor do troco
        /// </summary>
        /// <param name="amountInCents"></param>
        /// <returns></returns>
        public static AbstractProcessor CreateProcessor(long changeAmountInCents) {

            List<AbstractProcessor> processorCollection = new List<AbstractProcessor>() {
            
                new BillProcessor(),
                new CoinProcessor()

                // Adicione novos processadores acima desta linha.
            };

            // Ordena os processadores com base no menor valor disponível, do maior para o menor.
            IEnumerable<AbstractProcessor> orderedProcessors = processorCollection
                .OrderByDescending(p => p.GetAvailableValues().Min());

            // Analisa cada processador e seleciona o mais adequado para processar o valor do troco.
            foreach (AbstractProcessor processor in orderedProcessors) {

                if (processor.GetAvailableValues().Min() < changeAmountInCents) {

                    return processor;
                }
            }

            return null;
        }
    }
}
