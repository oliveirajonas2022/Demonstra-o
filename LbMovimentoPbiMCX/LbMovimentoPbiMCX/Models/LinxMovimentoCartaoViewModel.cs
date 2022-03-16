using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LinxMovimentoCartaoViewModel
    {
        [Description("portal")]
        public string portal { get; set; }

        [Description("cnpj_emp")]
        public string cnpj_emp { get; set; }

        [Description("codlojasitef")]
        public string codlojasitef { get; set; }

        [Description("data_lancamento")]
        public string data_lancamento { get; set; }

        [Description("identificador")]
        public string identificador { get; set; }

        [Description("cupomfiscal")]
        public string cupomfiscal { get; set; }

        [Description("credito_debito")]
        public string credito_debito { get; set; }

        [Description("id_cartao_bandeira")]
        public string id_cartao_bandeira { get; set; }

        [Description("descricao_bandeira")]
        public string descricao_bandeira { get; set; }

        [Description("valor")]
        public string valor { get; set; }

        [Description("ordem_cartao")]
        public string ordem_cartao { get; set; }

        [Description("nsu_host")]
        public string nsu_host { get; set; }

        [Description("nsu_sitef")]
        public string nsu_sitef { get; set; }

        [Description("cod_autorizacao")]
        public string cod_autorizacao { get; set; }

        [Description("id_antecipacoes_financeiras")]
        public string id_antecipacoes_financeiras { get; set; }

        [Description("transacao_servico_terceiro")]
        public string transacao_servico_terceiro { get; set; }

        [Description("texto_comprovante")]
        public string texto_comprovante { get; set; }

        [Description("id_maquineta_pos")]
        public string id_maquineta_pos { get; set; }

        [Description("descricao_maquineta")]
        public string descricao_maquineta { get; set; }

        [Description("serie_maquineta")]
        public string serie_maquineta { get; set; }

        [Description("timestamp")]
        public string timestamp { get; set; }


    }
}
