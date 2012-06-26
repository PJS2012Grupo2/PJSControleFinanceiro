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
        SqlDataAdapter preencherCategoria;
        private formularioInicial formularioInicial;
        SqlConnection conexao = new SqlConnection(@"Data Source=ROPAS-PC\SQLEXPRESS;Initial Catalog=FINANCEIRO;Integrated Security=SSPI");
        SqlCommand comando = new SqlCommand();

        public Form_Movimentação(formularioInicial formularioInicial, SqlDataAdapter adaptadorMovimento)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
            this.adaptadorMovimento = adaptadorMovimento;
            
            //trecho para popular combo box de categoria
            int qtd_categorias=0;
            comando.Connection = conexao;
            conexao.Open();
            comando.CommandText = "select MAX (ID_CATEGORIA) from CATEGORIA";
            Object retorno = comando.ExecuteScalar();

            //há um bug aqui se o banco estiver vazio
            if (retorno != null)
            {
                qtd_categorias = Convert.ToInt32(retorno);
            }

            comando.CommandText = "select COUNT (ID_CATEGORIA) from CATEGORIA";
            Object total_Categ = comando.ExecuteScalar();
            int total_Categoria=Convert.ToInt32(total_Categ);
            conexao.Close();

            string[] TiposCategorias = new string[qtd_categorias];
            conexao.Open();


            for (int cont = 1; cont <= qtd_categorias; cont++)
            { 
            comando.CommandText = "select NOME from CATEGORIA where ID_CATEGORIA="+cont+"";
            Object name=comando.ExecuteScalar();
            if (name != null)
            {
                TiposCategorias[cont - 1] = name.ToString();
            }

            else 
            {
                TiposCategorias[cont - 1] = "null";
            }
            }

            string[] C = new string[total_Categoria];
            int j=0;
            for (int i = 0; i < qtd_categorias; i++)
            {
          
               
                    if (TiposCategorias[i] != "null")
                    {
                        C[j] = TiposCategorias[i];
                        j++;
                    }
                
            }

            conexao.Close();
            this.cbCategoria.DataSource = C;

            //trecho para inicializar escolha de quantidade de parcelas com 1
            numericUpDown1.Value = 1;

            //trecho para popular campo saldo total com valor correto
            tbSaldo.Enabled = false;
            conexao.Open();
            comando.CommandText = "select * from SALDO";
            Object total_saldo = comando.ExecuteScalar();
            tbSaldo.Text = total_saldo.ToString();
            conexao.Close();
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
                DataSet dMovimento = new DataSet();
                adaptadorMovimento.Fill(dMovimento, "MOVIMENTO");
                DataRow novoMovimento = dMovimento.Tables["MOVIMENTO"].NewRow();
                novoMovimento["Descricao"] = tbDescrição.Text;
                novoMovimento["Valor"] = tbValor.Text;
                novoMovimento["Data_Cadastro"] = dtpData.Value.ToString("dd-MM-yyyy");

                SqlCommand achaCategoria = formularioInicial.conexaoFinanceiro.CreateCommand();
                achaCategoria.CommandText = "SELECT ID_CATEGORIA FROM CATEGORIA WHERE NOME = '" + cbCategoria.Text + "'";
                int numeroCategoria = ((int)achaCategoria.ExecuteScalar());
                novoMovimento["Id_Categoria"] = numeroCategoria;


                int parcelas = 1;
                if (radioButton2.Checked)
                {
                    parcelas = int.Parse(numericUpDown1.Value.ToString());
                }
                else
                {
                    parcelas = 1;
                }
                novoMovimento["PARCELA"] = parcelas;


                dMovimento.Tables["MOVIMENTO"].Rows.Add(novoMovimento);
                adaptadorMovimento.Update(dMovimento, "MOVIMENTO");
                adaptadorMovimento.Fill(dMovimento, "MOVIMENTO");
                //Cs_Movimento movimento = new Cs_Movimento(tbDescrição.Text, float.Parse(tbValor.Text), DateTime.Parse(dtpData.Text), 0, 0, cbCategoria.Text);
                //formularioInicial.AdicionaMovimento(movimento);

                 Saldo total_saldo= new Saldo(float.Parse(tbValor.Text));
                 float total = float.Parse(tbValor.Text);
                 string categoria = cbCategoria.SelectedItem.ToString().ToUpper();
                 bool negativar=formularioInicial.valor_Negativo();
                 if (negativar == false)
                 {
                     // comando da inserção 
                     comando.CommandText = "UPDATE SALDO SET TOTAL = TOTAL+ (" + total + ")";
                     // abre a conexão
                     conexao.Open();
                     //executa a inserção dos dados no sql 
                     comando.ExecuteNonQuery();
                     conexao.Close();

                     // comando da inserção 
                     comando.CommandText = "UPDATE CATEGORIA SET VALOR_ATUAL = VALOR_ATUAL+ (" + total + ") WHERE nome='"+categoria.ToUpper()+"'";
                     // abre a conexão
                     conexao.Open();
                     //executa a inserção dos dados no sql 
                     comando.ExecuteNonQuery();
                     formularioInicial.listViewCategorias.Items.Clear();
                     formularioInicial.listViewMovimentos.Items.Clear();
                     formularioInicial.conexaoDados();
                     conexao.Close();

                 }
                 else
                 { 
                   // abre a conexão
                     conexao.Open();
                   // comando da inserção 
                     comando.CommandText = "UPDATE SALDO SET TOTAL = TOTAL- (" + total + ")";
                     comando.ExecuteNonQuery();

                     comando.CommandText = "UPDATE CATEGORIA SET VALOR_ATUAL = VALOR_ATUAL - (" + float.Parse(tbValor.Text) + ") WHERE NOME IN ('" + cbCategoria.SelectedValue.ToString().ToUpper() + "')";
                     comando.ExecuteNonQuery();

                     formularioInicial.listViewCategorias.Items.Clear();
                     formularioInicial.listViewMovimentos.Items.Clear();
                     formularioInicial.conexaoDados();
                     conexao.Close();       
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


            formularioInicial.var_Saida = false;
            InitializeComponent();
            try
            {
                //MOSTRA SALDO TOTAL NO RODAPÉ
                SqlConnection conn = new SqlConnection(@"Data Source=ROPAS-PC\SQLEXPRESS;Initial Catalog=FINANCEIRO;Integrated Security=SSPI");
                conn.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conn;

                comando.CommandText = "select * from SALDO";
                Object total_saldo = comando.ExecuteScalar();
                formularioInicial.toolStripStatusLabel1.Text = "Lembretes: Saldo=" + total_saldo.ToString() + "";
              
                //invocaR AVISO DE ESTOURO DE SALDO CATEGORIA
                popular_rodapé();
            }
            catch (Exception c)
            {
                MessageBox.Show("erro", "erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        public void popular_rodapé()
        {
        //AVISO DE ESTOURO DE SALDO CATEGORIA
                comando.Connection = conexao;
                conexao.Open();
                comando.CommandText = "select MAX (ID_CATEGORIA) from CATEGORIA";
                Object retorno = comando.ExecuteScalar();
                int qtd_categorias = Convert.ToInt32(retorno);
                conexao.Close();

                conexao.Open();
                comando.CommandText = "select COUNT (ID_CATEGORIA) from CATEGORIA";
                Object total_Categ = comando.ExecuteScalar();
                int total_Categoria = Convert.ToInt32(total_Categ);
                conexao.Close();

                string[] TiposCategorias = new string[qtd_categorias];
                conexao.Open();


                for (int cont = 1; cont <= qtd_categorias; cont++)
                {
                    comando.CommandText = "select NOME from CATEGORIA where ID_CATEGORIA=" + cont + "";
                    Object name = comando.ExecuteScalar();
                    if (name != null)
                    {
                        TiposCategorias[cont - 1] = name.ToString();
                    }

                    else
                    {
                        TiposCategorias[cont - 1] = "null";
                    }
                }

                string[] C = new string[total_Categoria];
                int j = 0;
                for (int i = 0; i < qtd_categorias; i++)
                {


                    if (TiposCategorias[i] != "null")
                    {
                        C[j] = TiposCategorias[i];
                        j++;
                    }

                }
                conexao.Close();

                for (int cont = 0; cont < total_Categoria; cont++)
                {
                    conexao.Open();
                    comando.CommandText = "select VALOR_ATUAL from CATEGORIA where nome='" + C[cont] + "'";
                    Object valor = comando.ExecuteScalar();
                    float vAtual = float.Parse(valor.ToString());
                    conexao.Close();
                    conexao.Open();
                    comando.CommandText = "select NOME from CATEGORIA where nome='" + C[cont] + "'";
                    Object nomeCategoria = comando.ExecuteScalar();
                    String n = nomeCategoria.ToString();
                    conexao.Close();
                    if (vAtual < 0)
                    {
                        formularioInicial.toolStripStatusLabel3.Text = "Avisos: Categoria " + n + ", ultrapassou limite, valor atual: " + vAtual + "";
                        break;
                    }
                    else 
                    {
                        formularioInicial.toolStripStatusLabel3.Text = "Avisos:- "; 
                    }

                }

        
        }

        
        
    }
}
