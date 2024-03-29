﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace projetoFinalPJS
{
    public partial class formularioInicial : Form
    {
        public SqlDataAdapter adaptadorMovimento;
        public SqlDataAdapter adaptadorCategoria = new SqlDataAdapter();
        public SqlDataAdapter adaptadorRecorrente;
        public SqlConnection conexaoFinanceiro;
        public DataSet dadosFinanceiro;
        public bool var_Saida = false;

        public formularioInicial()
        {
            InitializeComponent();
        }

        public void carregaMovimentos(int idCategoria=0)
        {
            int prc;
            float total;
            listViewMovimentos.Items.Clear();
            SqlCommand comandoInicializarMovimentos = new SqlCommand();
            comandoInicializarMovimentos.Connection = conexaoFinanceiro;
            comandoInicializarMovimentos.CommandText = "Select ID_MOVIMENTO, DESCRICAO, VALOR, DATA_CADASTRO, PARCELA, VALOR_TOTAL, ID_CATEGORIA FROM MOVIMENTO";
            SqlDataReader leitorMovimentos = comandoInicializarMovimentos.ExecuteReader();
            while (leitorMovimentos.Read())
            {
                if (int.TryParse(leitorMovimentos["PARCELA"].ToString(), out prc))
                {
                    prc     = int.Parse(leitorMovimentos["PARCELA"].ToString());
                    total   = float.Parse(leitorMovimentos["VALOR_TOTAL"].ToString());
                }
                else
                    prc = 0; total = 0;

                Cs_Movimento movimento = new Cs_Movimento(
                    (string)leitorMovimentos["DESCRICAO"],
                    float.Parse(leitorMovimentos["VALOR"].ToString()),
                    (DateTime)leitorMovimentos["DATA_CADASTRO"],
                    prc,
                    total,
                    leitorMovimentos["ID_CATEGORIA"].ToString()
                );
                if (idCategoria > 0)
                {
                    if (idCategoria.ToString() == leitorMovimentos["ID_CATEGORIA"].ToString())
                        AdicionaMovimento(movimento, leitorMovimentos["ID_MOVIMENTO"].ToString(), int.Parse(leitorMovimentos["ID_CATEGORIA"].ToString()));
                }
                else
                    AdicionaMovimento(movimento, leitorMovimentos["ID_MOVIMENTO"].ToString(), int.Parse(leitorMovimentos["ID_CATEGORIA"].ToString()));
            }
            leitorMovimentos.Close();
            string nomeCategoria = "";
            SqlCommand achaCategoria = conexaoFinanceiro.CreateCommand();

            // Troca o ID da categoria pelo nome da categoria na exibição do ListView
            foreach (ListViewItem item in listViewMovimentos.Items)
            {
                achaCategoria.CommandText = "SELECT NOME FROM CATEGORIA WHERE ID_CATEGORIA = @IdCategoria";
                achaCategoria.Parameters.Clear();
                achaCategoria.Parameters.AddWithValue("@IdCategoria", int.Parse(item.SubItems[3].Text));
                nomeCategoria = ((string)achaCategoria.ExecuteScalar());
                item.SubItems[3].Text = nomeCategoria;
            }
            verificaValor();
        }

        public void VisualizarCategoria(Cs_Categorias ctg, int idCategoria=0)
        {
            ListViewItem itemDescricao = new ListViewItem(ctg.Nome_Categoria);
            ListViewItem.ListViewSubItem itemLimite = new ListViewItem.ListViewSubItem(itemDescricao, "R$" + ctg.Orçamento_Categoria.ToString());
            itemDescricao.SubItems.Add(itemLimite);
            itemDescricao.Tag = idCategoria;
            listViewCategorias.Items.Add(itemDescricao);
        }

        public void carregaCategorias()
        {
            listViewCategorias.Items.Clear();
            ListViewItem todas = new ListViewItem("Todas as Categorias");
            todas.Tag = "todas";
            listViewCategorias.Items.Add(todas);
            SqlCommand comandoInicializarCategorias = new SqlCommand();
            comandoInicializarCategorias.Connection = conexaoFinanceiro;
            comandoInicializarCategorias.CommandText = "Select id_categoria, nome, limite from CATEGORIA";
            comandoInicializarCategorias.ExecuteNonQuery();
            SqlDataReader leitorCategorias = comandoInicializarCategorias.ExecuteReader();
            while (leitorCategorias.Read())
            {
                Cs_Categorias categoria = new Cs_Categorias((string)leitorCategorias["nome"], (float.Parse(leitorCategorias["limite"].ToString())));
                ListViewItem itemDescricao = new ListViewItem(categoria.Nome_Categoria);
                ListViewItem.ListViewSubItem itemLimite = new ListViewItem.ListViewSubItem(itemDescricao, "R$" + categoria.Orçamento_Categoria.ToString());
                itemDescricao.SubItems.Add(itemLimite);
                itemDescricao.Tag = int.Parse(leitorCategorias["ID_Categoria"].ToString());
                listViewCategorias.Items.Add(itemDescricao);
            }
            leitorCategorias.Close();
        }        
        
        public void conexaoDados()
        {
            // Cria a conexão para a base de dados e seu adaptador
            conexaoFinanceiro = new SqlConnection();
            //conexaoFinanceiro.ConnectionString = "Data Source=YURI-PC\\YURISQL;Initial Catalog=Financeiro;Integrated Security=SSPI";
            conexaoFinanceiro.ConnectionString = "Data Source=PC18LA3\\SQLEXPRESS;Initial Catalog=Financeiro;Integrated Security=SSPI";
            try
            {
                conexaoFinanceiro.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possível fazer a conexão com a base de dados.");
            }            
            // Adaptadores
            adaptadorMovimento  = new SqlDataAdapter();
            adaptadorCategoria  = new SqlDataAdapter();
            adaptadorRecorrente = new SqlDataAdapter();

            // Comando de seleção dos adaptadores
            SqlCommand comandoSelecaoMovimento  = new SqlCommand("Select * from MOVIMENTO",             conexaoFinanceiro);
            SqlCommand comandoSelecaoCategoria  = new SqlCommand("Select * from CATEGORIA",             conexaoFinanceiro);
            SqlCommand comandoSelecaoRecorrente = new SqlCommand("Select * from MOVIMENTO_RECORRENTE",  conexaoFinanceiro);

            adaptadorMovimento.SelectCommand    = comandoSelecaoMovimento;
            adaptadorCategoria.SelectCommand    = comandoSelecaoCategoria;
            adaptadorRecorrente.SelectCommand   = comandoSelecaoRecorrente;

            /* -------------- Comandos de inserção ------------------ */
            SqlCommand comandoInsercaoMovimento
                = new SqlCommand("Insert into MOVIMENTO (DESCRICAO, VALOR, DATA_CADASTRO, ID_CATEGORIA) values (@Descricao, @Valor, @DataCadastro, @Categoria)", conexaoFinanceiro);
            SqlParameter prmDescricaoMovimento  = new SqlParameter("@Descricao", SqlDbType.VarChar, 50);
            prmDescricaoMovimento.SourceColumn  = "DESCRICAO";
            prmDescricaoMovimento.SourceVersion = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmDescricaoMovimento);

            SqlParameter prmValorMovimento  = new SqlParameter("@Valor", SqlDbType.Money);
            prmValorMovimento.SourceColumn  = "VALOR";
            prmValorMovimento.SourceVersion = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmValorMovimento);

            SqlParameter prmDataCadastroMovimento   = new SqlParameter("@DataCadastro", SqlDbType.Date);
            prmDataCadastroMovimento.SourceColumn   = "DATA_CADASTRO";
            prmDataCadastroMovimento.SourceVersion  = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmDataCadastroMovimento);

            SqlParameter prmParcelaMovimento    = new SqlParameter("@Parcela", SqlDbType.Int);
            prmParcelaMovimento.SourceColumn    = "PARCELA";
            prmParcelaMovimento.SourceVersion   = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmParcelaMovimento);

            SqlParameter prmCategoriaMovimento  = new SqlParameter("@Categoria", SqlDbType.Int);
            prmCategoriaMovimento.SourceColumn  = "ID_CATEGORIA";
            prmCategoriaMovimento.SourceVersion = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmCategoriaMovimento);
            adaptadorMovimento.InsertCommand = comandoInsercaoMovimento;

            SqlCommand comandoInsercaoCategoria = new SqlCommand("Insert into CATEGORIA (NOME, LIMITE) values (@Nome, @Limite)", conexaoFinanceiro);
            SqlParameter prmNomeCategoria       = new SqlParameter("@Nome", SqlDbType.VarChar, 50);
            prmNomeCategoria.SourceColumn       = "NOME";
            prmNomeCategoria.SourceVersion      = DataRowVersion.Current;
            comandoInsercaoCategoria.Parameters.Add(prmNomeCategoria);

            SqlParameter prmLimiteCategoria     = new SqlParameter("@Limite", SqlDbType.Money);
            prmLimiteCategoria.SourceColumn     = "LIMITE";
            prmLimiteCategoria.SourceVersion    = DataRowVersion.Current;
            comandoInsercaoCategoria.Parameters.Add(prmLimiteCategoria);
            adaptadorCategoria.InsertCommand = comandoInsercaoCategoria;

            SqlCommand comandoInsercaoRecorrente
                = new SqlCommand("Insert into MOVIMENTO_RECORRENTE (NOME, VALOR, RECORRENCIA, ID_CATEGORIA) values (@Nome, @Valor, @Recorrencia, @IdCategoria)", conexaoFinanceiro);
            SqlParameter prmNomeRecorrente       = new SqlParameter("@Nome", SqlDbType.VarChar, 30);
            prmNomeRecorrente.SourceColumn       = "NOME";
            prmNomeRecorrente.SourceVersion      = DataRowVersion.Current;
            comandoInsercaoRecorrente.Parameters.Add(prmNomeRecorrente);

            SqlParameter prmValorRecorrente  = new SqlParameter("@Valor", SqlDbType.Money);
            prmValorRecorrente.SourceColumn  = "VALOR";
            prmValorRecorrente.SourceVersion = DataRowVersion.Current;
            comandoInsercaoRecorrente.Parameters.Add(prmValorRecorrente);

            SqlParameter prmRecorrenciaRecorrente   = new SqlParameter("@Recorrencia", SqlDbType.VarChar, 20);
            prmValorRecorrente.SourceColumn         = "RECORRENCIA";
            prmValorRecorrente.SourceVersion        = DataRowVersion.Current;
            comandoInsercaoRecorrente.Parameters.Add(prmRecorrenciaRecorrente);

            SqlParameter prmCategoriaRecorrente = new SqlParameter("@IdCategoria", SqlDbType.Int);
            prmValorRecorrente.SourceColumn     = "ID_CATEGORIA";
            prmValorRecorrente.SourceVersion    = DataRowVersion.Current;
            comandoInsercaoRecorrente.Parameters.Add(prmCategoriaRecorrente);

            /* -------------- Comandos de atualização ------------------ */
            SqlCommand comandoAtualizacaoMovimento  =
                new SqlCommand("Update MOVIMENTO set DESCRICAO = @Descricao, VALOR = @Valor, DATA_CADASTRO = @DataCadastro, PARCELA = @Parcela, ID_CATEGORIA = @Categoria where ID_MOVIMENTO = @IdMovimento", conexaoFinanceiro);
            SqlParameter prmIdMovimento             = new SqlParameter("@IdMovimento", SqlDbType.Int);
            prmIdMovimento.SourceColumn             = "ID_Movimento";
            prmIdMovimento.SourceVersion            = DataRowVersion.Original;
            comandoAtualizacaoMovimento.Parameters.Add(prmIdMovimento);

            prmDescricaoMovimento = new SqlParameter("@Descricao", SqlDbType.VarChar, 50);
            prmDescricaoMovimento.SourceColumn  = "Descricao";
            prmDescricaoMovimento.SourceVersion = DataRowVersion.Current;
            comandoAtualizacaoMovimento.Parameters.Add(prmDescricaoMovimento);
            
            prmValorMovimento = new SqlParameter("@Valor", SqlDbType.Money);
            prmValorMovimento.SourceColumn  = "Valor";
            prmValorMovimento.SourceVersion = DataRowVersion.Current;
            comandoAtualizacaoMovimento.Parameters.Add(prmValorMovimento);
            
            prmDataCadastroMovimento = new SqlParameter("@DataCadastro", SqlDbType.Date);
            prmDataCadastroMovimento.SourceColumn   = "Data_Cadastro";
            prmDataCadastroMovimento.SourceVersion  = DataRowVersion.Current;
            comandoAtualizacaoMovimento.Parameters.Add(prmDataCadastroMovimento);
            
            prmParcelaMovimento = new SqlParameter("@Parcela", SqlDbType.Int);
            prmParcelaMovimento.SourceColumn    = "Parcela";
            prmParcelaMovimento.SourceVersion   = DataRowVersion.Current;
            comandoAtualizacaoMovimento.Parameters.Add(prmParcelaMovimento);
            
            prmCategoriaMovimento = new SqlParameter("@Categoria", SqlDbType.Int);
            prmCategoriaMovimento.SourceColumn  = "ID_Categoria";
            prmCategoriaMovimento.SourceVersion = DataRowVersion.Current;
            comandoAtualizacaoMovimento.Parameters.Add(prmCategoriaMovimento);
            adaptadorMovimento.UpdateCommand = comandoAtualizacaoMovimento;
            adaptadorMovimento.UpdateCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord; // FIX para ConcurrencyViolation

            SqlCommand comandoAtualizacaoCategoria =
                new SqlCommand("Update CATEGORIA set NOME = @Nome, LIMITE = @Limite where ID_CATEGORIA = @IdCategoria", conexaoFinanceiro);
            SqlParameter prmIdCategoria = new SqlParameter("@IdCategoria", SqlDbType.Int);
            prmIdCategoria.SourceColumn = "ID_Categoria";
            prmIdCategoria.SourceVersion = DataRowVersion.Original;
            comandoAtualizacaoCategoria.Parameters.Add(prmIdCategoria);

            prmNomeCategoria = new SqlParameter("@Nome", SqlDbType.VarChar, 50);
            prmNomeCategoria.SourceVersion = DataRowVersion.Current;
            prmNomeCategoria.SourceColumn = "Nome";
            comandoAtualizacaoCategoria.Parameters.Add(prmNomeCategoria);

            prmLimiteCategoria = new SqlParameter("@Limite", SqlDbType.Money);
            prmLimiteCategoria.SourceVersion = DataRowVersion.Current;
            prmLimiteCategoria.SourceColumn = "Limite";
            comandoAtualizacaoCategoria.Parameters.Add(prmLimiteCategoria);

            adaptadorCategoria.UpdateCommand = comandoAtualizacaoCategoria;
            adaptadorCategoria.UpdateCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;

            SqlCommand comandoAtualizaoRecorrente =
                new SqlCommand("Update MOVIMENTO_RECORRENTE set NOME = @Nome, VALOR = @Valor, RECORRENCIA = @Recorrencia, ID_CATEGORIA = @IdCategoria", conexaoFinanceiro);
            prmNomeRecorrente = new SqlParameter("@Nome", SqlDbType.VarChar, 30);
            comandoAtualizaoRecorrente.Parameters.Add(prmNomeRecorrente);
            prmValorRecorrente = new SqlParameter("@Valor", SqlDbType.Money);
            comandoAtualizaoRecorrente.Parameters.Add(prmValorRecorrente);
            prmRecorrenciaRecorrente = new SqlParameter("@Recorrencia", SqlDbType.VarChar, 20);
            comandoAtualizaoRecorrente.Parameters.Add(prmRecorrenciaRecorrente);
            prmCategoriaRecorrente = new SqlParameter("@IdCategoria", SqlDbType.Int);
            comandoAtualizaoRecorrente.Parameters.Add(prmCategoriaRecorrente);
            adaptadorRecorrente.UpdateCommand = comandoAtualizaoRecorrente;

            /* -------------- Comandos de remoção ------------------ */
            SqlCommand comandoRemocaoMovimento =
                new SqlCommand("Delete from MOVIMENTO where ID_MOVIMENTO = @IdMovimento", conexaoFinanceiro);
            prmIdMovimento = new SqlParameter("@IdMovimento", SqlDbType.Int);
            prmIdMovimento.SourceColumn     = "ID_MOVIMENTO";
            prmIdMovimento.SourceVersion    = DataRowVersion.Original;
            comandoRemocaoMovimento.Parameters.Add(prmIdMovimento);
            adaptadorMovimento.DeleteCommand = comandoRemocaoMovimento;

            SqlCommand comandoRemocaoCategoria =
                new SqlCommand("Delete from CATEGORIA where ID_CATEGORIA = @IdCategoria", conexaoFinanceiro);
            prmIdCategoria     = new SqlParameter("@IdCategoria", SqlDbType.Int);
            prmIdCategoria.SourceColumn     = "ID_CATEGORIA";
            prmIdCategoria.SourceVersion    = DataRowVersion.Original;
            comandoRemocaoCategoria.Parameters.Add(prmIdCategoria);
            adaptadorCategoria.DeleteCommand = comandoRemocaoCategoria;

            SqlCommand comandoRemocaoRecorrente =
                new SqlCommand("Delete from MOVIMENTO_RECORRENTE where ID_RECORRENTE = @IdRecorrente", conexaoFinanceiro);
            SqlParameter prmIdRecorrente    = new SqlParameter("@IdRecorrente", SqlDbType.Int);
            prmIdRecorrente.SourceColumn    = "ID_RECORRENTE";
            prmIdRecorrente.SourceVersion   = DataRowVersion.Original;
            comandoRemocaoRecorrente.Parameters.Add(prmIdRecorrente);
            adaptadorRecorrente.DeleteCommand = comandoRemocaoRecorrente;

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexaoFinanceiro;
            comando.CommandText = "select * from SALDO";
            Object tt_saldo = comando.ExecuteScalar();
            toolStripStatusLabel1.Text = tt_saldo.ToString();

            // Ação para esquema faltando
            adaptadorMovimento.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adaptadorCategoria.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adaptadorRecorrente.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            dadosFinanceiro = new DataSet();
            adaptadorMovimento.Fill(dadosFinanceiro, "Movimento");
            adaptadorCategoria.Fill(dadosFinanceiro, "Categoria");
            adaptadorRecorrente.Fill(dadosFinanceiro, "Movimento_Recorrente");
        }
        
        private void formularioInicial_Load(object sender, EventArgs e)
        {
            conexaoDados();
            carregaCategorias();
            carregaMovimentos();
            
            verificaSelecaoMovimentos();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexaoFinanceiro;
            comando.CommandText = "select * from SALDO";
            Object total_saldo = comando.ExecuteScalar();
            toolStripStatusLabel1.Text ="Lembretes: Saldo="+ total_saldo.ToString()+ "";
        }

        private ListViewItem ConstroiItemMovimento(Cs_Movimento mvt, bool alt=false, int idCategoria=0, string idMovimento="")
        {
            ListViewItem itemDescricao = new ListViewItem(mvt.descricao);
            ListViewItem.ListViewSubItem itemValor = new ListViewItem.ListViewSubItem(itemDescricao, "R$" + mvt.valor.ToString());
            ListViewItem.ListViewSubItem itemDataCadastro = new ListViewItem.ListViewSubItem(itemDescricao, mvt.dataCadastro.ToString());
            ListViewItem.ListViewSubItem itemCategoria = new ListViewItem.ListViewSubItem(itemDescricao, mvt.categoria);
            string parcela, valorTotal;
            if (mvt.parcela <= 0)
            {
                parcela = "";
                valorTotal = itemValor.Text;
            }
            else
            {
                parcela = mvt.parcela.ToString();
                valorTotal = mvt.valorTotal.ToString();
            }
            ListViewItem.ListViewSubItem itemParcela = new ListViewItem.ListViewSubItem(itemDescricao, parcela);
            itemDescricao.SubItems.Add(itemValor);
            itemDescricao.SubItems.Add(itemDataCadastro);
            itemDescricao.SubItems.Add(itemCategoria);
            itemDescricao.SubItems.Add(itemParcela);
            if (!alt)
                // Apenas atribui uma tag ao movimento para id e categoria se for uma inserção
                itemDescricao.Tag = idMovimento;
            itemDescricao.SubItems[3].Tag = idCategoria;
            return itemDescricao;
        }

        public void AdicionaMovimento(Cs_Movimento mvt, string idMovimento, int idCategoria)
        {
            listViewMovimentos.Items.Add(ConstroiItemMovimento(mvt, false, idCategoria, idMovimento));
        }

        public void AlteraMovimento(Cs_Movimento mvt, int tagItemAlterado, int idCategoria)
        {
            int i;
            for (i = 0; i < listViewMovimentos.Items.Count; i++)
                if (int.Parse(listViewMovimentos.Items[i].Tag.ToString()) == tagItemAlterado)
                    break;
            listViewMovimentos.Items[i] = ConstroiItemMovimento(mvt, true, idCategoria);
        }

        private void verificaValor()
        {
            foreach (ListViewItem mvt in listViewMovimentos.Items)
            {
                mvt.UseItemStyleForSubItems = false;
                if (float.Parse(mvt.SubItems[1].Text.Replace("R$", "")) >= 0)
                    mvt.SubItems[1].ForeColor = Color.Green;
                else
                    mvt.SubItems[1].ForeColor = Color.Red;
            }
        }

        private void verificaSelecaoMovimentos(object sender=null, EventArgs e=null)
        {
            // Desabilita ou habilita o botão de edição de movimento no menu
            if (listViewMovimentos.SelectedItems.Count != 0)
            {
                movimentacaoToolStripMenuItem.Enabled = true;
            }
            else
            {
                movimentacaoToolStripMenuItem.Enabled = false;
            }
        }

        // Método que visualiza todas as categorias inseridas
        public void VisualizarCategoria(Cs_Categorias ctg)
        {
            ListViewItem itemDescricao = new ListViewItem(ctg.Nome_Categoria);
            ListViewItem.ListViewSubItem itemLimite = new ListViewItem.ListViewSubItem(itemDescricao, "R$"+ctg.Orçamento_Categoria.ToString());

            itemDescricao.SubItems.Add(itemLimite);

            listViewCategorias.Items.Add(itemDescricao);
        }

        public void FiltrarCategoria(DataRow[] busca)
        {
            foreach (DataRow p in busca)
            {
                listViewCategorias.Items.Clear();
                ListViewItem nome = new ListViewItem(p["Nome"].ToString());
                ListViewItem.ListViewSubItem limite = new ListViewItem.ListViewSubItem(nome, p["Limite"].ToString());

                nome.SubItems.Add(limite);
                listViewCategorias.Items.Add(nome);
            }

        }

        public void FiltrarMovimento(DataRow[] busca)
        {
            foreach (DataRow p in busca)
            {
                listViewMovimentos.Items.Clear();
                ListViewItem nome = new ListViewItem(p["Nome"].ToString());
                ListViewItem.ListViewSubItem descricao = new ListViewItem.ListViewSubItem(nome, p["DESCRICAO"].ToString());
                ListViewItem.ListViewSubItem valor = new ListViewItem.ListViewSubItem(nome, p["VALOR"].ToString());
                ListViewItem.ListViewSubItem dataCadastro = new ListViewItem.ListViewSubItem(nome, p["DATA_CADASTRO"].ToString());
                ListViewItem.ListViewSubItem parcela = new ListViewItem.ListViewSubItem(nome, p["PARCELA"].ToString());
                ListViewItem.ListViewSubItem valorTotal = new ListViewItem.ListViewSubItem(nome, p["VALOR_TOTAL"].ToString());

                nome.SubItems.Add(descricao);
                nome.SubItems.Add(valor);
                nome.SubItems.Add(dataCadastro);
                nome.SubItems.Add(parcela);
                nome.SubItems.Add(valorTotal);
                listViewMovimentos.Items.Add(nome);

            }
        }
        public void FiltrarData(DataRow[] busca)
        {
            foreach (DataRow p in busca)
            {
                listViewMovimentos.Items.Clear();
                ListViewItem nome = new ListViewItem(p["Nome"].ToString());
                ListViewItem.ListViewSubItem descricao = new ListViewItem.ListViewSubItem(nome, p["DESCRICAO"].ToString());
                ListViewItem.ListViewSubItem valor = new ListViewItem.ListViewSubItem(nome, p["VALOR"].ToString());
                ListViewItem.ListViewSubItem dataCadastro = new ListViewItem.ListViewSubItem(nome, p["DATA_CADASTRO"].ToString());
                ListViewItem.ListViewSubItem parcela = new ListViewItem.ListViewSubItem(nome, p["PARCELA"].ToString());
                ListViewItem.ListViewSubItem valorTotal = new ListViewItem.ListViewSubItem(nome, p["VALOR_TOTAL"].ToString());

                nome.SubItems.Add(descricao);
                nome.SubItems.Add(valor);
                nome.SubItems.Add(dataCadastro);
                nome.SubItems.Add(parcela);
                nome.SubItems.Add(valorTotal);
                listViewMovimentos.Items.Add(nome);
            }
        }

        public void FiltrarRecorrentes(DataRow[] busca)
        {
            foreach (DataRow p in busca)
            {
                listViewMovimentos.Items.Clear();
                ListViewItem nome = new ListViewItem(p["Nome"].ToString());
                ListViewItem.ListViewSubItem descricao = new ListViewItem.ListViewSubItem(nome, p["DESCRICAO"].ToString());
                ListViewItem.ListViewSubItem valor = new ListViewItem.ListViewSubItem(nome, p["VALOR"].ToString());
                ListViewItem.ListViewSubItem dataCadastro = new ListViewItem.ListViewSubItem(nome, p["RECORRENCIA"].ToString());
                ListViewItem.ListViewSubItem parcela = new ListViewItem.ListViewSubItem(nome, p["PARCELA"].ToString());
                ListViewItem.ListViewSubItem valorTotal = new ListViewItem.ListViewSubItem(nome, p["VALOR_TOTAL"].ToString());

                nome.SubItems.Add(descricao);
                nome.SubItems.Add(valor);
                nome.SubItems.Add(dataCadastro);
                nome.SubItems.Add(parcela);
                nome.SubItems.Add(valorTotal);
                listViewMovimentos.Items.Add(nome);
            }
        }

        private void entradaDeValoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Movimentação Var_Form_Movimentação = new Form_Movimentação(this, adaptadorMovimento);
            Var_Form_Movimentação.checkBox1.Enabled = false;
            Var_Form_Movimentação.groupBox1.Enabled = false;
            Var_Form_Movimentação.tbValor.ForeColor = Color.Green;
            Var_Form_Movimentação.ShowDialog();
        }

        private void saídaDeValoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var_Saida = true;
            Form_Movimentação Var_Form_Movimentação = new Form_Movimentação(this, adaptadorMovimento);
            Var_Form_Movimentação.tbValor.ForeColor = Color.Red;
            Var_Form_Movimentação.ShowDialog();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Categoria Var_Form_Categoria = new Form_Categoria(this, adaptadorCategoria);
            Var_Form_Categoria.ShowDialog();
        }        

        private void abreAlteracaoMovimento(object sender, EventArgs e)
        {
            if (listViewMovimentos.SelectedItems.Count > 0)
            {
                Form_Movimentação formAlt = new Form_Movimentação(this, adaptadorMovimento, listViewMovimentos.SelectedItems[0]);
                formAlt.ShowDialog();
            }
        }

        private void listViewMovimentos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            verificaSelecaoMovimentos();
        }

        public void removeCategoria(DataRow catDel)
        {
            const string mensagem =
            "Tem certeza de que deseja excluir esta categoria?";
            const string titulo = "Aviso";
            var result = MessageBox.Show(mensagem, titulo,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = int.Parse(listViewCategorias.SelectedItems[0].Tag.ToString());
                SqlCommand comandoUpdate = new SqlCommand();
                SqlCommand comandoAchaSemCategoria = new SqlCommand();
                comandoUpdate.Connection = conexaoFinanceiro;
                comandoAchaSemCategoria.Connection = conexaoFinanceiro;
                comandoAchaSemCategoria.CommandText =
                    ("Select ID_CATEGORIA From CATEGORIA where NOME = 'Sem Categoria'");
                int idSemCategoria = (int)comandoAchaSemCategoria.ExecuteScalar();
                comandoUpdate.CommandText =
                    ("Update Movimento set id_categoria = " + idSemCategoria + " where id_categoria = " + id);
                comandoUpdate.ExecuteNonQuery();
                catDel.Delete();
                adaptadorCategoria.Update(dadosFinanceiro, "Categoria");
                adaptadorMovimento.Update(dadosFinanceiro, "Movimento");
                carregaMovimentos();
                carregaCategorias();
            }
        }

        public void removeMovimento(DataRow movDel)
        {
            const string mensagem =
            "Tem certeza de que deseja excluir a movimentação?";
            const string titulo = "Aviso";
            var result = MessageBox.Show(mensagem, titulo,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                movDel.Delete();
                adaptadorMovimento.Update(dadosFinanceiro, "Movimento");
                carregaMovimentos();
            }
        }

        private void listViewCategorias_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewCategorias.SelectedItems.Count > 0 && listViewCategorias.Items.IndexOf(listViewCategorias.SelectedItems[0]) != 0)
            {
                int idCat = int.Parse(listViewCategorias.SelectedItems[0].Tag.ToString());

                listViewMovimentos.Items.Clear();
                foreach (DataRow rowMovimento in dadosFinanceiro.Tables["Movimento"].Rows)
                {
                    if (rowMovimento["ID_Categoria"].ToString() == idCat.ToString())
                    {
                        carregaMovimentos(idCat);
                    }
                }
            } 
            //else if (listViewCategorias.SelectedItems[0].Tag.ToString() == "todas") 
            //{
            //    carregaMovimentos();
            //}
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
        
        public bool valor_Negativo()
        {
            bool negativo = var_Saida;
            return negativo;
        }

        private void listViewCategorias_DoubleClick(object sender, EventArgs e)
        {
            if (listViewCategorias.SelectedItems.Count > 0 && listViewCategorias.SelectedItems[0].Tag.ToString() != "todas")
            {
                Form_Categoria formAlt = new Form_Categoria(this, adaptadorCategoria, listViewCategorias.SelectedItems[0]);
                formAlt.ShowDialog();
            }
        }

        private void listViewMovimentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewMovimentos.SelectedItems.Count > 0)
            {
                foreach (DataRow movDel in dadosFinanceiro.Tables["MOVIMENTO"].Rows)
                {
                    if (movDel["ID_MOVIMENTO"].ToString() == listViewMovimentos.SelectedItems[0].Tag.ToString())
                    {
                        removeMovimento(movDel);
                        break;
                    }
                }
            }
        }

        private void listViewCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewCategorias.SelectedItems.Count > 0)
            {
                foreach (DataRow catDel in dadosFinanceiro.Tables["CATEGORIA"].Rows)
                {
                    if (catDel["ID_CATEGORIA"].ToString() == listViewCategorias.SelectedItems[0].Tag.ToString())
                    {
                        removeCategoria(catDel);
                        break;
                    }
                }
            }
        }
    }
}
