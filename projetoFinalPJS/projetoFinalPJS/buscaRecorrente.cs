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
    public partial class buscaRecorrente : Form
    {
        formularioInicial   formularioInicial;
        SqlDataAdapter      adaptador;

        public buscaRecorrente(formularioInicial formularioInicial, SqlDataAdapter adaptador)
        {
            InitializeComponent();
            this.formularioInicial  = formularioInicial;
            this.adaptador          = adaptador;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DataSet dados = new DataSet();
            adaptador.Fill(dados, "tabelaBusca");
            string buscaRecorrentes = textBoxRecorrente.Text;

            DataRow[] busca = dados.Tables["tabelaBusca"].Select("NOME LIKE '" + buscaRecorrentes + "'");
            formularioInicial.FiltrarRecorrentes(busca);
            Close();
        }
    }
}
