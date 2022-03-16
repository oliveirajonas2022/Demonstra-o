using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LinxGrupoLojasViewModelcs
    {
        [Description("cnpj")]
        public string CNPJ { get; set; }

        [Description("nome_empresa")]
        public string NOME_EMPRESA { get; set; }

        [Description("id_empresas_rede")]
        public string ID_EMPRESAS_REDE{ get; set; }

        [Description("rede")]
        public string REDE{ get; set; }

        [Description("portal")]
        public string  PORTAL { get; set; }

        [Description("nome_portal")]
        public string NOME_PORTAL { get; set; }

        [Description("empresa")]
        public string EMPRESA { get; set; }

        [Description("lojas_proprias")]
        public string LOJAS_PROPRIAS { get; set; }

        [Description("classificacao_portal")]
        public string CLASSIFICACAO_PORTAL { get; set; }
        [Description("integrar")]
        public byte Integrar { get; set; } = 0;

        [Description("legado")]
        public byte legado { get; set; } = 0;


    }
}
