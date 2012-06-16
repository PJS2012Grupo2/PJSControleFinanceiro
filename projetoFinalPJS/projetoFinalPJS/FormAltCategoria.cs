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
    public partial class FormAltCategoria : Form
    {
        private formularioInicial formularioInicial;
        private SqlDataAdapter adaptadorCategoria;
        public FormAltCategoria(formularioInicial formularioInicial, SqlDataAdapter adaptadorCategoria)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
            this.adaptadorCategoria = adaptadorCategoria;
        }

        public void PreencherCategoria()
        {
            SqlCommand comandoSelectCat = new SqlCommand();
            comandoSelectCat.Connection = formularioInicial.conexaoFinanceiro;
            comandoSelectCat.CommandText = "Select nome, limite from CATEGORIA";
            comandoSelectCat.ExecuteNonQuery();

            SqlDataReader leitor = comandoSelectCat.ExecuteReader();

            while (leitor.Read())
            {
                ListViewItem itemDescricao = new ListViewItem(leitor["nome"].ToString());

                ListViewItem.ListViewSubItem itemLimite = new ListViewItem.ListViewSubItem(itemDescricao, leitor["limite"].ToString());

                itemDescricao.SubItems.Add(itemLimite);

                listaCategoria.Items.Add(itemDescricao);
            }

            leitor.Close();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            PreencherCategoria();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            Form_Categoria Var_Form_Categoria = new Form_Categoria(this.formularioInicial, adaptadorCategoria);
            Var_Form_Categoria.ShowDialog();
        }
    }
}
