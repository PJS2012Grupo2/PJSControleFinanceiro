using System;
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

        private List<Cs_Categorias> listaCategorias;
        
        public SqlDataAdapter adaptadorMovimento;
        public SqlDataAdapter adaptadorCategoria;
        public SqlDataAdapter adaptadorRecorrente;
        public SqlConnection conexaoFinanceiro;
        public DataRow[] busca;
        
        

        private void formularioInicial_Load(object sender, EventArgs e)
        {
            try
            {
                conexaoDados();
            }
            catch
            {
                MessageBox.Show("Não foi possível fazer a conexão com a base de dados.");
            } 
        }

        public void conexaoDados()
        {
            // Cria a conexão para a base de dados e seu adaptador
            conexaoFinanceiro = new SqlConnection();
            conexaoFinanceiro.ConnectionString = @"Data Source=ROPAS-PC\SQLEXPRESS;Initial Catalog=Financeiro;Integrated Security=SSPI";

            conexaoFinanceiro.Open();
            // Cria os adaptadores
           
            adaptadorMovimento = new SqlDataAdapter();
            adaptadorCategoria = new SqlDataAdapter();
            adaptadorRecorrente = new SqlDataAdapter();

            // Cria o comando de seleção do adaptador
            SqlCommand comandoSelecaoSaldo = new SqlCommand("Select * from SALDO", conexaoFinanceiro);
            SqlCommand comandoSelecaoMovimento = new SqlCommand("Select * from MOVIMENTO", conexaoFinanceiro);
            SqlCommand comandoSelecaoCategoria = new SqlCommand("Select * from CATEGORIA", conexaoFinanceiro);
            SqlCommand comandoSelecaoRecorrente = new SqlCommand("Select * from MOVIMENTO_RECORRENTE", conexaoFinanceiro);

           
            adaptadorMovimento.SelectCommand = comandoSelecaoMovimento;
            adaptadorCategoria.SelectCommand = comandoSelecaoCategoria;
            adaptadorRecorrente.SelectCommand = comandoSelecaoRecorrente;

            /* -------------- Comandos de inserção ------------------ */


            SqlCommand comandoInsercaoMovimento = new SqlCommand("Insert into MOVIMENTO (DESCRICAO, VALOR, DATA_CADASTRO, ID_CATEGORIA) values (@Descricao, @Valor, @DataCadastro, @Categoria)", conexaoFinanceiro);
            // Descrição
            SqlParameter prmDescricaoMovimento = new SqlParameter("@Descricao", SqlDbType.VarChar, 50);
            prmDescricaoMovimento.SourceColumn = "DESCRICAO";
            prmDescricaoMovimento.SourceVersion = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmDescricaoMovimento); // Adiciona o parâmetro ao comando
            // Valor
            SqlParameter prmValorMovimento = new SqlParameter("@Valor", SqlDbType.Money);
            prmValorMovimento.SourceColumn = "VALOR";
            prmValorMovimento.SourceVersion = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmValorMovimento);
            // Data de cadastro
            SqlParameter prmDataCadastroMovimento = new SqlParameter("@DataCadastro", SqlDbType.Date);
            prmDataCadastroMovimento.SourceColumn = "DATA_CADASTRO";
            prmDataCadastroMovimento.SourceVersion = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmDataCadastroMovimento);
            // Parcela
            SqlParameter prmParcelaMovimento = new SqlParameter("@Parcela", SqlDbType.Int);
            prmParcelaMovimento.SourceColumn = "PARCELA";
            prmParcelaMovimento.SourceVersion = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmParcelaMovimento);
            // Categoria
            SqlParameter prmCategoriaMovimento = new SqlParameter("@Categoria", SqlDbType.Int);
            prmCategoriaMovimento.SourceColumn = "ID_CATEGORIA";
            prmCategoriaMovimento.SourceVersion = DataRowVersion.Current;
            comandoInsercaoMovimento.Parameters.Add(prmCategoriaMovimento);
            adaptadorMovimento.InsertCommand = comandoInsercaoMovimento;

            SqlCommand comandoInsercaoCategoria = new SqlCommand("Insert into CATEGORIA (NOME, LIMITE) values (@Nome, @Limite)", conexaoFinanceiro);
            // Nome
            SqlParameter prmNomeCategoria = new SqlParameter("@Nome", SqlDbType.VarChar, 50);
            prmNomeCategoria.SourceColumn = "NOME";
            prmNomeCategoria.SourceVersion = DataRowVersion.Current;
            comandoInsercaoCategoria.Parameters.Add(prmNomeCategoria);
            // Limite
            SqlParameter prmLimiteCategoria = new SqlParameter("@Limite", SqlDbType.Money);
            prmLimiteCategoria.SourceColumn = "LIMITE";
            prmLimiteCategoria.SourceVersion = DataRowVersion.Current;
            comandoInsercaoCategoria.Parameters.Add(prmLimiteCategoria);
            adaptadorCategoria.InsertCommand = comandoInsercaoCategoria;

            SqlCommand comandoInsercaoRecorrente = new SqlCommand("Insert into MOVIMENTO_RECORRENTE (NOME, VALOR, RECORRENCIA, ID_CATEGORIA) values (@Nome, @Valor, @Recorrencia, @IdCategoria)", conexaoFinanceiro);
            // Nome
            SqlParameter prmNomeRecorrente = new SqlParameter("@Nome", SqlDbType.VarChar, 30);
            prmNomeRecorrente.SourceColumn = "NOME";
            prmNomeRecorrente.SourceVersion = DataRowVersion.Current;
            comandoInsercaoRecorrente.Parameters.Add(prmNomeRecorrente);
            // Valor
            SqlParameter prmValorRecorrente = new SqlParameter("@Valor", SqlDbType.Money);
            prmValorRecorrente.SourceColumn = "VALOR";
            prmValorRecorrente.SourceVersion = DataRowVersion.Current;
            comandoInsercaoRecorrente.Parameters.Add(prmValorRecorrente);
            // Recorrência
            SqlParameter prmRecorrenciaRecorrente = new SqlParameter("@Recorrencia", SqlDbType.VarChar, 20);
            prmValorRecorrente.SourceColumn = "RECORRENCIA";
            prmValorRecorrente.SourceVersion = DataRowVersion.Current;
            comandoInsercaoRecorrente.Parameters.Add(prmRecorrenciaRecorrente);
            // ID da Categoria
            SqlParameter prmCategoriaRecorrente = new SqlParameter("@IdCategoria", SqlDbType.Int);
            prmValorRecorrente.SourceColumn = "ID_CATEGORIA";
            prmValorRecorrente.SourceVersion = DataRowVersion.Current;
            comandoInsercaoRecorrente.Parameters.Add(prmCategoriaRecorrente);

            /**************** Comandos de atualização **********************/
            



            SqlCommand comandoAtualizacaoMovimento = new SqlCommand("Update MOVIMENTO set DESCRICAO = @Descricao, VALOR = @Valor, DATACADASTRO = @DataCadastro, PARCELA = @Parcela, ID_CATEGORIA = @Categoria where ID_MOVIMENTO = @IdMovimento", conexaoFinanceiro);
            prmDescricaoMovimento = new SqlParameter("@Descricao", SqlDbType.VarChar, 50);
            comandoAtualizacaoMovimento.Parameters.Add(prmDescricaoMovimento);
            prmValorMovimento = new SqlParameter("@Valor", SqlDbType.Money);
            comandoAtualizacaoMovimento.Parameters.Add(prmValorMovimento);
            prmDataCadastroMovimento = new SqlParameter("@DataCadastro", SqlDbType.Date);
            comandoAtualizacaoMovimento.Parameters.Add(prmDataCadastroMovimento);
            prmParcelaMovimento = new SqlParameter("@Parcela", SqlDbType.Int);
            comandoAtualizacaoMovimento.Parameters.Add(prmParcelaMovimento);
            prmCategoriaMovimento = new SqlParameter("@Categoria", SqlDbType.Int);
            comandoAtualizacaoMovimento.Parameters.Add(prmCategoriaMovimento);
            adaptadorMovimento.UpdateCommand = comandoAtualizacaoMovimento;

            SqlCommand comandoAtualizacaoCategoria = new SqlCommand("Update CATEGORIA set NOME = @Nome, LIMITE = @Limite where ID_CATEGORIA = @IdCategoria", conexaoFinanceiro);
            prmNomeCategoria = new SqlParameter("@Nome", SqlDbType.VarChar, 50);
            comandoAtualizacaoCategoria.Parameters.Add(prmNomeCategoria);
            prmLimiteCategoria = new SqlParameter("@Limite", SqlDbType.Money);
            comandoAtualizacaoCategoria.Parameters.Add(prmLimiteCategoria);
            adaptadorCategoria.UpdateCommand = comandoAtualizacaoCategoria;

            SqlCommand comandoAtualizaoRecorrente = new SqlCommand("Update MOVIMENTO_RECORRENTE set NOME = @Nome, VALOR = @Valor, RECORRENCIA = @Recorrencia, ID_CATEGORIA = @IdCategoria", conexaoFinanceiro);
            prmNomeRecorrente = new SqlParameter("@Nome", SqlDbType.VarChar, 30);
            comandoAtualizaoRecorrente.Parameters.Add(prmNomeRecorrente);
            prmValorRecorrente = new SqlParameter("@Valor", SqlDbType.Money);
            comandoAtualizaoRecorrente.Parameters.Add(prmValorRecorrente);
            prmRecorrenciaRecorrente = new SqlParameter("@Recorrencia", SqlDbType.VarChar, 20);
            comandoAtualizaoRecorrente.Parameters.Add(prmRecorrenciaRecorrente);
            prmCategoriaRecorrente = new SqlParameter("@IdCategoria", SqlDbType.Int);
            comandoAtualizaoRecorrente.Parameters.Add(prmCategoriaRecorrente);
            adaptadorRecorrente.UpdateCommand = comandoAtualizaoRecorrente;

            /************************* Comandos de remoção ************************/
            SqlCommand comandoRemocaoMovimento = new SqlCommand("Delete from MOVIMENTO where ID_MOVIMENTO = @IdMovimento", conexaoFinanceiro);
            // ID do movimento
            SqlParameter prmIdMovimento = new SqlParameter("@IdMovimento", SqlDbType.Int);
            prmIdMovimento.SourceColumn = "ID_MOVIMENTO";
            prmIdMovimento.SourceVersion = DataRowVersion.Original;
            comandoRemocaoMovimento.Parameters.Add(prmIdMovimento);
            adaptadorMovimento.DeleteCommand = comandoRemocaoMovimento;

            SqlCommand comandoRemocaoCategoria = new SqlCommand("Delete from CATEGORIA where ID_CATEGORIA = @IdCategoria", conexaoFinanceiro);
            // ID da  categoria
            SqlParameter prmIdCategoria = new SqlParameter("@IdCategoria", SqlDbType.Int);
            prmIdCategoria.SourceColumn = "ID_CATEGORIA";
            prmIdCategoria.SourceVersion = DataRowVersion.Original;
            comandoRemocaoCategoria.Parameters.Add(prmIdCategoria);
            adaptadorCategoria.DeleteCommand = comandoRemocaoCategoria;

            SqlCommand comandoRemocaoRecorrente = new SqlCommand("Delete from MOVIMENTO_RECORRENTE where ID_RECORRENTE = @IdRecorrente", conexaoFinanceiro);
            // ID da  categoria
            SqlParameter prmIdRecorrente = new SqlParameter("@IdRecorrente", SqlDbType.Int);
            prmIdRecorrente.SourceColumn = "ID_RECORRENTE";
            prmIdRecorrente.SourceVersion = DataRowVersion.Original;
            comandoRemocaoRecorrente.Parameters.Add(prmIdRecorrente);
            adaptadorRecorrente.DeleteCommand = comandoRemocaoRecorrente;

            // Ação para esquema faltando
            adaptadorMovimento.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adaptadorCategoria.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adaptadorRecorrente.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Cria os datasets
            DataSet dadosMovimento = new DataSet();
        

            adaptadorMovimento.Fill(dadosMovimento, "MOVIMENTO");
            DataSet dadosCategoria = new DataSet();
            adaptadorCategoria.Fill(dadosCategoria, "CATEGORIA");
            DataSet dadosRecorrente = new DataSet();
            adaptadorRecorrente.Fill(dadosRecorrente, "MOVIMENTO_RECORRENTE");

            SqlCommand comandoInicializar = new SqlCommand();
            comandoInicializar.Connection = conexaoFinanceiro;
           
            comandoInicializar.CommandText = "Select nome, limite from CATEGORIA";
            comandoInicializar.ExecuteNonQuery();

            SqlDataReader leitor = comandoInicializar.ExecuteReader();

            while (leitor.Read())
            {
                //string nome; float limite;
                Cs_Categorias categoria = new Cs_Categorias((string)leitor["nome"],(float.Parse(leitor["limite"].ToString())));
                VisualizarCategoria(categoria);
            }
        }


        public formularioInicial()
        {
              InitializeComponent();
              try
              {
                  SqlConnection conn = new SqlConnection(@"Data Source=ROPAS-PC\SQLEXPRESS;Initial Catalog=FINANCEIRO;Integrated Security=SSPI");
                  conn.Open();
                  SqlCommand comando = new SqlCommand();
                  comando.Connection = conn;
                  comando.CommandText = "select * from SALDO";
                  Object total_saldo = comando.ExecuteScalar();
                  toolStripStatusLabel1.Text ="Lembretes: Saldo="+ total_saldo.ToString()+ "";
                  conn.Close();
              }
              catch (Exception c)
              {
                  MessageBox.Show("erro", "erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
            //dataGridView1.DataSource = listaC ategorias;
        }

        public void VisualizarCategoria(Cs_Categorias ctg)
        {
            ListViewItem itemDescricao = new ListViewItem(ctg.Nome_Categoria);

            ListViewItem.ListViewSubItem itemLimite = new ListViewItem.ListViewSubItem(itemDescricao, "R$"+ctg.Orçamento_Categoria.ToString());

            itemDescricao.SubItems.Add(itemLimite);

            listViewCategorias.Items.Add(itemDescricao);
        }

        public void AdicionaMovimento(Cs_Movimento mvt)
        {
            //ListViewItem itemDescricao = new ListViewItem(mvt.descricao);
            //ListViewItem.ListViewSubItem itemValor = new ListViewItem.ListViewSubItem(itemDescricao, "R$" + mvt.valor.ToString());
            //ListViewItem.ListViewSubItem itemDataCadastro = new ListViewItem.ListViewSubItem(itemDescricao, mvt.dataCadastro.ToString());
            //ListViewItem.ListViewSubItem itemCategoria = new ListViewItem.ListViewSubItem(itemDescricao, mvt.categoria);
            //string parcela, valorTotal;
            //if (mvt.parcela <= 0) { parcela = ""; valorTotal = ""; } else { parcela = mvt.parcela.ToString(); valorTotal = mvt.valorTotal.ToString(); }
            //ListViewItem.ListViewSubItem itemParcela = new ListViewItem.ListViewSubItem(itemDescricao, parcela);
            //itemDescricao.SubItems.Add(itemValor);
            //itemDescricao.SubItems.Add(itemDataCadastro);
            //itemDescricao.SubItems.Add(itemCategoria);
            //itemDescricao.SubItems.Add(itemParcela);

            //listViewMovimentos.Items.Add(itemDescricao);
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

        private void categoriaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            buscaCategoria busca = new buscaCategoria(this, adaptadorCategoria);
            busca.ShowDialog();
        }

        private void movimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscaMovimento busca = new buscaMovimento(this, adaptadorMovimento);
            busca.ShowDialog();
        }

        private void movimentoRecorrenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscaRecorrente busca = new buscaRecorrente(this, adaptadorRecorrente);
            busca.ShowDialog();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscaData busca = new buscaData(this, adaptadorRecorrente);
            busca.ShowDialog();
        }


        private void entradaDeValoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Movimentação Var_Form_Movimentação = new Form_Movimentação(this, adaptadorMovimento);
            Var_Form_Movimentação.ShowDialog();
        }

        private void saidaDeValoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Movimentação Var_Form_Movimentação_2 = new Form_Movimentação(this, adaptadorMovimento);
            Var_Form_Movimentação_2.ShowDialog();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Categoria Var_Form_Categoria = new Form_Categoria(this, adaptadorCategoria);
            Var_Form_Categoria.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
