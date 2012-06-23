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
        public SqlDataAdapter adaptadorMovimento;
        public SqlDataAdapter adaptadorCategoria = new SqlDataAdapter();
        public SqlDataAdapter adaptadorRecorrente;
        public SqlConnection conexaoFinanceiro;
        public DataSet dadosFinanceiro;

        public formularioInicial()
        {
            InitializeComponent();
        }

        public void carregaMovimentos(int idCategoria=0)
        {
            SqlCommand comandoInicializarMovimentos = new SqlCommand();
            comandoInicializarMovimentos.Connection = conexaoFinanceiro;
            comandoInicializarMovimentos.CommandText = "Select ID_MOVIMENTO, DESCRICAO, VALOR, DATA_CADASTRO, PARCELA, VALOR_TOTAL, ID_CATEGORIA FROM MOVIMENTO";
            SqlDataReader leitorMovimentos = comandoInicializarMovimentos.ExecuteReader();
            
            int prc;
            float total;

            listViewMovimentos.Items.Clear();
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
                    total, //(float)leitorMovimentos["VALOR_TOTAL"],
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
        }

        public void VisualizarCategoria(Cs_Categorias ctg, int idCategoria=0)
        {
            ListViewItem itemDescricao = new ListViewItem(ctg.Nome_Categoria);
            ListViewItem.ListViewSubItem itemLimite = new ListViewItem.ListViewSubItem(itemDescricao, "R$" + ctg.Orçamento_Categoria.ToString());
            itemDescricao.SubItems.Add(itemLimite);
            itemDescricao.Tag = idCategoria;
            listViewCategorias.Items.Add(itemDescricao);
        }

        private void carregaCategorias()
        {
            SqlCommand comandoInicializarCategorias = new SqlCommand();
            comandoInicializarCategorias.Connection = conexaoFinanceiro;
            comandoInicializarCategorias.CommandText = "Select id_categoria, nome, limite from CATEGORIA";
            comandoInicializarCategorias.ExecuteNonQuery();
            SqlDataReader leitorCategorias = comandoInicializarCategorias.ExecuteReader();
            while (leitorCategorias.Read())
            {
                Cs_Categorias categoria = new Cs_Categorias((string)leitorCategorias["nome"], (float.Parse(leitorCategorias["limite"].ToString())));
                VisualizarCategoria(categoria, int.Parse(leitorCategorias["ID_Categoria"].ToString()));
            }
            leitorCategorias.Close();
        }        
        
        public void conexaoDados()
        {
            // Cria a conexão para a base de dados e seu adaptador
            conexaoFinanceiro = new SqlConnection();
            conexaoFinanceiro.ConnectionString = "Data Source=YURI-PC\\YURISQL;Initial Catalog=Financeiro;Integrated Security=SSPI";
            //conexaoFinanceiro.ConnectionString = "Data Source=PC15LAB3\\SQLEXPRESS;Initial Catalog=Financeiro;Integrated Security=SSPI";
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
            prmNomeCategoria = new SqlParameter("@Nome", SqlDbType.VarChar, 50);
            comandoAtualizacaoCategoria.Parameters.Add(prmNomeCategoria);
            prmLimiteCategoria = new SqlParameter("@Limite", SqlDbType.Money);
            comandoAtualizacaoCategoria.Parameters.Add(prmLimiteCategoria);
            adaptadorCategoria.UpdateCommand = comandoAtualizacaoCategoria;

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
            SqlParameter prmIdCategoria     = new SqlParameter("@IdCategoria", SqlDbType.Int);
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
                valorTotal = "";
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
        
        private void verificaSelecaoMovimentos()
        {
            // Desabilita ou habilita o botão de edição de movimento no menu
            if (listViewMovimentos.SelectedItems.Count != 0)
            {
                entradaDeValoresToolStripMenuItem.Enabled = true;
                saídaDeValoresToolStripMenuItem.Enabled = true;
            }
            else
            {
                entradaDeValoresToolStripMenuItem.Enabled = false;
                saídaDeValoresToolStripMenuItem.Enabled = false;
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
            Form_Categoria Var_Form_Categoria = new Form_Categoria(this, adaptadorCategoria,true,0);
            Var_Form_Categoria.ShowDialog();
        }        

        private void listViewMovimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificaSelecaoMovimentos();
        }

        private void listViewMovimentos_DoubleClick(object sender, EventArgs e)
        {
            FormAlteracaoMovimentos formAlt = new FormAlteracaoMovimentos(adaptadorMovimento, this, listViewMovimentos.SelectedItems[0]);
            formAlt.ShowDialog();
        }

        private void listViewMovimentos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            verificaSelecaoMovimentos();
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

        private void listViewMovimentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewMovimentos.SelectedItems.Count > 0)
            {
                foreach (DataRow movDel in dadosFinanceiro.Tables["Movimento"].Rows)
                {
                    if (movDel["ID_Movimento"].ToString() == listViewMovimentos.SelectedItems[0].Tag.ToString())
                    {
                        removeMovimento(movDel);
                        break;
                    }
                }
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
            else
            {
                carregaMovimentos();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAltCategoria Var_Alt_Categorias = new FormAltCategoria(this, adaptadorCategoria);
            Var_Alt_Categorias.ShowDialog(this);
        }

        // Metodo para limpar os registros excluidos da tabela CATEGORIA
        // dentro do listView do formularioInicial
        public void limparListViewInicial(int id)
        {
            SqlCommand comandoLimpar = new SqlCommand();
            comandoLimpar.Connection = conexaoFinanceiro;
            comandoLimpar.CommandText = ("Select nome from Categoria where id_categoria = " + id);
            comandoLimpar.ExecuteNonQuery();
            ListViewItem categoriaExcluida = listViewCategorias.SelectedItems[0];
            SqlDataReader leitor = comandoLimpar.ExecuteReader();

            while (leitor.Read())
            {
                if (leitor["Nome"].ToString() == categoriaExcluida.Text)
                {
                    listViewCategorias.Items.Remove(categoriaExcluida);
                }
            }
            leitor.Close();
        }
    }
}
