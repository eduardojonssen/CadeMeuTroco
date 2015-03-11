using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadeMeuTroco.Core;
using CadeMeuTroco.Core.DataContracts;
using CadeMeuTroco.Core.Repository.Entities;
using CadeMeuTroco.Core.Util;

namespace CadeMeuTroco {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void UxBtnCalculate_Click(object sender, EventArgs e) {

            this.Calculate();
        }

        private void Calculate() {
            this.UxTxtProcessorResult.Clear();
            this.UxTxtResult.Clear();
                      

            long productAmount = Convert.ToInt64(this.UxTxtProductValue.Text);
            long paidAmount = Convert.ToInt64(this.UxTxtPaidValue.Text);

            CadeMeuTrocoManager manager = new CadeMeuTrocoManager();

            manager.OnProcessorExecuted += manager_OnProcessorExecuted;

            CalculateRequest request = new CalculateRequest();

            request.PaidAmountInCents = paidAmount;
            request.ProductAmountInCents = productAmount;


            ILog log = new FileLog();

            log.Save("Calculate", "IT'S DONE MOTHERFUCKER!", CategoryType.Exception);

            CalculateResponse response = manager.Calculate(request);

            if (response.Success == false) {

                StringBuilder stringBuilder = new StringBuilder();

                foreach (Report report in response.ReportCollection) {

                    stringBuilder.AppendLine(string.Format("{0}: {1}", report.Field, report.Message));
                }

                this.UxTxtResult.Text = stringBuilder.ToString();
            }
            else {

                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine(string.Format("Valor total: {0}", response.ChangeAmount.Value));

                //Percorre a lista de moedas e exibe a resposta 
                foreach (ChangeData data in response.ChangeCollection) {
                    foreach(KeyValuePair<int,long> change in data.ChangeDictionary.Where(p => p.Value > 0) ) {
                        stringBuilder.AppendLine(string.Format("{0}: {1} | Quantidade: {2}", data.Name, change.Key, change.Value));
                    }
                    
                }

                this.UxTxtResult.Text = stringBuilder.ToString();
            }
        }

        void manager_OnProcessorExecuted(object sender, string name, long change) {
            string appendedText = string.Format("Nome: {0} | Troco: {1}\r\n", name, change);
            this.UxTxtProcessorResult.AppendText(appendedText);
        }
    }
}
