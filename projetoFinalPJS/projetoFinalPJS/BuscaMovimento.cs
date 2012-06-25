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
    public partial class buscaMovimento : Form
    {
        formularioInicial   formularioInicial;
        SqlDataAdapter      adaptador;

        public buscaMovimento(formularioInicial formularioInicial, SqlDataAdapter adaptador)
        {
            InitializeComponent();
            this.formularioInicial  = formularioInicial;
            this.adaptador          = adaptador;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DataSet dados = new DataSet();
            adaptador.Fill(dados, "tabelaBusca");
            string buscaMovimento = textBoxMovimento.Text;

            DataRow[] busca = dados.Tables["tabelaBusca"].Select("NOME LIKE '" + buscaMovimento + "'");
            formularioInicial.FiltrarMovimento(busca);
            Close();

        }

       
    }
}
