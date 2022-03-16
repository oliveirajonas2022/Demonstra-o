using Calls;
using Integration_LB;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Models.Deseralize;

namespace Business
{
    public class WorkerProdutos
    {
        public void ExecutarProdutos()
        {
            try
            {
                List<LinxProdutoViewModel> listaProd = new List<LinxProdutoViewModel>();
                LinxProdutosData linxProdutosDetalhesData = new LinxProdutosData();
                AtualizaTimestamp atualizaTimestamp = new AtualizaTimestamp();
                GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
                long ultimoTimestamp = 0;
                long novoTimestamp;
               
                var timestamp = getparametrosLojas.GetTimestamp("Produto", "8152", "10967749000166");

                var xml = Utility.RemoveByteOrderMark(Call.Produtos("8152", "10967749000166", "2021-01-01", "2021-12-31", timestamp));

                Microvix mcxDate = DeserializeXml<Microvix>(xml);
                var data = mcxDate.ResponseData;

                if(data.R.Count()> 0)
                {
                    foreach (var item in data.R)
                    {
                        int qtdData = data.C.D.Count();

                        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                        for (int i = 0; i < qtdData; i++)
                        {
                            keyValuePairs.Add(mcxDate.ResponseData.C.D[i], item.D[i]);
                        }
                        LinxProdutoViewModel listaProduto = new LinxProdutoViewModel();

                        foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                        {
                            PropertyInfo[] props = typeof(LinxProdutoViewModel).GetProperties();
                            foreach (PropertyInfo propertyInfo in props)
                            {
                                DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                                if (keyValue.Key.ToUpper().Trim() == att.Description.ToUpper().Trim())
                                {
                                    propertyInfo.SetValue(listaProduto, keyValue.Value);
                                    break;
                                }
                            }
                        }

                        listaProd.Add(listaProduto);

                    }

                    foreach (var prod in listaProd)
                    {
                        linxProdutosDetalhesData.InsertProd(prod);
                    }

                    novoTimestamp = listaProd.Max(s => Int64.Parse(s.timestamp));
                    listaProd.Clear();
                    ultimoTimestamp = timestamp;

                    DateTime dataIntegracao = DateTime.Now;

                    atualizaTimestamp.AtualizaTimestam("Produto", "8152", "10967749000166", novoTimestamp, ultimoTimestamp, dataIntegracao);
                }




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


    }
}
