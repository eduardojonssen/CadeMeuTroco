using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Processors {
    public abstract class AbstractProcessor {

        public AbstractProcessor() { }

        /// <summary>
        /// Retorna a lista de valores disponíveis
        /// </summary>
        /// <returns></returns>
        public abstract List<int> GetAvailableValues();

        /// <summary>
        /// Retorna um dicionario com a quantidade de moedas ou notas de cada tipo que serão retornadas
        /// </summary>
        /// <param name="changeAmountInCents"></param>
        /// <returns></returns>
        public Dictionary<int, long> CalculateChange(long changeAmountInCents) {

            //Dicionário para guardar o número de moedas de cada valor
            Dictionary<int, long> response = new Dictionary<int, long>();

            //Valor atual do troco após cada iteração
            long currentChange = changeAmountInCents;

            foreach (int coin in this.GetAvailableValues().OrderByDescending(p => p)) {

                //Numero de moedas para o valor atual
                long numberOfCoins = currentChange / coin;

                //Guarda o resto desta divisão para a próxima iteração
                currentChange = currentChange % coin;

                //Adiciona ao dicionário o número de moedas deste valor
                response.Add(coin, numberOfCoins);
            }

            return response;
        }
    }
}
