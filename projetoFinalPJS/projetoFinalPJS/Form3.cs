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
        formularioInicial formInicial;
        SqlDataAdapter adaptadorCategoria;
        SqlConnection conexao = new SqlConnection(@"Data Source=ROPAS-PC\SQLEXPRESS;Initial Catalog=FINANCEIRO;Integrated Security=SSPI");
        SqlCommand comando = new SqlCommand();



        public Form_Categoria(formularioInicial form, SqlDataAdapter dCategoria)
        {
            InitializeComponent();
            formInicial = form;
            adaptadorCategoria = dCategoria;
        }

        private void salvarCtg_Click(object sender, EventArgs e)
        {
             SqlConnection conn = new SqlConnection(@"Data Source=ROPAS-PC\SQLEXPRESS;Initial Catalog=FINANCEIRO;Integrated Security=SSPI");
                conn.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conn;
                comando.CommandText = "select COUNT (ID_CATEGORIA) from CATEGORIA";
                Object total_categoria = comando.ExecuteScalar();
                int total_categ=Convert.ToInt32(total_categoria);
                
                

                    comando.CommandText = "select NOME from CATEGORIA where NOME LIKE '%"+tbDescriçãoCtg.Text.ToUpper()+"%'";
                    Object nome_Categoria = comando.ExecuteScalar();

                    if (nome_Categoria != null)
                    {

                        if (tbDescriçãoCtg.Text.ToUpper().Equals(nome_Categoria.ToString().ToUpper()))
                        {
                            MessageBox.Show("Esta categoria já existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                     
                        }
                    }
                    
                    if (nome_Categoria==null)
                    {
                       comando.CommandText = "insert into CATEGORIA (NOME,LIMITE) values('"+tbDescriçãoCtg.Text.ToUpper()+"','"+Convert.ToDecimal(tbOrçamentoCtg.Text)+"')";
                       comando.ExecuteScalar();
                      
                    }



                

             
                    conn.Close();
             

     
              


            //novaCategoria["Nome"] = tbDescriçãoCtg.Text;
            //novaCategoria["Limite"] = tbOrçamentoCtg.Text;
            //dCategoria.Tables["CATEGORIA"].Rows.Add(novaCategoria);
            //adaptadorCategoria.Update(dCategoria, "CATEGORIA");
            //adaptadorCategoria.Fill(dCategoria, "CATEGORIA");

            Cs_Categorias categoria = new Cs_Categorias(tbDescriçãoCtg.Text, float.Parse(tbOrçamentoCtg.Text));
            formInicial.VisualizarCategoria(categoria);

            Close();
        }
    }
}
