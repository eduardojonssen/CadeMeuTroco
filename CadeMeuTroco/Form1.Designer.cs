namespace CadeMeuTroco {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.UxTxtProductValue = new System.Windows.Forms.TextBox();
            this.UxTxtPaidValue = new System.Windows.Forms.TextBox();
            this.UxLblProductValue = new System.Windows.Forms.Label();
            this.UxLblPaidValue = new System.Windows.Forms.Label();
            this.UxTxtResult = new System.Windows.Forms.TextBox();
            this.UxBtnResult = new System.Windows.Forms.Label();
            this.UxBtnCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UxTxtProductValue
            // 
            this.UxTxtProductValue.Location = new System.Drawing.Point(24, 44);
            this.UxTxtProductValue.Name = "UxTxtProductValue";
            this.UxTxtProductValue.Size = new System.Drawing.Size(247, 26);
            this.UxTxtProductValue.TabIndex = 0;
            // 
            // UxTxtPaidValue
            // 
            this.UxTxtPaidValue.Location = new System.Drawing.Point(24, 113);
            this.UxTxtPaidValue.Name = "UxTxtPaidValue";
            this.UxTxtPaidValue.Size = new System.Drawing.Size(247, 26);
            this.UxTxtPaidValue.TabIndex = 1;
            // 
            // UxLblProductValue
            // 
            this.UxLblProductValue.AutoSize = true;
            this.UxLblProductValue.Location = new System.Drawing.Point(28, 21);
            this.UxLblProductValue.Name = "UxLblProductValue";
            this.UxLblProductValue.Size = new System.Drawing.Size(132, 20);
            this.UxLblProductValue.TabIndex = 2;
            this.UxLblProductValue.Text = "Valor do Produto:";
            // 
            // UxLblPaidValue
            // 
            this.UxLblPaidValue.AutoSize = true;
            this.UxLblPaidValue.Location = new System.Drawing.Point(28, 90);
            this.UxLblPaidValue.Name = "UxLblPaidValue";
            this.UxLblPaidValue.Size = new System.Drawing.Size(90, 20);
            this.UxLblPaidValue.TabIndex = 3;
            this.UxLblPaidValue.Text = "Valor pago:";
            // 
            // UxTxtResult
            // 
            this.UxTxtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UxTxtResult.Location = new System.Drawing.Point(24, 188);
            this.UxTxtResult.Multiline = true;
            this.UxTxtResult.Name = "UxTxtResult";
            this.UxTxtResult.Size = new System.Drawing.Size(825, 350);
            this.UxTxtResult.TabIndex = 4;
            // 
            // UxBtnResult
            // 
            this.UxBtnResult.AutoSize = true;
            this.UxBtnResult.Location = new System.Drawing.Point(28, 165);
            this.UxBtnResult.Name = "UxBtnResult";
            this.UxBtnResult.Size = new System.Drawing.Size(86, 20);
            this.UxBtnResult.TabIndex = 5;
            this.UxBtnResult.Text = "Resultado:";
            // 
            // UxBtnCalculate
            // 
            this.UxBtnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UxBtnCalculate.Location = new System.Drawing.Point(877, 432);
            this.UxBtnCalculate.Name = "UxBtnCalculate";
            this.UxBtnCalculate.Size = new System.Drawing.Size(155, 106);
            this.UxBtnCalculate.TabIndex = 6;
            this.UxBtnCalculate.Text = "Calcular Troco!!";
            this.UxBtnCalculate.UseVisualStyleBackColor = true;
            this.UxBtnCalculate.Click += new System.EventHandler(this.UxBtnCalculate_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.UxBtnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 579);
            this.Controls.Add(this.UxBtnCalculate);
            this.Controls.Add(this.UxBtnResult);
            this.Controls.Add(this.UxTxtResult);
            this.Controls.Add(this.UxLblPaidValue);
            this.Controls.Add(this.UxLblProductValue);
            this.Controls.Add(this.UxTxtPaidValue);
            this.Controls.Add(this.UxTxtProductValue);
            this.Name = "Form1";
            this.Text = "Cade Meu Troco";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UxTxtProductValue;
        private System.Windows.Forms.TextBox UxTxtPaidValue;
        private System.Windows.Forms.Label UxLblProductValue;
        private System.Windows.Forms.Label UxLblPaidValue;
        private System.Windows.Forms.TextBox UxTxtResult;
        private System.Windows.Forms.Label UxBtnResult;
        private System.Windows.Forms.Button UxBtnCalculate;
    }
}

