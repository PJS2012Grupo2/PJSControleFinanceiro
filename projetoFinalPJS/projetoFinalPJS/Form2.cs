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
    public partial class Form_Movimentação : Form
    {
        SqlDataAdapter adaptadorMovimento;
        private formularioInicial formularioInicial;

        private void Form_Movimentação_Load(object sender, EventArgs e)
        {
            cbCategoria.SelectedIndex = 0;
        }

        public Form_Movimentação(formularioInicial formularioInicial, SqlDataAdapter adaptadorMovimento)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
            this.adaptadorMovimento = adaptadorMovimento;
        }

        private void cadastrar_Click(object sender, EventArgs e)
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
                adaptadorMovimento.Fill(formularioInicial.dadosFinanceiro, "MOVIMENTO");
                DataRow novoMovimento = formularioInicial.dadosFinanceiro.Tables["MOVIMENTO"].NewRow();
                novoMovimento["Descricao"] = tbDescrição.Text;
                novoMovimento["Valor"] = tbValor.Text;
                novoMovimento["Data_Cadastro"] = DateTime.UtcNow;
                SqlCommand achaCategoria = formularioInicial.conexaoFinanceiro.CreateCommand();
                achaCategoria.CommandText = "SELECT ID_CATEGORIA FROM CATEGORIA WHERE NOME = '" + cbCategoria.Text + "'";
                int numeroCategoria = ((int)achaCategoria.ExecuteScalar());
                novoMovimento["Id_Categoria"] = numeroCategoria;
                formularioInicial.dadosFinanceiro.Tables["MOVIMENTO"].Rows.Add(novoMovimento);
                adaptadorMovimento.Update(formularioInicial.dadosFinanceiro, "MOVIMENTO");
                Cs_Movimento movimento = new Cs_Movimento(tbDescrição.Text, float.Parse(tbValor.Text), DateTime.Parse(dtpData.Text), 0, 0, cbCategoria.Text);
                formularioInicial.AdicionaMovimento(movimento, novoMovimento["ID_MOVIMENTO"].ToString(), numeroCategoria);

                Close();
            }
        }
    }
}
