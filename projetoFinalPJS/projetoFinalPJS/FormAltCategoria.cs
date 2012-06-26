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
        int id = 0;
        public FormAltCategoria(formularioInicial formularioInicial)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
        }

        public void PreencherCategoria()
        {
           // listaCategoria.Items.AddRange();
        }

        /*(private void FormCategoria_Load(object sender, EventArgs e)
        {
            PreencherCategoria();
        }*/

        //private void btAlterar_Click(object sender, EventArgs e)
        //{
        //    if (listaCategoria.SelectedItems.Count > 0)
        //    {
        //        Form_Categoria formAlt = new Form_Categoria(formularioInicial, formularioInicial.adaptadorCategoria, listaCategoria.SelectedItems[0], this);
        //        //formAlt.preencherCategoria(id); TESTE
        //        formAlt.ShowDialog();
        //    }
        //}

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
                if (leitor["Nome"].ToString() == categoriaExcluida.Text)
                {
                    listaCategoria.Items.Remove(categoriaExcluida);
                }
            }
            leitor.Close(); 

        }
      
        private void btExcluir_Click(object sender, EventArgs e)
        {
            formularioInicial.adaptadorCategoria.Fill(formularioInicial.dadosFinanceiro,"CATEGORIA");
            DialogResult resposta;
            resposta = MessageBox.Show("Deseja excluir esse item?", "Aviso", MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                DataRow registro = formularioInicial.dadosFinanceiro.Tables["CATEGORIA"].Rows.Find(id);
                SqlCommand comandoUpdate = new SqlCommand();
                comandoUpdate.Connection = formularioInicial.conexaoFinanceiro;
                comandoUpdate.CommandText = ("Update Movimento set id_categoria = 1 where id_categoria = " + id);
                comandoUpdate.ExecuteNonQuery();
                SqlDataReader leitor = comandoUpdate.ExecuteReader();
                leitor.Close();
                registro.Delete();
                limparListView(id);
                //formularioInicial.limparListViewInicial(id);
                formularioInicial.adaptadorCategoria.Update(formularioInicial.dadosFinanceiro, "CATEGORIA");
                formularioInicial.carregaMovimentos();
                formularioInicial.carregaCategorias();
            }
            else
                Close();      
        }
    }
}
