using CadeMeuTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadeMeuTroco.Core.Processors;
using CadeMeuTroco.Core.Util;
using Dlp.Framework;
using System.IO;
using System.Configuration;
using Dlp.Framework.Container;

namespace CadeMeuTroco.Core {


    public class CadeMeuTrocoManager : ICadeMeuTrocoManager {

        private ILog Log { get; set; }

        public CadeMeuTrocoManager() {

            Dlp.Framework.Container.IocFactory.Register(
                    Component.For<IConfigurationUtility>().ImplementedBy<ConfigurationUtility>()                    
                );

            IConfigurationUtility configurationUtility =
                Dlp.Framework.Container.IocFactory.Resolve<IConfigurationUtility>();

            Dlp.Framework.Container.IocFactory.Register(
                    Component.For<ILog>().ImplementedBy<EventViewerLog>().Interceptor<CadeMeuTrocoInterceptor>()
                );

            this.Log = Dlp.Framework.Container.IocFactory.Resolve<ILog>();
            //this.Log = new FileLog(configurationUtility.LogPath, "log");
        }

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
                this.Log.Save(string.Format("Nome do método: {0} | Objeto: {1} | JSON: {2}", "Calculate", "CalculateRequest", serializedRequest));

                // Verifica se todos os dados recebidos são validos.
                if (request.IsValid == false) {
                    response.ReportCollection = request.ReportCollection;
                    return response;
                }

                // Calcula o valor do troco.
                long changeAmount = request.PaidAmountInCents - request.ProductAmountInCents;

                response.ChangeCollection = CalculateEntities(changeAmount);

                response.ChangeAmount = changeAmount;

                response.Success = true;
            }
            catch (Exception ex) {

                this.Log.Save(string.Format("Erro: {0} | Nome do método: {1} | Objeto: {2} | JSON: {3}", ex.ToString(), "Calculate", "CalculateRequest", serializedRequest));

                Report report = new Report();

                report.Field = null;
                report.Message = "Ocorreu um erro ao processar sua requisição. Por favor, tente novamente mais tarde.";

                response.ReportCollection.Add(report);
            }
            finally {

                string serializedResponse = Serializer.JsonSerialize(response);
                this.Log.Save(string.Format("Nome do método: {0} | Objeto: {1} | JSON: {2}", "Calculate", "CalculateResponse", serializedResponse));
            }

            return response;
        }

        private List<ChangeData> CalculateEntities(long changeAmount) {

            long changeRest = changeAmount;

            List<ChangeData> changeDataCollection = new List<ChangeData>();

            while (changeRest > 0) {

                ChangeData currentData = new ChangeData();

                AbstractProcessor proc = ProcessorFactory.CreateProcessor(changeRest);
                Dictionary<int, long> monetaryObjs = proc.CalculateChange(changeRest);

                currentData.Name = proc.GetName();
                currentData.ChangeDictionary = monetaryObjs.Where(p => p.Value > 0).ToDictionary(p => p.Key, p => p.Value);

                foreach (KeyValuePair<int, long> kvPair in monetaryObjs) {

                    changeRest = changeRest - kvPair.Key * kvPair.Value;
                }

                changeDataCollection.Add(currentData);
            }

            return changeDataCollection;
        }
    }
}
