namespace projetoFinalPJS
{
    partial class Form_Relatorios
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
            this.listViewInformacoes = new System.Windows.Forms.ListView();
            this.lbExibir = new System.Windows.Forms.Label();
            this.lbPara = new System.Windows.Forms.Label();
            this.cbCampo = new System.Windows.Forms.ComboBox();
            this.lbVer = new System.Windows.Forms.Label();
            this.cbInformacoes = new System.Windows.Forms.ComboBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShapeDivisao = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lbFiltrarData = new System.Windows.Forms.Label();
            this.lbFiltroDe = new System.Windows.Forms.Label();
            this.dtpFiltroDe = new System.Windows.Forms.DateTimePicker();
            this.dtpFiltroAte = new System.Windows.Forms.DateTimePicker();
            this.lbFiltroAte = new System.Windows.Forms.Label();
            this.columnDespesa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSaldo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnResultado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewInformacoes
            // 
            this.listViewInformacoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnResultado,
            this.columnDespesa,
            this.columnRenda,
            this.columnSaldo});
            this.listViewInformacoes.Location = new System.Drawing.Point(189, 12);
            this.listViewInformacoes.Name = "listViewInformacoes";
            this.listViewInformacoes.Size = new System.Drawing.Size(474, 396);
            this.listViewInformacoes.TabIndex = 0;
            this.listViewInformacoes.UseCompatibleStateImageBehavior = false;
            this.listViewInformacoes.View = System.Windows.Forms.View.Details;
            // 
            // lbExibir
            // 
            this.lbExibir.AutoSize = true;
            this.lbExibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExibir.Location = new System.Drawing.Point(12, 12);
            this.lbExibir.Name = "lbExibir";
            this.lbExibir.Size = new System.Drawing.Size(38, 13);
            this.lbExibir.TabIndex = 1;
            this.lbExibir.Text = "Exibir";
            // 
            // lbPara
            // 
            this.lbPara.AutoSize = true;
            this.lbPara.Location = new System.Drawing.Point(12, 36);
            this.lbPara.Name = "lbPara";
            this.lbPara.Size = new System.Drawing.Size(32, 13);
            this.lbPara.TabIndex = 2;
            this.lbPara.Text = "Para:";
            // 
            // cbCampo
            // 
            this.cbCampo.FormattingEnabled = true;
            this.cbCampo.Items.AddRange(new object[] {
            "Categoria",
            "Semana",
            "Mês",
            "Ano"});
            this.cbCampo.Location = new System.Drawing.Point(50, 33);
            this.cbCampo.Name = "cbCampo";
            this.cbCampo.Size = new System.Drawing.Size(133, 21);
            this.cbCampo.TabIndex = 3;
            // 
            // lbVer
            // 
            this.lbVer.AutoSize = true;
            this.lbVer.Location = new System.Drawing.Point(12, 63);
            this.lbVer.Name = "lbVer";
            this.lbVer.Size = new System.Drawing.Size(26, 13);
            this.lbVer.TabIndex = 4;
            this.lbVer.Text = "Ver:";
            // 
            // cbInformacoes
            // 
            this.cbInformacoes.FormattingEnabled = true;
            this.cbInformacoes.Items.AddRange(new object[] {
            "Gastos e Rendas",
            "Despesa",
            "Saldo"});
            this.cbInformacoes.Location = new System.Drawing.Point(50, 60);
            this.cbInformacoes.Name = "cbInformacoes";
            this.cbInformacoes.Size = new System.Drawing.Size(133, 21);
            this.cbInformacoes.TabIndex = 5;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShapeDivisao});
            this.shapeContainer1.Size = new System.Drawing.Size(675, 420);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShapeDivisao
            // 
            this.lineShapeDivisao.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.lineShapeDivisao.Name = "lineShapeDivisao";
            this.lineShapeDivisao.X1 = 15;
            this.lineShapeDivisao.X2 = 181;
            this.lineShapeDivisao.Y1 = 95;
            this.lineShapeDivisao.Y2 = 95;
            // 
            // lbFiltrarData
            // 
            this.lbFiltrarData.AutoSize = true;
            this.lbFiltrarData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltrarData.Location = new System.Drawing.Point(12, 105);
            this.lbFiltrarData.Name = "lbFiltrarData";
            this.lbFiltrarData.Size = new System.Drawing.Size(70, 13);
            this.lbFiltrarData.TabIndex = 7;
            this.lbFiltrarData.Text = "Filtrar Data";
            // 
            // lbFiltroDe
            // 
            this.lbFiltroDe.AutoSize = true;
            this.lbFiltroDe.Location = new System.Drawing.Point(12, 127);
            this.lbFiltroDe.Name = "lbFiltroDe";
            this.lbFiltroDe.Size = new System.Drawing.Size(24, 13);
            this.lbFiltroDe.TabIndex = 8;
            this.lbFiltroDe.Text = "De:";
            // 
            // dtpFiltroDe
            // 
            this.dtpFiltroDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFiltroDe.Location = new System.Drawing.Point(51, 121);
            this.dtpFiltroDe.Name = "dtpFiltroDe";
            this.dtpFiltroDe.Size = new System.Drawing.Size(132, 20);
            this.dtpFiltroDe.TabIndex = 9;
            // 
            // dtpFiltroAte
            // 
            this.dtpFiltroAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFiltroAte.Location = new System.Drawing.Point(50, 147);
            this.dtpFiltroAte.Name = "dtpFiltroAte";
            this.dtpFiltroAte.Size = new System.Drawing.Size(132, 20);
            this.dtpFiltroAte.TabIndex = 10;
            // 
            // lbFiltroAte
            // 
            this.lbFiltroAte.AutoSize = true;
            this.lbFiltroAte.Location = new System.Drawing.Point(12, 153);
            this.lbFiltroAte.Name = "lbFiltroAte";
            this.lbFiltroAte.Size = new System.Drawing.Size(26, 13);
            this.lbFiltroAte.TabIndex = 11;
            this.lbFiltroAte.Text = "Até:";
            // 
            // columnDespesa
            // 
            this.columnDespesa.Text = "Despesa";
            this.columnDespesa.Width = 77;
            // 
            // columnRenda
            // 
            this.columnRenda.Text = "Renda";
            this.columnRenda.Width = 68;
            // 
            // columnSaldo
            // 
            this.columnSaldo.Text = "Saldo";
            this.columnSaldo.Width = 69;
            // 
            // columnResultado
            // 
            this.columnResultado.Text = "Resultado";
            this.columnResultado.Width = 110;
            // 
            // Form_Relatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 420);
            this.Controls.Add(this.lbFiltroAte);
            this.Controls.Add(this.dtpFiltroAte);
            this.Controls.Add(this.dtpFiltroDe);
            this.Controls.Add(this.lbFiltroDe);
            this.Controls.Add(this.lbFiltrarData);
            this.Controls.Add(this.cbInformacoes);
            this.Controls.Add(this.lbVer);
            this.Controls.Add(this.cbCampo);
            this.Controls.Add(this.lbPara);
            this.Controls.Add(this.lbExibir);
            this.Controls.Add(this.listViewInformacoes);
            this.Controls.Add(this.shapeContainer1);
            this.MinimizeBox = false;
            this.Name = "Form_Relatorios";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatórios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewInformacoes;
        private System.Windows.Forms.Label lbExibir;
        private System.Windows.Forms.Label lbPara;
        private System.Windows.Forms.ComboBox cbCampo;
        private System.Windows.Forms.Label lbVer;
        private System.Windows.Forms.ComboBox cbInformacoes;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShapeDivisao;
        private System.Windows.Forms.Label lbFiltrarData;
        private System.Windows.Forms.Label lbFiltroDe;
        private System.Windows.Forms.DateTimePicker dtpFiltroDe;
        private System.Windows.Forms.DateTimePicker dtpFiltroAte;
        private System.Windows.Forms.Label lbFiltroAte;
        private System.Windows.Forms.ColumnHeader columnResultado;
        private System.Windows.Forms.ColumnHeader columnDespesa;
        private System.Windows.Forms.ColumnHeader columnRenda;
        private System.Windows.Forms.ColumnHeader columnSaldo;
    }
}