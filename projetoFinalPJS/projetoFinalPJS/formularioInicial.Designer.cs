﻿namespace projetoFinalPJS
{
    partial class formularioInicial
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Todas as Categorias");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formularioInicial));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Form_Entrada_De_ValoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saídaDeValoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mêsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.anoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gastosParceladosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewCategorias = new System.Windows.Forms.ListView();
            this.columnNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLimite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRestante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewMovimentos = new System.Windows.Forms.ListView();
            this.columnDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDataCadastro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnParcelas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cATEGORIABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.csCategoriasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNovaEntrada = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNovaSaida = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRelatorio = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.csCategoriasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cATEGORIABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.csCategoriasBindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csCategoriasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.gerenciarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(823, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.abrirToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form_Entrada_De_ValoresToolStripMenuItem1,
            this.saídaDeValoresToolStripMenuItem1,
            this.categoriaToolStripMenuItem});
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.novoToolStripMenuItem.Text = "Novo";
            // 
            // Form_Entrada_De_ValoresToolStripMenuItem1
            // 
            this.Form_Entrada_De_ValoresToolStripMenuItem1.Name = "Form_Entrada_De_ValoresToolStripMenuItem1";
            this.Form_Entrada_De_ValoresToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.Form_Entrada_De_ValoresToolStripMenuItem1.Text = "Entrada de Valores";
            this.Form_Entrada_De_ValoresToolStripMenuItem1.Click += new System.EventHandler(this.entradaDeValoresToolStripMenuItem1_Click);
            // 
            // saídaDeValoresToolStripMenuItem1
            // 
            this.saídaDeValoresToolStripMenuItem1.Name = "saídaDeValoresToolStripMenuItem1";
            this.saídaDeValoresToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.saídaDeValoresToolStripMenuItem1.Text = "Saída de Valores";
            this.saídaDeValoresToolStripMenuItem1.Click += new System.EventHandler(this.saídaDeValoresToolStripMenuItem1_Click);
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.categoriaToolStripMenuItem.Text = "Categoria";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriasToolStripMenuItem,
            this.movimentacaoToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            // 
            // movimentacaoToolStripMenuItem
            // 
            this.movimentacaoToolStripMenuItem.Name = "movimentacaoToolStripMenuItem";
            this.movimentacaoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.movimentacaoToolStripMenuItem.Text = "Movimentação";
            this.movimentacaoToolStripMenuItem.Click += new System.EventHandler(this.abreAlteracaoMovimento);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatóriosToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriaToolStripMenuItem1,
            this.mêsToolStripMenuItem,
            this.mêsToolStripMenuItem1,
            this.anoToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.relatóriosToolStripMenuItem.Text = "Relatórios Visuais";
            // 
            // categoriaToolStripMenuItem1
            // 
            this.categoriaToolStripMenuItem1.Name = "categoriaToolStripMenuItem1";
            this.categoriaToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.categoriaToolStripMenuItem1.Text = "Categoria";
            // 
            // mêsToolStripMenuItem
            // 
            this.mêsToolStripMenuItem.Name = "mêsToolStripMenuItem";
            this.mêsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.mêsToolStripMenuItem.Text = "Semana";
            // 
            // mêsToolStripMenuItem1
            // 
            this.mêsToolStripMenuItem1.Name = "mêsToolStripMenuItem1";
            this.mêsToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.mêsToolStripMenuItem1.Text = "Mês";
            // 
            // anoToolStripMenuItem
            // 
            this.anoToolStripMenuItem.Name = "anoToolStripMenuItem";
            this.anoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.anoToolStripMenuItem.Text = "Ano";
            // 
            // gerenciarToolStripMenuItem
            // 
            this.gerenciarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gastosParceladosToolStripMenuItem1});
            this.gerenciarToolStripMenuItem.Name = "gerenciarToolStripMenuItem";
            this.gerenciarToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.gerenciarToolStripMenuItem.Text = "Gerenciar";
            // 
            // gastosParceladosToolStripMenuItem1
            // 
            this.gastosParceladosToolStripMenuItem1.Name = "gastosParceladosToolStripMenuItem1";
            this.gastosParceladosToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.gastosParceladosToolStripMenuItem1.Text = "Gastos Parcelados";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.listViewCategorias);
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 373);
            this.panel1.TabIndex = 1;
            // 
            // listViewCategorias
            // 
            this.listViewCategorias.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCategorias.BackColor = System.Drawing.Color.Gainsboro;
            this.listViewCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewCategorias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNome,
            this.columnLimite,
            this.columnRestante});
            this.listViewCategorias.ForeColor = System.Drawing.Color.Black;
            this.listViewCategorias.FullRowSelect = true;
            this.listViewCategorias.GridLines = true;
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            listViewItem1.Tag = "todas";
            this.listViewCategorias.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewCategorias.Location = new System.Drawing.Point(-2, 0);
            this.listViewCategorias.Name = "listViewCategorias";
            this.listViewCategorias.Size = new System.Drawing.Size(169, 365);
            this.listViewCategorias.TabIndex = 0;
            this.listViewCategorias.UseCompatibleStateImageBehavior = false;
            this.listViewCategorias.View = System.Windows.Forms.View.Tile;
            this.listViewCategorias.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewCategorias_ItemSelectionChanged);
            this.listViewCategorias.DoubleClick += new System.EventHandler(this.listViewCategorias_DoubleClick);
            this.listViewCategorias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewCategorias_KeyDown);
            // 
            // columnNome
            // 
            this.columnNome.Text = "Nome";
            this.columnNome.Width = 133;
            // 
            // columnLimite
            // 
            this.columnLimite.Text = "Orçamento";
            this.columnLimite.Width = 98;
            // 
            // columnRestante
            // 
            this.columnRestante.Text = "Orçamento Restante";
            this.columnRestante.Width = 117;
            // 
            // listViewMovimentos
            // 
            this.listViewMovimentos.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewMovimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMovimentos.BackColor = System.Drawing.SystemColors.Window;
            this.listViewMovimentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewMovimentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDescricao,
            this.columnValor,
            this.columnDataCadastro,
            this.columnCategoria,
            this.columnParcelas,
            this.columnTotal});
            this.listViewMovimentos.FullRowSelect = true;
            this.listViewMovimentos.GridLines = true;
            this.listViewMovimentos.Location = new System.Drawing.Point(0, 19);
            this.listViewMovimentos.Name = "listViewMovimentos";
            this.listViewMovimentos.Size = new System.Drawing.Size(650, 362);
            this.listViewMovimentos.TabIndex = 0;
            this.listViewMovimentos.UseCompatibleStateImageBehavior = false;
            this.listViewMovimentos.View = System.Windows.Forms.View.Details;
            this.listViewMovimentos.SelectedIndexChanged += new System.EventHandler(this.verificaSelecaoMovimentos);
            this.listViewMovimentos.DoubleClick += new System.EventHandler(this.abreAlteracaoMovimento);
            this.listViewMovimentos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewMovimentos_KeyDown);
            // 
            // columnDescricao
            // 
            this.columnDescricao.Text = "Descrição";
            this.columnDescricao.Width = 168;
            // 
            // columnValor
            // 
            this.columnValor.Text = "Valor";
            this.columnValor.Width = 87;
            // 
            // columnDataCadastro
            // 
            this.columnDataCadastro.Text = "Data do Cadastro";
            this.columnDataCadastro.Width = 105;
            // 
            // columnCategoria
            // 
            this.columnCategoria.Text = "Categoria";
            this.columnCategoria.Width = 146;
            // 
            // columnParcelas
            // 
            this.columnParcelas.Text = "Parcelas";
            this.columnParcelas.Width = 57;
            // 
            // columnTotal
            // 
            this.columnTotal.Text = "Valor Total";
            this.columnTotal.Width = 71;
            // 
            // cATEGORIABindingSource
            // 
            this.cATEGORIABindingSource.DataMember = "CATEGORIA";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.listViewMovimentos);
            this.panel2.Location = new System.Drawing.Point(173, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 389);
            this.panel2.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNovaEntrada,
            this.toolStripButtonNovaSaida,
            this.toolStripButton3,
            this.toolStripButtonRelatorio,
            this.toolStripButton5,
            this.toolStripButton7,
            this.toolStripButton6});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(823, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNovaEntrada
            // 
            this.toolStripButtonNovaEntrada.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNovaEntrada.Image")));
            this.toolStripButtonNovaEntrada.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNovaEntrada.Name = "toolStripButtonNovaEntrada";
            this.toolStripButtonNovaEntrada.Size = new System.Drawing.Size(97, 35);
            this.toolStripButtonNovaEntrada.Text = "Entrada de Valor";
            this.toolStripButtonNovaEntrada.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButtonNovaEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonNovaEntrada.ToolTipText = "Entrada de Valores";
            // 
            // toolStripButtonNovaSaida
            // 
            this.toolStripButtonNovaSaida.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNovaSaida.Image")));
            this.toolStripButtonNovaSaida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNovaSaida.Name = "toolStripButtonNovaSaida";
            this.toolStripButtonNovaSaida.Size = new System.Drawing.Size(85, 35);
            this.toolStripButtonNovaSaida.Text = "Saída de Valor";
            this.toolStripButtonNovaSaida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonNovaSaida.ToolTipText = "Saída de Valores";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(62, 35);
            this.toolStripButton3.Text = "Categoria";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.ToolTipText = "Cadastrar Categorias";
            // 
            // toolStripButtonRelatorio
            // 
            this.toolStripButtonRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRelatorio.Image")));
            this.toolStripButtonRelatorio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRelatorio.Name = "toolStripButtonRelatorio";
            this.toolStripButtonRelatorio.Size = new System.Drawing.Size(58, 35);
            this.toolStripButtonRelatorio.Text = "Relatório";
            this.toolStripButtonRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonRelatorio.ToolTipText = "Relatório";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(43, 35);
            this.toolStripButton5.Text = "Filtros";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton5.ToolTipText = "Filtros";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(74, 35);
            this.toolStripButton7.Text = "Calculadora";
            this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton7.ToolTipText = "Calculadora";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "Salvar";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(823, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(146, 17);
            this.toolStripStatusLabel1.Text = "Lembretes:                           ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // formularioInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(823, 451);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formularioInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programa Financeiro";
            this.Load += new System.EventHandler(this.formularioInicial_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cATEGORIABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.csCategoriasBindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.csCategoriasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNovaEntrada;
        private System.Windows.Forms.ToolStripButton toolStripButtonNovaSaida;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRelatorio;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentacaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Form_Entrada_De_ValoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saídaDeValoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mêsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mêsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem anoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gastosParceladosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.BindingSource csCategoriasBindingSource1;
        private System.Windows.Forms.ColumnHeader columnNome;
        private System.Windows.Forms.ColumnHeader columnLimite;
        private System.Windows.Forms.BindingSource csCategoriasBindingSource;
        private System.Windows.Forms.BindingSource cATEGORIABindingSource;
        private System.Windows.Forms.ColumnHeader columnDescricao;
        private System.Windows.Forms.ColumnHeader columnRestante;
        private System.Windows.Forms.ColumnHeader columnDataCadastro;
        private System.Windows.Forms.ColumnHeader columnCategoria;
        private System.Windows.Forms.ColumnHeader columnParcelas;
        private System.Windows.Forms.ColumnHeader columnTotal;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ColumnHeader columnValor;
        public System.Windows.Forms.ListView listViewMovimentos;
        public System.Windows.Forms.ListView listViewCategorias;
    }
}