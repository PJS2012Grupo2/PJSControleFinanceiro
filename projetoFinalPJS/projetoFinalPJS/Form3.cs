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
        SqlDataAdapter adaptadorCategoria;
        formularioInicial formularioInicial;
        FormAltCategoria formEdit;
        SqlCommand comando = new SqlCommand();
        ListViewItem itemAlt;

        private void Form_Categoria_Load(object sender, EventArgs e)
        {
            if (itemAlt != null)
            {
                tbDescriçãoCtg.Text = itemAlt.SubItems[0].Text;
                tbOrçamentoCtg.Text = itemAlt.SubItems[1].Text;
            }
        }
        
        public Form_Categoria(
            formularioInicial formularioInicial,
            SqlDataAdapter adaptadorCategoria,
            ListViewItem itemSelecionado = null,
            FormAltCategoria formEdit=null)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
            this.formEdit = formEdit;
            this.adaptadorCategoria = adaptadorCategoria;
            this.itemAlt = itemSelecionado;
        }

        private void salvarCtg_Click(object sender, EventArgs e)
        {
            float valorParse;
            if (tbDescriçãoCtg.Text.Trim() == "")
            {
                MessageBox.Show("Digite uma descrição.");
                tbDescriçãoCtg.Focus();
            }
            else if (!float.TryParse(tbOrçamentoCtg.Text.Replace("R$", ""), out valorParse))
            {
                MessageBox.Show("Digite um valor válido.");
                tbOrçamentoCtg.Focus();
            }
            else
            {
                comando.CommandText = "select NOME from CATEGORIA where NOME = '"+tbDescriçãoCtg.Text.ToUpper()+"'";
                comando.Connection = formularioInicial.conexaoFinanceiro;
                Object nome_Categoria = comando.ExecuteScalar();

                if (nome_Categoria != null)
                {
                    MessageBox.Show("Esta categoria já existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tbDescriçãoCtg.Focus();
                }
                else
                {
                    string valorLimite = tbOrçamentoCtg.Text.Replace("R$", "");
                    DataRow novaCategoria = formularioInicial.dadosFinanceiro.Tables["CATEGORIA"].NewRow();
                    novaCategoria["NOME"] = tbDescriçãoCtg.Text;
                    novaCategoria["LIMITE"] = tbOrçamentoCtg.Text.Replace("R$", "");
                    Cs_Categorias categoria = new Cs_Categorias(tbDescriçãoCtg.Text, float.Parse(valorLimite));

                    if (itemAlt != null)
                    {
                        foreach (DataRow registro in formularioInicial.dadosFinanceiro.Tables["CATEGORIA"].Rows)
                        {
                            if (int.Parse(registro["ID_CATEGORIA"].ToString()) == int.Parse(itemAlt.Tag.ToString()))
                            {
                                registro["NOME"] = tbDescriçãoCtg.Text;
                                registro["LIMITE"] = valorLimite;
                                break;
                            }
                        }
                    }
                    else
                        formularioInicial.dadosFinanceiro.Tables["CATEGORIA"].Rows.Add(novaCategoria);
                    adaptadorCategoria.Update(formularioInicial.dadosFinanceiro, "CATEGORIA");
                    formularioInicial.carregaCategorias(formularioInicial.listViewCategorias);

                    if (formEdit != null)
                        formEdit.PreencherCategoria();
                    Close();
                }
            }
        }
    }
}
