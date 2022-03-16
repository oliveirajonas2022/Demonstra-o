using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LinxMovimentoViewModel
    {
        [Description("portal")]
        public string portal { get; set; }

        [Description("cnpj_emp")]
        public string cnpj_emp { get; set; }

        [Description("transacao")]
        public string transacao { get; set; }

        [Description("usuario")]
        public string usuario { get; set; }

        [Description("documento")]
        public string documento { get; set; }

        [Description("chave_nf")]
        public string chave_nf { get; set; }

        [Description("ecf")]
        public string ecf { get; set; }

        [Description("numero_serie_ecf ")]
        public string numero_serie_ecf { get; set; }

        [Description("modelo_nf ")]
        public string modelo_nf { get; set; }

        [Description("data_documento")]
        public string data_documento { get; set; }

        [Description("data_lancamento")]
        public string data_lancamento { get; set; }

        [Description("codigo_cliente")]
        public string codigo_cliente { get; set; }

        [Description("serie")]
        public string serie { get; set; }

        [Description("desc_cfop")]
        public string desc_cfop { get; set; }

        [Description("id_cfop")]
        public string id_cfop { get; set; }

        [Description("cod_vendedor ")]
        public string cod_vendedor { get; set; }

        [Description("quantidade")]
        public string quantidade { get; set; }

        [Description("preco_custo")]
        public string preco_custo { get; set; }

        [Description("valor_liquido")]
        public string valor_liquido { get; set; }

        [Description("desconto")]
        public string desconto { get; set; }

        [Description("cst_icms")]
        public string cst_icms { get; set; }

        [Description("cst_pis")]
        public string cst_pis { get; set; }

        [Description("cst_cofins")]
        public string cst_cofins { get; set; }

        [Description("cst_ipi")]
        public string cst_ipi { get; set; }

        [Description("valor_icms")]
        public string valor_icms { get; set; }

        [Description("aliquota_icms ")]
        public string aliquota_icms { get; set; }

        [Description("base_icms")]
        public string base_icms { get; set; }

        [Description("valor_pis")]
        public string valor_pis { get; set; }

        [Description("aliquota_pis")]
        public string aliquota_pis { get; set; }

        [Description("base_pis")]
        public string base_pis { get; set; }

        [Description("valor_cofins")]
        public string valor_cofins { get; set; }

        [Description("aliquota_cofins")]
        public string aliquota_cofins { get; set; }

        [Description("base_cofins")]
        public string base_cofins { get; set; }

        [Description("valor_icms_st")]
        public string valor_icms_st { get; set; }

        [Description("aliquota_icms_st")]
        public string aliquota_icms_st { get; set; }

        [Description("base_icms_st")]
        public string base_icms_st { get; set; }

        [Description("valor_ipi")]
        public string valor_ipi { get; set; }

        [Description("aliquota_ipi")]
        public string aliquota_ipi { get; set; }

        [Description("base_ipi")]
        public string base_ipi { get; set; }

        [Description("valor_total")]
        public string valor_total { get; set; }

        [Description("forma_dinheiro")]
        public string forma_dinheiro { get; set; }

        [Description("total_dinheiro")]
        public string total_dinheiro { get; set; }

        [Description("forma_cheque")]
        public string forma_cheque { get; set; }

        [Description("total_cheque")]
        public string total_cheque { get; set; }

        [Description("forma_cartao")]
        public string forma_cartao { get; set; }

        [Description("total_cartao")]
        public string total_cartao { get; set; }

        [Description("forma_crediario")]
        public string forma_crediario { get; set; }

        [Description("total_crediario")]
        public string total_crediario { get; set; }

        [Description("forma_convenio")]
        public string forma_convenio { get; set; }

        [Description("total_convenio")]
        public string total_convenio { get; set; }

        [Description("frete")]
        public string frete { get; set; }

        [Description("operacao")]
        public string operacao { get; set; }

        [Description("tipo_transacao")]
        public string tipo_transacao { get; set; }

        [Description("cod_produto")]
        public string cod_produto { get; set; }

        [Description("cod_barra")]
        public string cod_barra { get; set; }

        [Description("cancelado")]
        public string cancelado { get; set; }

        [Description("excluido")]
        public string excluido { get; set; }

        [Description("soma_relatorio")]
        public string soma_relatorio { get; set; }

        [Description("identificador")]
        public string identificador { get; set; }

        [Description("deposito")]
        public string deposito { get; set; }

        [Description("obs")]
        public string obs { get; set; }

        [Description("preco_unitario")]
        public string preco_unitario { get; set; }

        [Description("hora_lancamento ")]
        public string hora_lancamento { get; set; }

        [Description("natureza_operacao")]
        public string natureza_operacao { get; set; }

        [Description("tabela_preco")]
        public string tabela_preco { get; set; }

        [Description("nome_tabela_preco")]
        public string nome_tabela_preco { get; set; }

        [Description("portal")]
        public string cod_sefaz_situacao { get; set; }

        [Description("desc_sefaz_situacao ")]
        public string desc_sefaz_situacao { get; set; }

        [Description("protocolo_aut_nfe")]
        public string protocolo_aut_nfe { get; set; }

        [Description("dt_update")]
        public string dt_update { get; set; }

        [Description("orma_cheque_prazo")]
        public string forma_cheque_prazo { get; set; }

        [Description("total_cheque_prazo")]
        public string total_cheque_prazo { get; set; }

        [Description("cod_natureza_operacao")]
        public string cod_natureza_operacao { get; set; }

        [Description("preco_tabela_epoca")]
        public string preco_tabela_epoca { get; set; }

        [Description("desconto_total_item")]
        public string desconto_total_item { get; set; }

        [Description("conferido")]
        public string conferido { get; set; }

        [Description("transacao_pedido_venda")]
        public string transacao_pedido_venda { get; set; }

        [Description("codigo_modelo_nf")]
        public string codigo_modelo_nf { get; set; }

        [Description("acrescimo")]
        public string acrescimo { get; set; }

        [Description("mob_checkout")]
        public string mob_checkout { get; set; }

        [Description("aliquota_iss")]
        public string aliquota_iss { get; set; }

        [Description("base_iss")]
        public string base_iss { get; set; }

        [Description("ordem")]
        public string ordem { get; set; }

        [Description("codigo_rotina_origem")]
        public string codigo_rotina_origem { get; set; }

        [Description("timestamp")]
        public string timestamp { get; set; }


    }
}
