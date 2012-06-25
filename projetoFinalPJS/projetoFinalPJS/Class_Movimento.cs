
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
    public class Class_Movimento
    {
        public string descricao { get; set; }
        public float valor { get; set; }
        public DateTime dataCadastro { get; set; }
        public int parcela { get; set; }
        //VALOR PARCELADO
        public float valorParcelado { get; set; }
        public string categoria { get; set; }

        public Class_Movimento(string descricao, float valor, DateTime datacadastro, int parcelas, float valorParcelado, string categoria)
        {
            this.descricao = descricao;
            this.valor = valor;
            this.dataCadastro = dataCadastro;
            this.parcela = parcelas;
            //VALOR PARCELADO
            this.valorParcelado = valorParcelado;
            this.categoria = categoria;
        }
    }
}
