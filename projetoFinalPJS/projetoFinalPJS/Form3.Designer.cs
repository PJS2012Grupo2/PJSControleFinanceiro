﻿namespace projetoFinalPJS
{
    partial class Form_Categoria
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
            this.tbDescriçãoCtg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOrçamentoCtg = new System.Windows.Forms.TextBox();
            this.salvarCtg = new System.Windows.Forms.Button();
            this.labelMensagem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDescriçãoCtg
            // 
            this.tbDescriçãoCtg.Location = new System.Drawing.Point(12, 25);
            this.tbDescriçãoCtg.Name = "tbDescriçãoCtg";
            this.tbDescriçãoCtg.Size = new System.Drawing.Size(192, 20);
            this.tbDescriçãoCtg.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Limite";
            // 
            // tbOrçamentoCtg
            // 
            this.tbOrçamentoCtg.Location = new System.Drawing.Point(12, 64);
            this.tbOrçamentoCtg.Name = "tbOrçamentoCtg";
            this.tbOrçamentoCtg.Size = new System.Drawing.Size(192, 20);
            this.tbOrçamentoCtg.TabIndex = 7;
            // 
            // salvarCtg
            // 
            this.salvarCtg.Location = new System.Drawing.Point(129, 90);
            this.salvarCtg.Name = "salvarCtg";
            this.salvarCtg.Size = new System.Drawing.Size(75, 23);
            this.salvarCtg.TabIndex = 8;
            this.salvarCtg.Text = "Salvar";
            this.salvarCtg.UseVisualStyleBackColor = true;
            this.salvarCtg.Click += new System.EventHandler(this.salvarCtg_Click);
            // 
            // labelMensagem
            // 
            this.labelMensagem.AutoSize = true;
            this.labelMensagem.ForeColor = System.Drawing.Color.Red;
            this.labelMensagem.Location = new System.Drawing.Point(12, 126);
            this.labelMensagem.Name = "labelMensagem";
            this.labelMensagem.Size = new System.Drawing.Size(0, 13);
            this.labelMensagem.TabIndex = 9;
            // 
            // Form_Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 168);
            this.Controls.Add(this.labelMensagem);
            this.Controls.Add(this.salvarCtg);
            this.Controls.Add(this.tbOrçamentoCtg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDescriçãoCtg);
            this.Name = "Form_Categoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDescriçãoCtg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOrçamentoCtg;
        private System.Windows.Forms.Button salvarCtg;
        private System.Windows.Forms.Label labelMensagem;
    }
}