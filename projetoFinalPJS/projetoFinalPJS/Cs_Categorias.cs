using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projetoFinalPJS
{
    public class Cs_Categorias
    {
        public string Nome_Categoria { get; set; }
        public float Orçamento_Categoria { get; set; }
        public float Orçamento_Restante { get; set; }

        public Cs_Categorias(string descricao, float orcamento)
        {
            Nome_Categoria = descricao;
            Orçamento_Categoria = orcamento;
        }
    }
}


       
