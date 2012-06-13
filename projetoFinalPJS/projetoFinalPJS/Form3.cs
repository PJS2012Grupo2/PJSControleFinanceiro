using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projetoFinalPJS
{
    public partial class Form_Categoria : Form
    {
        formularioInicial formInicial;
        SqlDataAdapter adaptadorCategoria;
        public Form_Categoria(formularioInicial form, SqlDataAdapter dCategoria)
        {
            InitializeComponent();
<<<<<<< .merge_file_a04768


        }

        public SqlConnection conexao = new SqlConnection();
        public SqlDataAdapter adaptador = new SqlDataAdapter();
        public DataSet dCategoria = new DataSet();

        private void Form_Categoria_Load(object sender, EventArgs e)
        {
            // Conexao com sql
            conexao.ConnectionString = "Data Source=PC18LA3\\MSSQLSERVER1;Initial Catalog=Financeiro;Integrated Security=SSPI";
            SqlCommand comandoSelecao = new SqlCommand("Select * from Categoria", conexao);
            adaptador.SelectCommand = comandoSelecao;

            SqlCommand comandoInsercao = new SqlCommand("Insert into Categoria (Nome, Limite) values (@nome, @limite)", conexao);

            //Criando os parametros da tabela CATEGORIA
            SqlParameter pNome = new SqlParameter("@nome", SqlDbType.VarChar, 50);
            pNome.SourceColumn = "Nome";
            pNome.SourceVersion = DataRowVersion.Current;
            comandoInsercao.Parameters.Add(pNome);
            SqlParameter pLimite = new SqlParameter("@limite", SqlDbType.Money);
            pLimite.SourceColumn = "Limite";
            pLimite.SourceVersion = DataRowVersion.Current;
            comandoInsercao.Parameters.Add(pLimite);
            adaptador.InsertCommand = comandoInsercao;
            adaptador.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adaptador.Fill(dCategoria, "CATEGORIA");
        }
   
        private void salvarCtg_Click(object sender, EventArgs e)
        {
=======
            formInicial = form;
            adaptadorCategoria = dCategoria;
        }

        private void salvarCtg_Click(object sender, EventArgs e)
        {
            formInicial.conexaoDados();

            DataSet dCategoria = new DataSet();
            adaptadorCategoria.Fill(dCategoria, "CATEGORIA");
>>>>>>> .merge_file_a04216
            DataRow novaCategoria = dCategoria.Tables["CATEGORIA"].NewRow();
            novaCategoria["Nome"] = tbDescriçãoCtg.Text;
            novaCategoria["Limite"] = tbOrçamentoCtg.Text;
            dCategoria.Tables["CATEGORIA"].Rows.Add(novaCategoria);
<<<<<<< .merge_file_a04768
            adaptador.Update(dCategoria, "CATEGORIA");
            adaptador.Fill(dCategoria, "CATEGORIA");
=======
            adaptadorCategoria.Update(dCategoria, "CATEGORIA");
            adaptadorCategoria.Fill(dCategoria, "CATEGORIA");

            Cs_Categorias categoria = new Cs_Categorias(tbDescriçãoCtg.Text, float.Parse(tbOrçamentoCtg.Text));
            formInicial.VisualizarCategoria(categoria);

            //conexao.Close();
            Close();
>>>>>>> .merge_file_a04216
        }
    }
}
