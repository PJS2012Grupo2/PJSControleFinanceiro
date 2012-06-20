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
        public SqlDataAdapter adaptadorCategoria;
        public Form_Categoria(formularioInicial form, SqlDataAdapter dCategoria)
        {
            InitializeComponent();
            formInicial = form;
            adaptadorCategoria = dCategoria;
        }

        private void salvarCtg_Click(object sender, EventArgs e)
        {
            DataSet dCategoria = new DataSet();
            adaptadorCategoria.Fill(dCategoria, "CATEGORIA");
            DataRow novaCategoria = dCategoria.Tables["CATEGORIA"].NewRow();
            novaCategoria["Nome"] = tbDescriçãoCtg.Text;
            novaCategoria["Limite"] = tbOrçamentoCtg.Text;
            dCategoria.Tables["CATEGORIA"].Rows.Add(novaCategoria);
            adaptadorCategoria.Update(dCategoria, "CATEGORIA");
            adaptadorCategoria.Fill(dCategoria, "CATEGORIA");

            Cs_Categorias categoria = new Cs_Categorias(tbDescriçãoCtg.Text, float.Parse(tbOrçamentoCtg.Text));
            formInicial.VisualizarCategoria(categoria);

            Close();
        }
    }
}
