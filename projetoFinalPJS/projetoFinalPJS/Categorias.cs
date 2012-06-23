using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projetoFinalPJS
{
    public partial class Form_Categoria : Form
    {
        private formularioInicial formularioInicial;
        private System.Data.SqlClient.SqlDataAdapter adaptadorCategoria;

        public Form_Categoria(formularioInicial formularioInicial, System.Data.SqlClient.SqlDataAdapter adaptadorCategoria)
        {
            InitializeComponent();
            this.formularioInicial = formularioInicial;
            this.adaptadorCategoria = adaptadorCategoria;
        }
    }
}
