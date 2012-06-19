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
    public class Cs_Movimento
    {
        public string descricao { get; set; }
        public float valor { get; set; }
        public DateTime dataCadastro { get; set; }
        public int parcela { get; set; }
        public float valorTotal { get; set; }
        public string categoria { get; set; }

        public Cs_Movimento(string descricao, float valor, DateTime datacadastro, int parcelas, float valorTotal, string categoria)
        {
            this.descricao = descricao;
            this.valor = valor;
            this.dataCadastro = dataCadastro;
            this.parcela = parcelas;
            this.valorTotal = valorTotal;
            this.categoria = categoria;
        }
    }
}