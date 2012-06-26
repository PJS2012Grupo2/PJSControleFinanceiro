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
    public partial class Form_Relatorios : Form
    {
        formularioInicial formPrincipal;
        public Form_Relatorios(formularioInicial form)
        {   
            InitializeComponent();
            formPrincipal = form;
        }

        private void Form_Relatorios_Load(object sender, EventArgs e)
        {
            cbCampo.SelectedIndex = 0;
        }

        private void FiltrarCampo(object sender, EventArgs e)
        {
            string[] diasSemana = { "Domingo", "Segunda-Feira", "Terça-Feira", "Quarta-Feira", "Quinta-Feira", "Sexta-Feira", "Sábado" };
            string campo = cbCampo.Text.Trim();
            if (campo == "Categoria")
            {
                listViewInformacoes.Items.Clear();
                foreach (ListViewItem item in formPrincipal.listViewCategorias.Items)
                {
                    if (item.Tag.ToString() != "todas")
                        listViewInformacoes.Items.Add(item.SubItems[0].Text.ToString());
                }
            }
            else if (campo == "Semana")
            {
                listViewInformacoes.Items.Clear();
                foreach (ListViewItem item in formPrincipal.listViewMovimentos.Items)
                {
                    var data = DateTime.Parse(item.SubItems[2].Text).DayOfWeek;
                    listViewInformacoes.Items.Add(data.ToString());
                }
            }
            else if (campo == "Mês")
            {
            }
            else if (campo == "Ano")
            {
            }
        }
    }
}
