using CadeMeuTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadeMeuTroco.Core.Processors;
using CadeMeuTroco.Core.Util;
using Dlp.Framework;

namespace CadeMeuTroco.Core {

    public class CadeMeuTrocoManager {

        private ILog log = new FileLog(@"C:\Logs", "log");

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
            string serializedRequest = Serializer.JsonSerialize(request);
            try {
                this.log.Log(string.Format("Nome do método: {0} | Objeto: {1} | JSON: {2}", "Calculate", "CalculateRequest", serializedRequest));

                // Verifica se todos os dados recebidos são validos.
                if (request.IsValid == false) {
                    response.ReportCollection = request.ReportCollection;
                    return response;
                }

                // Calcula o valor do troco.
                long changeAmount = request.PaidAmountInCents - request.ProductAmountInCents;

                long changeRest = changeAmount;

                while (changeRest > 0) {

                    ChangeData currentData = new ChangeData();

                    AbstractProcessor proc = ProcessorFactory.CreateProcessor(changeRest);
                    Dictionary<int, long> monetaryObjs = proc.CalculateChange(changeRest);

                    currentData.Name = proc.GetName();
                    currentData.ChangeDictionary = monetaryObjs;

                    foreach (KeyValuePair<int, long> kvPair in monetaryObjs) {

                        changeRest = changeRest - kvPair.Key * kvPair.Value;
                    }

                    response.ChangeCollection.Add(currentData);
                }

                response.ChangeAmount = changeAmount;

                response.Success = true;
            }
            catch (Exception ex) {

                this.log.Log(string.Format("Erro: {0} | Nome do método: {1} | Objeto: {2} | JSON: {3}", ex.ToString(), "Calculate", "CalculateRequest", serializedRequest));

                Report report = new Report();

                report.Field = null;
                report.Message = "Ocorreu um erro ao processar sua requisição. Por favor, tente novamente mais tarde.";

                response.ReportCollection.Add(report);
            }

            return response;
        }
    }
}
