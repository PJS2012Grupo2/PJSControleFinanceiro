﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projetoFinalPJS
{
    public partial class formularioInicial : Form
    {

        private List<Cs_Categorias> listaCategorias;

        public formularioInicial()
        {
            InitializeComponent();
            
            dataGridView1.DataSource = listaCategorias;
        }

        private void entradaDeValoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Movimentação Var_Form_Movimentação = new Form_Movimentação();
            Var_Form_Movimentação.ShowDialog();
        }

        private void saídaDeValoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Movimentação Var_Form_Movimentação = new Form_Movimentação();
            Var_Form_Movimentação.ShowDialog();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Categoria Var_Form_Categoria = new Form_Categoria();
            Var_Form_Categoria.ShowDialog();
        }

        private void formularioInicial_Load(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "Data Source=PC18LAB3\\MSSQLSERVER1;Initial Catalog=Financeiro;Integrated Security=SSPI";

            SqlDataAdapter adaptador = new SqlDataAdapter();
            SqlCommand comandoSelecao = new SqlCommand("Select * from Categoria", conexao);
            adaptador.SelectCommand = comandoSelecao;

            SqlCommand comandoInsercao = new SqlCommand("Insert into (Categoria) values (@nome, @limite)");
            adaptador.SelectCommand = comandoInsercao;
        }
    }
}
