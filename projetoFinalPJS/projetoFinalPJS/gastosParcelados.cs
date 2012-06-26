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
    public partial class gastosParcelados : Form
    {
       
        SqlConnection conexao = new SqlConnection(@"Data Source=ROPAS-PC\SQLEXPRESS;Initial Catalog=FINANCEIRO;Integrated Security=SSPI");
        SqlCommand comando = new SqlCommand();
        public gastosParcelados()
        {
          
            InitializeComponent();
            
            string[] meses = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            comboBox2.DataSource = meses;
            comando.Connection = conexao;
            conexao.Open();
        }     


        private void button2_Click(object sender, EventArgs e)
        {
            popular_combos();
                
        }


        public void popular_combos()
        {

            //CRIAR VETOR Para POPULAR GASTOS PARCELADOS

            //VETOR "SUJO" COM VALORES NÃO PARCELADOS
           
            comando.CommandText = "SELECT MAX(ID_MOVIMENTO) FROM MOVIMENTO WHERE PARCELA > 1";
            Object MContasParceladas = comando.ExecuteScalar();
            int MAXParcelados = int.Parse(MContasParceladas.ToString());
            conexao.Close();
            string[] todosMovimentos = new string[MAXParcelados];
            conexao.Open();


            for (int cont = 1; cont <= MAXParcelados; cont++)
            {
                comando.CommandText = "select DESCRICAO from MOVIMENTO where ID_MOVIMENTO=" + cont + "AND PARCELA > 1";
                Object name = comando.ExecuteScalar();
                if (name != null)
                {
                    todosMovimentos[cont - 1] = name.ToString();
                }

                else
                {
                    todosMovimentos[cont - 1] = "null";
                }
            }

            comando.CommandText = "SELECT COUNT (PARCELA) FROM MOVIMENTO WHERE PARCELA > 1";
            Object tContasParceladas = comando.ExecuteScalar();
            int qtdParcelados = int.Parse(tContasParceladas.ToString());
            //VETOR LIMPO COM VALORES PARCELADOS 
            string[] movParcelados = new string[qtdParcelados];
            int j = 0;
            for (int i = 0; i < MAXParcelados; i++)
            {


                if (todosMovimentos[i] != "null")
                {
                    movParcelados[j] = todosMovimentos[i];
                    j++;
                }

            }

            comando.CommandText = "select count(datepart(month,data_cadastro))from movimento where datepart(month,data_cadastro)='" + comboBox2.SelectedItem + "'and parcela >1";
            Object qtdMeses = comando.ExecuteScalar();
            int qtdMes = int.Parse(qtdMeses.ToString());
            string[] gastos = new string[qtdMes];
             int l = 0;
            for (int k = 0; k < qtdParcelados; k++)
            {

               
                comando.CommandText = "select descricao from movimento where datepart(month,data_cadastro)='" + comboBox2.SelectedItem + "'and descricao='" + movParcelados[k]+"'";
                Object qtddesc = comando.ExecuteScalar();
                if (qtddesc != null)
                { string desc = qtddesc.ToString(); 
                
                   gastos[l] = desc;
                   l++;
                }
                
            }

            comboBox1.DataSource = gastos;

            
          
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comando.CommandText = "select PARCELA FROM MOVIMENTO WHERE DESCRICAO ='" + comboBox1.Text + "';";
            Object parcela = comando.ExecuteScalar();
            textBox2.Text = parcela.ToString();

            comando.CommandText = "select valor FROM MOVIMENTO WHERE DESCRICAO ='" + comboBox1.Text + "';";
            Object valor = comando.ExecuteScalar();
            textBox5.Text = valor.ToString();

            comando.CommandText = "select valor_parcelado FROM MOVIMENTO WHERE DESCRICAO ='" + comboBox1.Text + "';";
            Object valor_parcelado = comando.ExecuteScalar();
            textBox7.Text = valor_parcelado.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comando.CommandText ="UPDATE MOVIMENTO SET VALOR=VALOR-VALOR_PARCELADO where DESCRICAO='"+comboBox1.Text+"'";
            comando.ExecuteScalar();
            comando.CommandText = "UPDATE MOVIMENTO SET PARCELA=PARCELA-1 where descricao='"+comboBox1.Text+"'";
            comando.ExecuteScalar();
            popular_combos();
        }
    }
}
