
using Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Calls
{
   public static class Call
   {
       public  static GetParametrosLojas getParametrosLojas = new GetParametrosLojas();

        public static string LojaGrupos(string idPortal)
        {
            idPortal = "8152";
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao/LinxLojas");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix>" +
                "<Authentication user = \"linx_export\" " +
                "password=\"linx_export\"/>" +
                "<ResponseFormat>xml</ResponseFormat>" +
                "<IdPortal>" + idPortal + "</IdPortal>" +
                "<Command> <Name>LinxGrupoLojas</Name>" +
                "<Parameters>" +
                "<Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                "<Parameter id =\"grupo\">Luiza Barcelos - Franqueadora - WS de Saida Padrao</Parameter>" +
                "</Parameters> </Command> </LinxMicrovix>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;

        }

        public static string Lojas(string idPortal, string cnpj ,long timeStamp)
        {
                
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao/LinxLojas");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix><Authentication user = \"linx_export\" password=\"linx_export\"/>" +
                "<ResponseFormat>xml</ResponseFormat>" +
                "<IdPortal>"+idPortal+"</IdPortal>" +
                "<Command>" +
                "<Name>LinxLojas</Name> " +
                " <Parameters>" +
                " <Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                " <Parameter id =\"cnpjEmp\">"+cnpj+"</Parameter>" +
                " <Parameter id=\"timestamp\">"+timeStamp+"</Parameter> " +
                " </Parameters>  " +
                "  </Command> " +
                "</LinxMicrovix>", ParameterType.RequestBody);
                 IRestResponse response = client.Execute(request);
            

            return response.Content;
        }

        public static string lojasMovimento(string idPortal, string cnpj, long timestamp, string dataIni , string dataFim )
        {
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix>" +
                " <Authentication user = \"linx_export\" password=\"linx_export\"/> " +
                " <ResponseFormat>xml</ResponseFormat>" +
                " <IdPortal>" + idPortal + "</IdPortal>" +
                " <Command> " +
                "<Name>LinxMovimento</Name>" +
                "<Parameters><Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                "<Parameter id =\"cnpjEmp\">" + cnpj + "</Parameter>" +
                "<Parameter id =\"data_inicial\">" + dataIni + "</Parameter>" +
                "<Parameter id =\"data_fim\">"+ dataFim +"</Parameter>" +
                "<Parameter id =\"timestamp\">" + timestamp + "</Parameter>" +
                "</Parameters> " +
                "</Command>" +
                "</LinxMicrovix>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }


        //public static string lojasMovimento(string idPortal, string cnpj, long timestamp)
        //{
        //    var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao");
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Content-Type", "application/xml");
        //    request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
        //        "<LinxMicrovix>" +
        //        " <Authentication user = \"linx_export\" password=\"linx_export\"/> " +
        //        " <ResponseFormat>xml</ResponseFormat>" +
        //        " <IdPortal>" + idPortal + "</IdPortal>" +
        //        " <Command> " +
        //        "<Name>LinxMovimento</Name>" +
        //        "<Parameters><Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
        //        "<Parameter id =\"cnpjEmp\">" + cnpj + "</Parameter>" +
        //        "<Parameter id =\"data_inicial\">2021-03-01</Parameter>" +
        //        "<Parameter id =\"data_fim\">2021-03-05</Parameter>" +
        //       "<Parameter id =\"timestamp\">" + timestamp + "</Parameter>" +
        //        "</Parameters> " +
        //        "</Command>" +
        //        "</LinxMicrovix>", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);

        //    return response.Content;
        //}


        public static string lojasMovimentoCartoes(string idPortal, string cnpj, string dataInicial, string dataFinal, string timeStamp)
        {
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix>" +
                " <Authentication user = \"linx_export\" password=\"linx_export\"/> " +
                " <ResponseFormat>xml</ResponseFormat>" +
                " <IdPortal>" + idPortal + "</IdPortal>" +
                " <Command> " +
                "<Name>LinxMovimentoCartoes</Name>" +
                "<Parameters><Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                "<Parameter id =\"cnpjEmp\">" + cnpj + "</Parameter>" +
                "<Parameter id =\"data_inicial\">" + dataInicial + "</Parameter>" +
                "<Parameter id =\"data_fim\">" + dataFinal + "</Parameter>" +
                "<Parameter id =\"timestamp\">" + timeStamp+ "</Parameter>" +
                "</Parameters> " +
                "</Command>" +
                "</LinxMicrovix>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content; 
        }


        public static string lojasMovimentoTrocas(string idPortal, string cnpj, string dataInicial, string dataFinal,string timeStamp)
        {
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix>" +
                " <Authentication user = \"linx_export\" password=\"linx_export\"/> " +
                " <ResponseFormat>xml</ResponseFormat>" +
                " <IdPortal>" + idPortal + "</IdPortal>" +
                " <Command> " +
                "<Name>LinxMovimentoCartoes</Name>" +
                "<Parameters><Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                "<Parameter id =\"cnpjEmp\">" +cnpj+ "</Parameter>" +
                "<Parameter id =\"data_inicial\">" +dataInicial+ "</Parameter>" +
                "<Parameter id =\"data_fim\">" +dataFinal+ "</Parameter>" +
                "<Parameter id =\"timestamp\">" +timeStamp+ "</Parameter>" +
                "</Parameters> " +
                "</Command>" +
                "</LinxMicrovix>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }


        public static string ClientesFornecedores(string idPortal, string cnpj, string dataInicial, string dataFinal, long timestamp)
        {
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix>" +
                " <Authentication user = \"linx_export\" password=\"linx_export\"/> " +
                " <ResponseFormat>xml</ResponseFormat>" +
                " <IdPortal>" + idPortal + "</IdPortal>" +
                " <Command> " +
                "<Name>LinxClientesFornec</Name>" +
                "<Parameters><Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                "<Parameter id =\"cnpjEmp\">" + cnpj + "</Parameter>" +
                "<Parameter id =\"data_inicial\">" + dataInicial + "</Parameter>" +
                "<Parameter id =\"data_fim\">" + dataFinal + "</Parameter>" +
                "<Parameter id =\"timestamp\">" + timestamp + "</Parameter>" +
                "</Parameters> " +
                "</Command>" +
                "</LinxMicrovix>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static string ProdutosDetalhes(string idPortal, string cnpj, string dataInicial, string dataFinal, long timestamp)
        {
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix>" +
                " <Authentication user = \"linx_export\" password=\"linx_export\"/> " +
                " <ResponseFormat>xml</ResponseFormat>" +
                " <IdPortal>" + idPortal + "</IdPortal>" +
                " <Command> " +
                "<Name>LinxProdutosDetalhes</Name>" +
                "<Parameters><Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                "<Parameter id =\"cnpjEmp\">" + cnpj + "</Parameter>" +
                "<Parameter id =\"data_mov_ini\">" + dataInicial + "</Parameter>" +
                "<Parameter id =\"data_mov_fim\">" + dataFinal + "</Parameter>" +
                "<Parameter id =\"timestamp\">" + timestamp + "</Parameter>" +
                "</Parameters> " +
                "</Command>" +
                "</LinxMicrovix>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static string Produtos(string idPortal, string cnpj, string dataInicial, string dataFinal, long timestamp)
        {
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix>" +
                " <Authentication user = \"linx_export\" password=\"linx_export\"/> " +
                " <ResponseFormat>xml</ResponseFormat>" +
                " <IdPortal>" + idPortal + "</IdPortal>" +
                " <Command> " +
                "<Name>LinxProdutos</Name>" +
                "<Parameters><Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                "<Parameter id =\"cnpjEmp\">" + cnpj + "</Parameter>" +
                "<Parameter id =\"Dt_update_inicio\">" + dataInicial + "</Parameter>" +
                "<Parameter id =\"Dt_update_fim\">" + dataFinal + "</Parameter>" +
                "<Parameter id =\"timestamp\">" + timestamp + "</Parameter>" +
                "</Parameters> " +
                "</Command>" +
                "</LinxMicrovix>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public static string Vendedores(string idPortal, string cnpj, long timestamp)
        {
            var client = new RestClient("https://webapi.microvix.com.br/1.0/api/integracao");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("application/xml", "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<LinxMicrovix>" +
                " <Authentication user = \"linx_export\" password=\"linx_export\"/> " +
                " <ResponseFormat>xml</ResponseFormat>" +
                " <IdPortal>" + idPortal + "</IdPortal>" +
                " <Command> " +
                "<Name>LinxVendedores</Name>" +
                "<Parameters><Parameter id =\"chave\">62df25ae-5067-4ae3-8039-ea28326449ec</Parameter>" +
                "<Parameter id =\"cnpjEmp\">" + cnpj + "</Parameter>" +
                "<Parameter id =\"timestamp\">" + timestamp + "</Parameter>" +
                "</Parameters> " +
                "</Command>" +
                "</LinxMicrovix>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

    }
}
