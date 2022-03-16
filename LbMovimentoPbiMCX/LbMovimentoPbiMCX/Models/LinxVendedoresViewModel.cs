
using System.ComponentModel;


namespace Models
{
   public  class LinxVendedoresViewModel
    {
        [Description("portal")]
        public string portal { get; set; }

        [Description("cod_vendedor")]
        public string cod_vendedor { get; set; }

        [Description("nome_vendedor")]
        public string nome_vendedor { get; set; }

        [Description("tipo_vendedor")]
        public string tipo_vendedor { get; set; }

        [Description("end_vend_rua")]
        public string end_vend_rua { get; set; }

        [Description("end_vend_numero")]
        public string end_vend_numero { get; set; }

        [Description("end_vend_complemento")]
        public string end_vend_complemento { get; set; }

        [Description("end_vend_bairro")]
        public string end_vend_bairro { get; set; }

        [Description("end_vend_cep")]
        public string end_vend_cep { get; set; }

        [Description("end_vend_cidade")]
        public string end_vend_cidade { get; set; }

        [Description("end_vend_uf")]
        public string end_vend_uf { get; set; }

        [Description("fone_vendedor")]
        public string fone_vendedor { get; set; }

        [Description("mail_vendedor")]
        public string mail_vendedor { get; set; }

        [Description("dt_upd")]
        public string dt_upd { get; set; }

        [Description("cpf_vendedor")]
        public string cpf_vendedor { get; set; }

        [Description("ativo")]
        public string ativo { get; set; }

        [Description("data_admissao")]
        public string data_admissao { get; set; }

        [Description("data_saida")]
        public string data_saida { get; set; }

        [Description("timestamp")]
        public string timestamp { get; set; }

    }
}
