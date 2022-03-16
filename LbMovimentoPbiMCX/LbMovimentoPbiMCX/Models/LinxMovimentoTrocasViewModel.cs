using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LinxMovimentoTrocasViewModel
    {

        [Description("portal")]
        public string portal { get; set; }

        [Description("cnpj_emp")]
        public string cnpj_emp { get; set; }

        [Description("identificador")]
        public string identificador { get; set; }

        [Description("num_vale")]
        public string num_vale { get; set; }

        [Description("valor_vale")]

        public string valor_vale { get; set; }


        [Description("motivo")]
        public string motivo { get; set; }

        [Description("doc_origem")]
        public string doc_origem { get; set; }

        [Description("serie_origem")]
        public string serie_origem { get; set; }

        [Description("doc_vend")]
        public string doc_venda { get; set; }

        [Description("serie_venda")]
        public string serie_venda { get; set; }

        [Description("excluido")]
        public string excluido { get; set; }

        [Description("timestamp")]
        public string timestamp { get; set; }

        [Description("desfazimento")]
        public string desfazimento { get; set; }
    }
}
