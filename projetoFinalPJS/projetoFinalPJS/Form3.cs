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
    public partial class Form_Categoria : Form
    {
        formularioInicial formInicial;
        public SqlDataAdapter adaptadorCategoria;
        SqlCommand comando = new SqlCommand();
        bool acao;
        int id;

        public Form_Categoria(formularioInicial form, SqlDataAdapter dCategoria, bool alterar, int id)
        {
            InitializeComponent();
            formInicial = form;
            adaptadorCategoria = dCategoria;
            acao = alterar;
            this.id = id;
        }

        public void preencherCategoria(int id)
        {
            SqlCommand comandoSelectCat = new SqlCommand();
            comandoSelectCat.Connection = formInicial.conexaoFinanceiro;
            comandoSelectCat.CommandText = "Select nome, limite from CATEGORIA where id_categoria = " + id;
            comandoSelectCat.ExecuteNonQuery();

            SqlDataReader leitor = comandoSelectCat.ExecuteReader();

            while (leitor.Read())
            {
                tbDescriçãoCtg.Text = leitor["Nome"].ToString();
                tbOrçamentoCtg.Text = leitor["Limite"].ToString();
            }

            leitor.Close();
        }

        private void salvarCtg_Click(object sender, EventArgs e)
        {
            if (acao)
                salvarCategoria();
            else
                alterarCategoria(id);
        }

        public void salvarCategoria()
        {
            DataSet dCategoria = new DataSet();
            adaptadorCategoria.Fill(dCategoria, "CATEGORIA");
            DataRow novaCategoria = dCategoria.Tables["CATEGORIA"].NewRow();
            novaCategoria["Nome"] = tbDescriçãoCtg.Text;
            novaCategoria["Limite"] = tbOrçamentoCtg.Text;
            dCategoria.Tables["CATEGORIA"].Rows.Add(novaCategoria);
            adaptadorCategoria.Update(dCategoria, "CATEGORIA");
            adaptadorCategoria.Fill(dCategoria, "CATEGORIA");
            comando.Connection = formInicial.conexaoFinanceiro;
            comando.CommandText = "select COUNT (ID_CATEGORIA) from CATEGORIA";
            Object total_categoria = comando.ExecuteScalar();
            int total_categ=Convert.ToInt32(total_categoria);
            comando.CommandText = "select NOME from CATEGORIA where NOME = '"+tbDescriçãoCtg.Text.ToUpper()+"'";
            Object nome_Categoria = comando.ExecuteScalar();

            if (nome_Categoria != null)
            {
                if (tbDescriçãoCtg.Text.ToUpper() == nome_Categoria.ToString().ToUpper())
                {
                    MessageBox.Show("Esta categoria já existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                    comando.CommandText = "insert into CATEGORIA (NOME,LIMITE) values('" + tbDescriçãoCtg.Text.ToUpper() + "','" + Convert.ToDecimal(tbOrçamentoCtg.Text) + "')";
                    comando.ExecuteScalar();
            }
            Cs_Categorias categoria = new Cs_Categorias(tbDescriçãoCtg.Text, float.Parse(tbOrçamentoCtg.Text));
            formInicial.VisualizarCategoria(categoria, int.Parse(novaCategoria["ID_Categoria"].ToString()));

            Close();
        }

        public void alterarCategoria(int id)
        {
            DataSet dCategoria = new DataSet();
            adaptadorCategoria.Fill(dCategoria, "CATEGORIA");
            DataRow alterarCategoria = dCategoria.Tables["CATEGORIA"].Rows.Find(id);
            alterarCategoria["Nome"] = tbDescriçãoCtg.Text;
            alterarCategoria["Limite"] = tbOrçamentoCtg.Text;
            adaptadorCategoria.Update(dCategoria, "CATEGORIA");
            adaptadorCategoria.Fill(dCategoria, "CATEGORIA");
            Close();
        }
    }
}
