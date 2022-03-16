using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class ProdutosDetalhesViewModel
    {
        [Description("portal")]
        public string portal { get; set; }

        [Description("cnpj_emp")]
        public string cnpj_emp { get; set; }

        [Description("cod_produto")]
        public string cod_produto { get; set; }

        [Description("cod_barra")]
        public string cod_barra { get; set; }

        [Description("quantidade")]
        public string quantidade { get; set; }

        [Description("preco_custo")]
        public string preco_custo { get; set; }

        [Description("preco_venda")]
        public string preco_venda { get; set; }

        [Description("custo_medio")]
        public string custo_medio { get; set; }

        [Description("id_config_tributaria")]
        public string id_config_tributaria { get; set; }

        [Description("desc_config_tributaria")]
        public string desc_config_tributaria { get; set; }

        [Description("despesas1")]
        public string despesas1 { get; set; }

        [Description("qtde_minima")]
        public string qtde_minima { get; set; }

        [Description("qtde_maxima")]
        public string qtde_maxima { get; set; }

        [Description("ipi")]
        public string ipi { get; set; }

        [Description("timestamp")]
        public string timestamp { get; set; }

                    
            


    }
}
