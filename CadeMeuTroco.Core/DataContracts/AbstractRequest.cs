using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.DataContracts {

    public abstract class AbstractRequest {

        protected AbstractRequest() {
            this.ActualReportCollection = new List<Report>();
        }

        public bool IsValid {
            get {
                this.Validate();
                return (this.ReportCollection.Any() == false);
            }
        }

        internal List<Report> ReportCollection { get { return this.ActualReportCollection.ToList(); } }

        private List<Report> ActualReportCollection { get; set; }

        public void AddReport(string field, string message) {

            string typeName = this.GetType().Name;

            Report report = new Report();

            if (field.StartsWith(typeName) == true) { report.Field = field; }
            else { report.Field = string.Format("{0}.{1}", typeName, field); }

            report.Message = message;

            this.ActualReportCollection.Add(report);
        }

        /// <summary>
        /// Método abstrato de validação que deverá ser implementado por cada classe de request.
        /// </summary>
        protected abstract void Validate();
    }
}
