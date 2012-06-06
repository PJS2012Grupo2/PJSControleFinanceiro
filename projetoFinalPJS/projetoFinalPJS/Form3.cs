using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projetoFinalPJS
{
    public partial class Form_Categoria : Form
    {
        public Form_Categoria()
        {
            InitializeComponent();


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
            DataRow novaCategoria = dCategoria.Tables["CATEGORIA"].NewRow();
            novaCategoria["Nome"] = tbDescriçãoCtg.Text;
            novaCategoria["Limite"] = tbOrçamentoCtg.Text;
            dCategoria.Tables["CATEGORIA"].Rows.Add(novaCategoria);
            adaptador.Update(dCategoria, "CATEGORIA");
            adaptador.Fill(dCategoria, "CATEGORIA");
        }
    }
}
