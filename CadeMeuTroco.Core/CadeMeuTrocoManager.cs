﻿using CadeMeuTroco.Core.DataContracts;
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

    public delegate void ProcessorExecutedEventHandler(object sender, string name, long change);

    public class CadeMeuTrocoManager : ICadeMeuTrocoManager {

        private ILog Log { get; set; }
        private LogManager LogManager { get; set; }

        public event ProcessorExecutedEventHandler OnProcessorExecuted;

        public CadeMeuTrocoManager() {
            this.LogManager = new LogManager();

            Dlp.Framework.Container.IocFactory.Register(
                    Component.For<IConfigurationUtility>().ImplementedBy<ConfigurationUtility>()
                );

            IConfigurationUtility configurationUtility =
                Dlp.Framework.Container.IocFactory.Resolve<IConfigurationUtility>();

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
                
                this.LogManager.Save("Calculate", string.Format("Nome do método: {0} | Objeto: {1} | JSON: {2}", "Calculate", "CalculateRequest", serializedRequest), CategoryType.Request);

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

                this.LogManager.Save("Calculate", string.Format("Erro: {0} | Nome do método: {1} | Objeto: {2} | JSON: {3}", ex.ToString(), "Calculate", "CalculateRequest", serializedRequest), CategoryType.Exception);

                Report report = new Report();

                report.Field = null;
                report.Message = "Ocorreu um erro ao processar sua requisição. Por favor, tente novamente mais tarde.";

                response.ReportCollection.Add(report);
            }
            finally {

                string serializedResponse = Serializer.JsonSerialize(response);
                this.LogManager.Save("Calculate", string.Format("Nome do método: {0} | Objeto: {1} | JSON: {2}", "Calculate", "CalculateResponse", serializedResponse), CategoryType.Response);
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

                long currentProduct = monetaryObjs.Sum(p => p.Key * p.Value);

                changeRest = changeRest - currentProduct;

                changeDataCollection.Add(currentData);

                // Dispara o evento informando que um processador foi executado.
                if (this.OnProcessorExecuted != null) {
                    string nameProcessor = proc.GetName();

                    this.OnProcessorExecuted(this, nameProcessor, currentProduct);
                }
            }

            return changeDataCollection;
        }
    }
}
