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
    public class WorkerProdutosDetalhes
    {
        public void ExecutarProdutosDetalhes()
        {
            try
            {
                GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
                List<LinxGrupoLojasViewModelcs> portais = getparametrosLojas.GetIdPortalCnpj();
                List<ProdutosDetalhesViewModel> listaProdutos = new List<ProdutosDetalhesViewModel>();
                LinxProdutosDetalhesData linxProdutosDetalhesData = new LinxProdutosDetalhesData();
                AtualizaTimestamp atualizaTimestamp = new AtualizaTimestamp();
                long ultimoTimestamp = 0;
                long novoTimestamp;

                foreach (var portal in portais)
                {
                    var timestamp = getparametrosLojas.GetTimestamp("Estoque_custo", portal.PORTAL, portal.CNPJ);
                    //var xml = Utility.RemoveByteOrderMark(Call.ProdutosDetalhes(portal.PORTAL, portal.CNPJ, "1900-01-01", "2050-12-31", timestamp));
                    var xml = Utility.RemoveByteOrderMark(Call.ProdutosDetalhes(portal.PORTAL, portal.CNPJ, "1900-01-01", "2021-12-31", 0));
                    //var xml = Utility.RemoveByteOrderMark(Call.ProdutosDetalhes("8152", "10967749000166", "1900-01-01", "2050-12-31", 0));


                    Microvix mcxDate = DeserializeXml<Microvix>(xml);

                    var data = mcxDate.ResponseData;

                    if (data.R.Count() > 0)
                    {
                        foreach (var item in data.R)
                        {
                            int qtdData = data.C.D.Count();

                            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                            for (int i = 0; i < qtdData; i++)
                            {
                                keyValuePairs.Add(mcxDate.ResponseData.C.D[i], item.D[i]);
                            }
                            ProdutosDetalhesViewModel listaProdutosDetalhes = new ProdutosDetalhesViewModel();

                            foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                            {
                                PropertyInfo[] props = typeof(ProdutosDetalhesViewModel).GetProperties();
                                foreach (PropertyInfo propertyInfo in props)
                                {
                                    DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                                    if (keyValue.Key.ToUpper().Trim() == att.Description.ToUpper().Trim())
                                    {
                                        propertyInfo.SetValue(listaProdutosDetalhes, keyValue.Value);
                                        break;
                                    }
                                }
                            }

                            listaProdutos.Add(listaProdutosDetalhes);
                        }

                        foreach (var estoque in listaProdutos)
                        {
                            //if(!estoque.quantidade.Contains("-"))

                            //{

                            linxProdutosDetalhesData.zeraEstoque(estoque);

                            linxProdutosDetalhesData.InsertProdutosDetalhes(estoque);
                            //}

                        }

                        novoTimestamp = listaProdutos.Max(s => Int64.Parse(s.timestamp));
                        listaProdutos.Clear();

                        ultimoTimestamp = timestamp;

                        DateTime dataIntegracao = DateTime.Now;

                        atualizaTimestamp.AtualizaTimestam("Estoque_custo", portal.PORTAL, portal.CNPJ, novoTimestamp, ultimoTimestamp, dataIntegracao);
                        // atualizaTimestamp.AtualizaTimestam("Estoque_custo", "8152", "10967749000166", novoTimestamp, 0, dataIntegracao);


                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }

    //public class WorkerProdutosDetalhes
    //{
    //    public void ExecutarProdutosDetalhes()
    //    {
    //        try
    //        {
    //            GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
    //            //List<LinxGrupoLojasViewModelcs> portais = getparametrosLojas.GetIdPortalCnpj();
    //            List<ProdutosDetalhesViewModel> listaProdutos = new List<ProdutosDetalhesViewModel>();
    //            LinxProdutosDetalhesData linxProdutosDetalhesData = new LinxProdutosDetalhesData();
    //            AtualizaTimestamp atualizaTimestamp = new AtualizaTimestamp();
    //            long ultimoTimestamp = 0;
    //            long novoTimestamp;





    //                //var timestamp = getparametrosLojas.GetTimestamp("Estoque_custo", portal.PORTAL, portal.CNPJ);
    //                //var xml = Utility.RemoveByteOrderMark(Call.ProdutosDetalhes(portal.PORTAL, portal.CNPJ, "1900-01-01", "2050-12-31", timestamp));
    //                var xml = Utility.RemoveByteOrderMark(Call.ProdutosDetalhes("11598", "34062678000110", "1900-03-01", "2021-12-30", 0));
    //                //var xml = Utility.RemoveByteOrderMark(Call.ProdutosDetalhes("8152", "10967749000166", "1900-01-01", "2050-12-31", 0));



    //                Microvix mcxDate = DeserializeXml<Microvix>(xml);

    //                var data = mcxDate.ResponseData;

    //                if (data.R.Count() > 0)
    //                {
    //                    foreach (var item in data.R)
    //                    {
    //                        int qtdData = data.C.D.Count();

    //                        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

    //                        for (int i = 0; i < qtdData; i++)
    //                        {
    //                            keyValuePairs.Add(mcxDate.ResponseData.C.D[i], item.D[i]);
    //                        }
    //                        ProdutosDetalhesViewModel listaProdutosDetalhes = new ProdutosDetalhesViewModel();

    //                        foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
    //                        {
    //                            PropertyInfo[] props = typeof(ProdutosDetalhesViewModel).GetProperties();
    //                            foreach (PropertyInfo propertyInfo in props)
    //                            {
    //                                DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
    //                                if (keyValue.Key.ToUpper().Trim() == att.Description.ToUpper().Trim())
    //                                {
    //                                    propertyInfo.SetValue(listaProdutosDetalhes, keyValue.Value);
    //                                    break;
    //                                }
    //                            }
    //                        }



    //                        listaProdutos.Add(listaProdutosDetalhes);




    //                    }

    //                    foreach (var estoque in listaProdutos)
    //                    {
    //                        //if(!estoque.quantidade.Contains("-"))
    //                        //{
    //                        linxProdutosDetalhesData.InsertProdutosDetalhes(estoque);
    //                        //}



    //                    }

    //                    novoTimestamp = listaProdutos.Max(s => Int64.Parse(s.timestamp));
    //                    listaProdutos.Clear();

    //                   // ultimoTimestamp = timestamp;

    //                    DateTime dataIntegracao = DateTime.Now;

    //                    atualizaTimestamp.AtualizaTimestam("Estoque_custo", "11598", "34062678000110", novoTimestamp, ultimoTimestamp, dataIntegracao);
    //                    // atualizaTimestamp.AtualizaTimestam("Estoque_custo", "8152", "10967749000166", novoTimestamp, 0, dataIntegracao);




    //                }




    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }




    //    }
    //}
}
