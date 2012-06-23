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
        string[] parcelar = { "Sim", "Não" };
        SqlDataAdapter adaptadorMovimento;
       // SqlDataAdapter preencherCategoria;
        private formularioInicial formularioInicial;
        SqlCommand comando = new SqlCommand();

        public Form_Movimentação(formularioInicial formularioInicial, SqlDataAdapter adaptadorMovimento)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
            this.adaptadorMovimento = formularioInicial.adaptadorMovimento;

            //trecho para popular combo box de categoria
            comando.Connection = formularioInicial.conexaoFinanceiro;
            comando.CommandText = "select count (NOME) from CATEGORIA";
            Object retorno = comando.ExecuteScalar();
            int qtd_categorias=Convert.ToInt32(retorno);
            Object name = new Object();
            string[] TiposCategorias = new string[qtd_categorias];
            for (int cont = 1; cont <= qtd_categorias; cont++)
            { 
                comando.CommandText = "select NOME from CATEGORIA where ID_CATEGORIA = "+cont+"";
                name=comando.ExecuteScalar();
                TiposCategorias[cont-1] = name.ToString(); 
            }
            this.cbCategoria.DataSource = TiposCategorias;

            //trecho para inicializar escolha de quantidade de parcelas com 1
            numericUpDown1.Value = 1;

            //trecho para popular campo saldo total com valor correto
            tbSaldo.Enabled = false;
            comando.CommandText = "select * from SALDO";
            Object total_saldo = comando.ExecuteScalar();
            tbSaldo.Text = total_saldo.ToString();
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
                DataSet dMovimento = new DataSet();
                adaptadorMovimento.Fill(dMovimento, "MOVIMENTO");
                DataRow novoMovimento = dMovimento.Tables["MOVIMENTO"].NewRow();
                novoMovimento["Descricao"] = tbDescrição.Text;
                novoMovimento["Valor"] = tbValor.Text;
                novoMovimento["Data_Cadastro"] = DateTime.UtcNow;
                SqlCommand achaCategoria = formularioInicial.conexaoFinanceiro.CreateCommand();
                achaCategoria.CommandText = "SELECT ID_CATEGORIA FROM CATEGORIA WHERE NOME = '" + cbCategoria.Text + "'";
                int numeroCategoria = ((int)achaCategoria.ExecuteScalar());
                novoMovimento["Id_Categoria"] = numeroCategoria;
                dMovimento.Tables["MOVIMENTO"].Rows.Add(novoMovimento);
                adaptadorMovimento.Update(dMovimento, "MOVIMENTO");
                adaptadorMovimento.Fill(dMovimento, "MOVIMENTO");
                //Cs_Movimento movimento = new Cs_Movimento(tbDescrição.Text, float.Parse(tbValor.Text), DateTime.Parse(dtpData.Text), 0, 0, cbCategoria.Text);
                //formularioInicial.AdicionaMovimento(movimento);

                Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown1.Value = 1;
            label4.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            label4.Enabled = true;
        }     
        
    }
}
