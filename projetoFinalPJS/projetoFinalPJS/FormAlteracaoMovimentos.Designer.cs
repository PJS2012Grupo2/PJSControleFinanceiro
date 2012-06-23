namespace projetoFinalPJS
{
    partial class FormAlteracaoMovimentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.tbSaldo = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDescrição = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.alterar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Items.AddRange(new object[] {
            "Sem Categoria"});
            this.cbCategoria.Location = new System.Drawing.Point(15, 103);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(158, 21);
            this.cbCategoria.TabIndex = 37;
            // 
            // tbSaldo
            // 
            this.tbSaldo.Location = new System.Drawing.Point(15, 25);
            this.tbSaldo.Name = "tbSaldo";
            this.tbSaldo.Size = new System.Drawing.Size(158, 20);
            this.tbSaldo.TabIndex = 36;
            // 
            // dtpData
            // 
            this.dtpData.CustomFormat = "yyyy/dd/MM";
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(179, 143);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(104, 20);
            this.dtpData.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Data";
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(15, 143);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(158, 20);
            this.tbValor.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Descrição";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Categoria";
            // 
            // tbDescrição
            // 
            this.tbDescrição.Location = new System.Drawing.Point(15, 64);
            this.tbDescrição.Name = "tbDescrição";
            this.tbDescrição.Size = new System.Drawing.Size(268, 20);
            this.tbDescrição.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Saldo Atual";
            // 
            // alterar
            // 
            this.alterar.Location = new System.Drawing.Point(208, 201);
            this.alterar.Name = "alterar";
            this.alterar.Size = new System.Drawing.Size(75, 23);
            this.alterar.TabIndex = 38;
            this.alterar.Text = "Alterar";
            this.alterar.UseVisualStyleBackColor = true;
            this.alterar.Click += new System.EventHandler(this.alterar_Click);
            // 
            // FormAlteracaoMovimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 236);
            this.Controls.Add(this.alterar);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.tbSaldo);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDescrição);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormAlteracaoMovimentos";
            this.Text = "FormAlteracaoMovimentos";
            this.Load += new System.EventHandler(this.FormAlteracaoMovimentos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.TextBox tbSaldo;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDescrição;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button alterar;
    }
}