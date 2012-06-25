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
    public partial class buscaData : Form
    {
        formularioInicial formularioInicial;
        SqlDataAdapter adaptador;

        public buscaData(formularioInicial formularioInicial, SqlDataAdapter adaptador)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
            this.adaptador = adaptador;

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DataSet dados = new DataSet();
            adaptador.Fill(dados, "tabelaBusca");
            DateTime buscaInicial = dateTimePickerInicial.Value;
            DateTime buscaFinal = dateTimePickerFinal.Value;

            DataRow[] busca = dados.Tables["tabelaBusca"].Select("DATA_CADASTRO >= '" + buscaInicial + "'" + "AND DATACADASTRO >= '" + buscaFinal);
            formularioInicial.FiltrarData(busca);
            Close();
        }

     }
}
