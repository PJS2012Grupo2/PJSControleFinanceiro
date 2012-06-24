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
        private formularioInicial formularioInicial;
        SqlCommand comando = new SqlCommand();
        ListViewItem itemAlt;
        
        private void Form_Movimentação_Load(object sender, EventArgs e)
        {
            cbCategoria.SelectedIndex = 0;
            //trecho para inicializar escolha de quantidade de parcelas com 1
            numericUpDown1.Value = 1;

            if (itemAlt != null)
            {
                tbDescrição.Text = itemAlt.SubItems[0].Text;
                cbCategoria.Text = itemAlt.SubItems[3].Text;
                cbCategoria.SelectedText = itemAlt.SubItems[3].Text;
                tbValor.Text = itemAlt.SubItems[1].Text;
                dtpData.Value = DateTime.UtcNow; // TESTE
                //dtpData.Text = DateTime.Parse(itemAlt.SubItems[2].Text).ToString().Substring(0, 7);
                groupBox1.Enabled = false;
                if (int.Parse(itemAlt.SubItems[4].Text) > 0)
                    radioButton2.Checked = true;
                else
                    radioButton1.Checked = true;
                numericUpDown1.Value = int.Parse(itemAlt.SubItems[4].Text);
                numericUpDown1.Enabled = false;
                checkBox1.Enabled = false;
            }
            else
                tbValor.Text = "R$+";
            verificaValor();
        }

        public void verificaValor()
        {
            if (float.Parse(tbValor.Text.Replace("R$", "")) >= 0)
                tbValor.ForeColor = Color.Green;
            else
                tbValor.ForeColor = Color.Red;
        }

        public Form_Movimentação(formularioInicial formularioInicial, SqlDataAdapter adaptadorMovimento, ListViewItem itemSelecionado=null)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
            this.adaptadorMovimento = formularioInicial.adaptadorMovimento;
            this.itemAlt = itemSelecionado;

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
            //trecho para popular campo saldo total com valor correto
            tbSaldo.Enabled = false;
            comando.CommandText = "select * from SALDO";
            Object total_saldo = comando.ExecuteScalar();
            tbSaldo.Text = total_saldo.ToString();
            groupBox1.Enabled = true;
        }

        private void cadastrar_Click(object sender, EventArgs e)
        {
            if (tbDescrição.Text.Trim() == "")
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
                novoMovimento["Valor"] = tbValor.Text.Replace("R$", "");
                novoMovimento["Data_Cadastro"] = DateTime.UtcNow;
                SqlCommand achaCategoria = formularioInicial.conexaoFinanceiro.CreateCommand();
                achaCategoria.CommandText = "SELECT ID_CATEGORIA FROM CATEGORIA WHERE NOME = '" + cbCategoria.Text + "'";
                int numeroCategoria = ((int)achaCategoria.ExecuteScalar());
                novoMovimento["Id_Categoria"] = numeroCategoria;
                Cs_Movimento movimento = new Cs_Movimento(tbDescrição.Text, float.Parse(tbValor.Text.Replace("R$", "")), DateTime.UtcNow, 0, 0, cbCategoria.Text);
                    
                if (itemAlt != null)
                {
                    foreach (DataRow registro in formularioInicial.dadosFinanceiro.Tables["MOVIMENTO"].Rows)
                    {
                        if (int.Parse(registro["ID_MOVIMENTO"].ToString()) == int.Parse(itemAlt.Tag.ToString()))
                        {
                            registro["Descricao"] = tbDescrição.Text;
                            registro["Valor"] = float.Parse(tbValor.Text.Replace("R$", ""));
                            registro["DATA_CADASTRO"] = DateTime.Parse(dtpData.Text);
                            registro["ID_CATEGORIA"] = numeroCategoria;
                            adaptadorMovimento.Update(formularioInicial.dadosFinanceiro, "MOVIMENTO");
                            break;
                        }
                    }
                }
                else
                    formularioInicial.dadosFinanceiro.Tables["MOVIMENTO"].Rows.Add(novoMovimento);
                adaptadorMovimento.Update(formularioInicial.dadosFinanceiro, "MOVIMENTO");
                formularioInicial.carregaMovimentos(); //TESTE

                Saldo total_saldo= new Saldo(float.Parse(tbValor.Text.Replace("R$", "")));
                float total = float.Parse(tbValor.Text.Replace("R$", ""));
                bool negativar=formularioInicial.valor_Negativo();
                if (negativar == false)
                {
                    // comando da inserção 
                    comando.CommandText = "UPDATE SALDO SET TOTAL = TOTAL+ (" + total + ")";
                    //executa a inserção dos dados no sql 
                    comando.ExecuteNonQuery();
                }
                else
                {
                    // comando da inserção 
                    comando.CommandText = "UPDATE SALDO SET TOTAL = TOTAL- (" + total + ")";
                    //executa a inserção dos dados no sql 
                    comando.ExecuteNonQuery();
                 }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }

        private void Form_Movimentação_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = formularioInicial.conexaoFinanceiro;
                comando.CommandText = "SELECT * FROM Saldo";
                Object total_saldo = comando.ExecuteScalar();
                formularioInicial.toolStripStatusLabel1.Text = "Lembretes: Saldo=" + total_saldo.ToString() + "";
            }
            catch
            {
                MessageBox.Show("Erro", "Erro de conexão com a base de dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tbValor_TextChanged(object sender, EventArgs e)
        {
            verificaValor();
        }
    }
}
