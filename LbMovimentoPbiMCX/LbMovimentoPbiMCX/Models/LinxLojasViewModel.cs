using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class LinxLojasViewModel
    {
        [Description("portal")]
        public string portal { get; set; }

        [Description("empresa")]
        public string empresa { get; set; }

        [Description("nome_emp")]
        public string nome_emp { get; set; }

        [Description("razao_emp")]
        public string razao_emp { get; set; }

        [Description("cnpj_emp")]
        public string cnpj_emp { get; set; }

        [Description("inscricao_emp")]
        public string inscricao_emp { get; set; }

        [Description("endereco_emp")]
        public string endereco_emp { get; set; }

        [Description("num_emp")]
        public string num_emp { get; set; }

        [Description("complement_emp")]
        public string complement_emp { get; set; }

        [Description("bairro_emp")]
        public string bairro_emp { get; set; }

        [Description("cep_emp")]
        public string cep_emp { get; set; }

        [Description("cidade_emp")]
        public string cidade_emp { get; set; }

        [Description("estado_emp")]
        public string estado_emp { get; set; }

        [Description("fone_emp")]
        public string fone_emp { get; set; }

        [Description("email_emp")]
        public string email_emp { get; set; }

        [Description("cod_ibge_municipio")]
        public string cod_ibge_municipio { get; set; }

        [Description("data_criacao_emp")]
        public string data_criacao_emp { get; set; }

        [Description("data_criacao_portal")]
        public string data_criacao_portal { get; set; }

        [Description("sistema_tributacao")]
        public string sistema_tributacao { get; set; }

        [Description("regime_tributario")]
        public string regime_tributario { get; set; }

        [Description("area_empresa")]
        public string area_empresa { get; set; }

        [Description("timestamp")]
        public string timestamp { get; set; }

        [Description("sigla_empresa")]
        public string sigla_empresa { get; set; }

        [Description("id_classe_fiscal")]
        public string id_classe_fiscal { get; set; }

        [Description("centro_distribuicao")]
        public string centro_distribuicao { get; set; }

        [Description("inscricao_municipal_emp")]
        public string inscricao_municipal_emp { get; set; }

        [Description("cnae_emp")]
        public string cnae_emp { get; set; }

    }
}
