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

namespace CadeMeuTroco {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void UxBtnCalculate_Click(object sender, EventArgs e) {

            this.Calculate();
        }

        private void Calculate() {

            long productAmount = Convert.ToInt64(this.UxTxtProductValue.Text);
            long paidAmount = Convert.ToInt64(this.UxTxtPaidValue.Text);

            CadeMeuTrocoManager manager = new CadeMeuTrocoManager();

            CalculateRequest request = new CalculateRequest();

            request.PaidAmountInCents = paidAmount;
            request.ProductAmountInCents = productAmount;

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
                foreach (KeyValuePair<int, long> coin in response.CoinDictionary) {
                    stringBuilder.AppendLine(string.Format("Moeda: {0} | Quantidade: {1}", coin.Key, coin.Value));
                }

                this.UxTxtResult.Text = stringBuilder.ToString();
            }
        }
    }
}
