using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projetoFinalPJS
{
    public class Class_Movimento
    {
        
        public string decricao {get; set;}
        public float valor {get; set;}
        public DateTime data_cadastro { get; set; }
        public int id_categoria { get; set; }
        public int parcela { get; set; }
        public float valor_total { get; set; }


        public Class_Movimento(string desc, float val, DateTime dat, int id_categ, int parc, float val_total)
        {
          
            decricao = desc;
            valor = val;
            data_cadastro = dat;
            id_categoria = id_categ;
            parcela = parc;
            valor_total = val_total;
        }

    }
}


