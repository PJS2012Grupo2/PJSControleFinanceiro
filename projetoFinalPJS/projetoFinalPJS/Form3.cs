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
        SqlDataAdapter adaptadorCategoria;
        SqlCommand comando = new SqlCommand();
        bool acao;
        ListViewItem itemAlt;

        public Form_Categoria(formularioInicial form, SqlDataAdapter dCategoria, bool alterar, ListViewItem itemAlt=null)
        {
            InitializeComponent();
            formInicial = form;
            adaptadorCategoria = dCategoria;
            acao = alterar;
            this.itemAlt = itemAlt;
        }

        public void preencherCategoria(int id)
        {
            tbDescriçãoCtg.Text = itemAlt.SubItems[0].Text;
            tbOrçamentoCtg.Text = itemAlt.SubItems[1].Text;
            /*
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
            */
        }

        private void salvarCtg_Click(object sender, EventArgs e)
        {
            if (acao)
                salvarCategoria();
            else
                alterarCategoria();
        }

        public void salvarCategoria()
        {
            comando.CommandText = "select NOME from CATEGORIA where NOME = '"+tbDescriçãoCtg.Text.ToUpper()+"'";
            comando.Connection = formInicial.conexaoFinanceiro;
            Object nome_Categoria = comando.ExecuteScalar();

            if (nome_Categoria != null)
            {
                MessageBox.Show("Esta categoria já existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                adaptadorCategoria.Fill(formInicial.dadosFinanceiro, "CATEGORIA");
                DataRow novaCategoria = formInicial.dadosFinanceiro.Tables["CATEGORIA"].NewRow();
                novaCategoria["Nome"] = tbDescriçãoCtg.Text;
                novaCategoria["Limite"] = tbOrçamentoCtg.Text;
                formInicial.dadosFinanceiro.Tables["CATEGORIA"].Rows.Add(novaCategoria);
                Cs_Categorias categoria = new Cs_Categorias(tbDescriçãoCtg.Text, float.Parse(tbOrçamentoCtg.Text));
                formInicial.VisualizarCategoria(categoria, int.Parse(novaCategoria["ID_Categoria"].ToString()));
            }
            adaptadorCategoria.Update(formInicial.dadosFinanceiro, "CATEGORIA");
            Close();
        }

        public void alterarCategoria()
        {
            int idCategoria = int.Parse(itemAlt.Tag.ToString());
            foreach (DataRow registro in formInicial.dadosFinanceiro.Tables["CATEGORIA"].Rows)
            {
                if (int.Parse(registro["ID_CATEGORIA"].ToString()) == idCategoria)
                {
                    DataRow altReg = formInicial.dadosFinanceiro.Tables["CATEGORIA"].Rows.Find(idCategoria);
                    altReg["Nome"] = tbDescriçãoCtg.Text;
                    altReg["Limite"] = float.Parse(tbOrçamentoCtg.Text);
                    break;
                }
            }
            adaptadorCategoria.Update(formInicial.dadosFinanceiro, "CATEGORIA");
            Close();
        }
    }
}
