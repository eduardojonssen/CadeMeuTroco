using CadeMeuTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadeMeuTroco.Core.Processors;

namespace CadeMeuTroco.Core {

    public class CadeMeuTrocoManager {

        public List<int> AvailableBills = new List<int>() { 10000, 5000, 2000, 1000, 500, 200 };

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

                // TODO: Precisamos chamar processador, caso o troco seja zero?

                // TODO: Chamar o factory para obter o processador a ser utilizado.

                // TODO: Chamar o metodo calculate do processador e obter o troco calculado.

                // TODO: Subtrair o troco retornado pelo processador do troco original a ser retornado.

                // TODO: Caso o troco seja maior que zero, devemos voltar para a primeira etapa.

                Dictionary<int, long> change = new Dictionary<int, long>();
                long changeRest = changeAmount;
                while (changeRest > 0)
                {
                    AbstractProcessor proc = ProcessorFactory.CreateProcessor(changeRest);
                    Dictionary<int, long> monetaryObjs = proc.CalculateChange(changeRest);

                    foreach (KeyValuePair<int, long> kvPair in monetaryObjs) {

                        change.Add(kvPair.Key, kvPair.Value);
                        changeRest = changeRest - kvPair.Key * kvPair.Value;
                    }
                    
                    // TODO: calcular o troco restante.


                }
                
                response.ChangeAmount = changeAmount;
                response.ChangeDictionary = change;

                //Calcula o número de moedas de cada valor que serão retornadas como troco.
                //response.CoinDictionary = this.CalculateCoins(changeAmount);

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
    }
}
