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
        int id;
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
            comandoSelectCat.CommandText = "Select ID_categoria,nome, limite from CATEGORIA";
            comandoSelectCat.ExecuteNonQuery();

            SqlDataReader leitor = comandoSelectCat.ExecuteReader();

            while (leitor.Read())
            {
                ListViewItem itemDescricao = new ListViewItem(leitor["nome"].ToString());
                itemDescricao.Tag = (int)leitor["ID_categoria"];
                id = int.Parse(itemDescricao.Tag.ToString());
                ListViewItem.ListViewSubItem itemLimite = new ListViewItem.ListViewSubItem(itemDescricao,leitor["limite"].ToString());

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


        /*
        public void limparListView(int id)
        {
            SqlCommand comandoLimpar = new SqlCommand();
            comandoLimpar.Connection = formularioInicial.conexaoFinanceiro;
            comandoLimpar.CommandText = ("Select nome from Categoria where id_categoria = " + id);
            comandoLimpar.ExecuteNonQuery();
            ListViewItem categoriaExcluida = listaCategoria.SelectedItems[0];
            SqlDataReader leitor = comandoLimpar.ExecuteReader();

            while (leitor.Read())
            {
                if (leitor["Nome"] != categoriaExcluida)
                {
                    listaCategoria.
                }

            }
            leitor.Close(); 

        }
         * 
         */
        private void btExcluir_Click(object sender, EventArgs e)
        {
            DataSet DeleteCategoria = new DataSet();
            adaptadorCategoria.Fill(DeleteCategoria,"CATEGORIA");
            DialogResult resposta;
            resposta = MessageBox.Show("Deseja excluir esse item?", "Aviso", MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                DataRow registro = DeleteCategoria.Tables["CATEGORIA"].Rows.Find(id);
                registro.Delete();
                SqlCommand comandoUpdate = new SqlCommand();
                comandoUpdate.Connection = formularioInicial.conexaoFinanceiro;
                comandoUpdate.CommandText = ("Update Movimento set id_categoria = 1 where id_categoria = " + id);
                comandoUpdate.ExecuteNonQuery();
                SqlDataReader leitor = comandoUpdate.ExecuteReader();
                leitor.Close();
                adaptadorCategoria.Update(DeleteCategoria, "CATEGORIA");
            }

            else
                Close();      
        }
    }
}
