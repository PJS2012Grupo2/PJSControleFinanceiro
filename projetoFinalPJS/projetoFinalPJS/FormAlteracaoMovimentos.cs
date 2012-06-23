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
    public partial class FormAlteracaoMovimentos : Form
    {
        SqlDataAdapter adaptadorMovimento;
        private formularioInicial formularioInicial;
        ListViewItem itemAlt;

        public FormAlteracaoMovimentos(SqlDataAdapter adaptador, formularioInicial form1, ListViewItem itemSelecionado)
        {
            InitializeComponent();
            this.adaptadorMovimento = adaptador;
            this.formularioInicial = form1;
            this.itemAlt = itemSelecionado;
        }

        private void FormAlteracaoMovimentos_Load(object sender, EventArgs e)
        {
            tbDescrição.Text = itemAlt.SubItems[0].Text;
            cbCategoria.Text = itemAlt.SubItems[3].Text;
            cbCategoria.SelectedText = itemAlt.SubItems[3].Text;
            tbValor.Text = itemAlt.SubItems[1].Text;
            dtpData.Text = DateTime.Parse(itemAlt.SubItems[2].Text).ToString().Substring(0, 7);
        }

        private void alterar_Click(object sender, EventArgs e)
        {
            if (tbSaldo.Text.Trim() == "")
            {
                MessageBox.Show("Digite um valor de Saldo válido.");
                tbSaldo.Focus();
            }
            else if (tbDescrição.Text.Trim() == "")
            {
                MessageBox.Show("Digite uma descrição.");
                tbDescrição.Focus();
            }
            else if (tbValor.Text.Trim() == "")
            {
                MessageBox.Show("Digite um valor válido.");
                tbValor.Focus();
            }
            else
            {
                DataSet dMovimento = new DataSet();
                adaptadorMovimento.Fill(dMovimento, "MOVIMENTO");
                DataRow novoMovimento = dMovimento.Tables["MOVIMENTO"].NewRow();
                novoMovimento["Descricao"] = tbDescrição.Text;
                novoMovimento["Valor"] = tbValor.Text.Replace("R$", "");
                novoMovimento["Data_Cadastro"] = DateTime.UtcNow;
                SqlCommand achaCategoria = formularioInicial.conexaoFinanceiro.CreateCommand();
                achaCategoria.CommandText = "SELECT ID_CATEGORIA FROM CATEGORIA WHERE NOME = '" + cbCategoria.Text + "'";
                int numeroCategoria = ((int)achaCategoria.ExecuteScalar());
                novoMovimento["Id_Categoria"] = numeroCategoria;
                SqlCommand achaMovimento = formularioInicial.conexaoFinanceiro.CreateCommand();
                achaMovimento.CommandText = "SELECT ID_CATEGORIA FROM CATEGORIA WHERE NOME = '" + cbCategoria.Text + "'";
                foreach (DataRow registro in dMovimento.Tables["MOVIMENTO"].Rows)
                {
                    if (int.Parse(registro["ID_MOVIMENTO"].ToString()) == int.Parse(itemAlt.Tag.ToString()))
                    {
                        DataRow altRegistro = dMovimento.Tables["MOVIMENTO"].Rows.Find(int.Parse(itemAlt.Tag.ToString()));
                        altRegistro["Descricao"] = tbDescrição.Text;
                        altRegistro["Valor"] = float.Parse(tbValor.Text.Replace("R$", ""));
                        altRegistro["DATA_CADASTRO"] = DateTime.Parse(dtpData.Text);
                        break;
                    }
                }
                adaptadorMovimento.Update(dMovimento, "MOVIMENTO");
                Cs_Movimento movimento = new Cs_Movimento(tbDescrição.Text, float.Parse(tbValor.Text.Replace("R$", "")), DateTime.Parse(dtpData.Text), 0, 0, cbCategoria.Text);
                formularioInicial.AlteraMovimento(movimento, int.Parse(itemAlt.Tag.ToString()), numeroCategoria);
                Close();
            }
        }
    }
}
