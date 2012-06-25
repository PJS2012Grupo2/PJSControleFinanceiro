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
    public partial class buscaCategoria : Form
    {
        formularioInicial   formularioInicial;
        SqlDataAdapter      adaptador;

        public buscaCategoria(formularioInicial formularioInicial, SqlDataAdapter adaptador)
        {
            InitializeComponent();
            this.formularioInicial  = formularioInicial;
            this.adaptador          = adaptador;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            adaptador.Fill(formularioInicial.dadosFinanceiro, "tabelaBusca");
            string buscaCategoria = textBoxCategoria.Text;

            DataRow[] busca = formularioInicial.dadosFinanceiro.Tables["tabelaBusca"].Select("NOME LIKE '" + buscaCategoria + "'");
            formularioInicial.FiltrarCategoria(busca);
            Close();
        }
    }
}
