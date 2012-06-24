namespace projetoFinalPJS
{
    partial class buscaData
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerInicial = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinal = new System.Windows.Forms.DateTimePicker();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Final";
            // 
            // dateTimePickerInicial
            // 
            this.dateTimePickerInicial.Location = new System.Drawing.Point(12, 25);
            this.dateTimePickerInicial.Name = "dateTimePickerInicial";
            this.dateTimePickerInicial.Size = new System.Drawing.Size(260, 20);
            this.dateTimePickerInicial.TabIndex = 1;
            // 
            // dateTimePickerFinal
            // 
            this.dateTimePickerFinal.Location = new System.Drawing.Point(12, 64);
            this.dateTimePickerFinal.Name = "dateTimePickerFinal";
            this.dateTimePickerFinal.Size = new System.Drawing.Size(257, 20);
            this.dateTimePickerFinal.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(197, 108);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buscaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 143);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dateTimePickerFinal);
            this.Controls.Add(this.dateTimePickerInicial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "buscaData";
            this.ShowIcon = false;
            this.Text = "Consultar por data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicial;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinal;
        private System.Windows.Forms.Button buttonOk;
    }
}