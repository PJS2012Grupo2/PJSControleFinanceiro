using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projetoFinalPJS
{
    public class Cs_Categorias
    {
        public string Nome_Categoria { get; set; }
        public float Orçamento_Restante { get; set; }
        public float Orçamento_Categoria { get; set; }

        public Cs_Categorias(string descricao, float orcamento_restante, float orcamento)
        {
            Nome_Categoria = descricao;
            Orçamento_Restante = orcamento_restante;
            Orçamento_Categoria = orcamento;
            
        }
    }
}
