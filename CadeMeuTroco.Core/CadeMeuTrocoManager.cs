using CadeMeuTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core {

    public class CadeMeuTrocoManager {

        /// <summary>
        /// Moedas disponiveis na maquina.
        /// </summary>
        public List<int> AvailableCoins = new List<int>() { 100, 50, 25, 10, 5, 1 };

        /// <summary>
        /// Calcula o valor do troco.
        /// </summary>
        /// <param name="productValue">Valor do produto</param>
        /// <param name="paidAmountInCents">Valor pago pelo produto</param>
        /// <returns></returns>
        public CalculateResponse Calculate(CalculateRequest request) {

            CalculateResponse response = new CalculateResponse();

            try {
                // Verifica se todos os dados recebidos são validos.
                if (request.IsValid == false) {
                    response.ReportCollection = request.ReportCollection;
                    return response;
                }

                // Calcula o valor do troco.
                long changeAmount = request.PaidAmountInCents - request.ProductAmountInCents;

                response.ChangeAmount = changeAmount;

                //Calcula o número de moedas de cada valor que serão retornadas como troco.
                response.CoinDictionary = this.CalculateCoins(changeAmount);

                response.Success = true;
            }
            catch (Exception ex) {

                // TODO: Log da exceção.

                Report report = new Report();

                report.Field = null;
                report.Message = "Ocorreu um erro ao processar sua requisição. Por favor, tente novamente mais tarde.";

                response.ReportCollection.Add(report);
            }

            return response;
        }

        /// <summary>
        /// Calcula a quantidade de moedas para o troco.
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, long> CalculateCoins(long changeAmountInCents) {

            //Dicionário para guardar o número de moedas de cada valor
            Dictionary<int, long> response= new Dictionary<int,long>();

            //Valor atual do troco após cada iteração
            long currentChange = changeAmountInCents;

            foreach (int coin in this.AvailableCoins.OrderByDescending(p => p)) {

                //Numero de moedas para o valor atual
                long numberOfCoins = currentChange/coin;

                //Guarda o resto desta divisão para a próxima iteração
                currentChange = currentChange % coin;

                //Adiciona ao dicionário o número de moedas deste valor
                response.Add(coin, numberOfCoins);
            }

            return response;
        }
    }
}
