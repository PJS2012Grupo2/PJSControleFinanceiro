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
    public partial class FormAlteracaoMovimentos : Form
    {
        SqlDataAdapter adaptadorMovimento;
        private formularioInicial formularioInicial;
        ListViewItem itemAlt;

        public FormAlteracaoMovimentos(SqlDataAdapter adaptador, formularioInicial form1, ListViewItem itemSelecionado)
        {
            InitializeComponent();
            this.adaptadorMovimento = adaptador;
            this.formularioInicial = form1;
            this.itemAlt = itemSelecionado;
        }

        private void FormAlteracaoMovimentos_Load(object sender, EventArgs e)
        {
            tbDescrição.Text = itemAlt.SubItems[0].Text;
            cbCategoria.Text = itemAlt.SubItems[3].Text;
            cbCategoria.SelectedText = itemAlt.SubItems[3].Text;
            tbValor.Text = itemAlt.SubItems[1].Text;
            dtpData.Text = DateTime.Parse(itemAlt.SubItems[2].Text).ToString().Substring(0, 7);
        }
    }
}
