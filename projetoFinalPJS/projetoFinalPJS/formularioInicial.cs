using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projetoFinalPJS
{
    public partial class formularioInicial : Form
    {

        private List<Cs_Categorias> listaCategorias;

        private void formularioInicial_Load(object sender, EventArgs e)
        {
            // Cria a conexão para a base de dados e seu adaptador
            SqlConnection conexaoFinanceiro = new SqlConnection();
            conexaoFinanceiro.ConnectionString = "Data Source=PC01LAB3\\SQLEXPRESS;Initial Catalog=Financeiro;Integrated Security=SSPI";
            // Cria os adaptadores
            SqlDataAdapter adaptadorMovimento = new SqlDataAdapter();
            SqlDataAdapter adaptadorCategoria = new SqlDataAdapter();
            SqlDataAdapter adaptadorRecorrente = new SqlDataAdapter();

            // Cria o comando de seleção do adaptador
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

            // Comando de atualização do movimento
            SqlCommand comandoAtualizacaoMovimento = new SqlCommand("Update Comprados set DESCRICAO = @Descricao, VALOR = @Valor, CATEGORIA = @Cateoria where ID_MOVIMENTO = @IdMovimento", conexaoFinanceiro);
            // Parâmetros para o comando
            // Descrição
            prmDescricaoMovimento = new SqlParameter("@Descricao", SqlDbType.VarChar, 50);
            prmDescricaoMovimento.SourceColumn = "DESCRICAO";
            prmDescricaoMovimento.SourceVersion = DataRowVersion.Current;
            comandoAtualizacaoMovimento.Parameters.Add(prmDescricaoMovimento);
            // Valor
            prmValorMovimento = new SqlParameter("@Valor", SqlDbType.Money);
            prmValorMovimento.SourceColumn = "Valor";
            prmValorMovimento.SourceVersion = DataRowVersion.Current;
            comandoAtualizacaoMovimento.Parameters.Add(prmValorMovimento);
            // Categoria
            prmCategoriaMovimento = new SqlParameter("@Categoria", SqlDbType.Int);
            prmCategoriaMovimento.SourceColumn = "CATEGORIA";
            prmCategoriaMovimento.SourceVersion = DataRowVersion.Current;
            comandoAtualizacaoMovimento.Parameters.Add(prmCategoriaMovimento);
            // Atribui o comando de atualização para o adaptador
            adaptadorMovimento.UpdateCommand = comandoAtualizacaoMovimento;

            // Cria o comando de remoção do Movimento
            SqlCommand comandoRemocao = new SqlCommand("Delete from MOVIMENTO where ID_MOVIMENTO = @IdMovimento", conexaoFinanceiro);
            // Código
            prm = new SqlParameter("@Codigo", SqlDbType.Int);
            prmCodigo.SourceColumn = "Codigo";
            prmCodigo.SourceVersion = DataRowVersion.Original;
            comandoRemocao.Parameters.Add(prmCodigo);
            // Atribui o comando de remoção para o adaptador
            adaptador.DeleteCommand = comandoRemocao;

            // Ação para esquema faltando
            adaptador.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Cria o dataset
            DataSet dados = new DataSet();
            adaptador.Fill(dados, "BlaBla");
        }

        public formularioInicial()
        {
            InitializeComponent();
            
            dataGridView1.DataSource = listaCategorias;
        }

        private void entradaDeValoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Movimentação Var_Form_Movimentação = new Form_Movimentação();
            Var_Form_Movimentação.ShowDialog();
        }

        private void saídaDeValoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Movimentação Var_Form_Movimentação = new Form_Movimentação();
            Var_Form_Movimentação.ShowDialog();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Categoria Var_Form_Categoria = new Form_Categoria();
            Var_Form_Categoria.ShowDialog();
        }
    }
}
