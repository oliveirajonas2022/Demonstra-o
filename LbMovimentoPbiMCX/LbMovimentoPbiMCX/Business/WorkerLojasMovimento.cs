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
    public class WorkerLojasMovimento
    {
      
        public void ExecutarLojasMovimento()
        {
            try
            {
                GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
                List<LinxGrupoLojasViewModelcs> portais = getparametrosLojas.GetIdPortalCnpj();
                List<LinxMovimentoViewModel> listaLojasMovimento = new List<LinxMovimentoViewModel>();
                LinxLojasMovimentoData lojaMovimentoData = new LinxLojasMovimentoData();
                AtualizaTimestamp atualizaTimestamp = new AtualizaTimestamp();
                long ultimoTimestamp = 0;
                long novoTimestamp;

                foreach (var portal in portais)
                {
                var timestamp = getparametrosLojas.GetTimestamp("LinxMovimento", portal.PORTAL, portal.CNPJ);

                    if(timestamp == 0)
                    {
                        Utility.VerifcaTimeStamp("LinxMovimento", portal.PORTAL, portal.CNPJ);
                    }

                var xml = Utility.RemoveByteOrderMark(Call.lojasMovimento(portal.PORTAL,portal.CNPJ, timestamp, "2022-01-01", "2022-12-31"));

                //var xml = Utility.RemoveByteOrderMark(Call.lojasMovimento("11598", "34062678000110", 0, "2021-06-01", "2021-06-30"));

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
                        LinxMovimentoViewModel linxLojasmoviementoViewModel = new LinxMovimentoViewModel();

                        foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                        {
                            PropertyInfo[] props = typeof(LinxMovimentoViewModel).GetProperties();
                            foreach (PropertyInfo propertyInfo in props)
                            {
                                DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                                if (keyValue.Key.ToUpper().Trim() == att.Description.ToUpper().Trim())
                                {
                                    propertyInfo.SetValue(linxLojasmoviementoViewModel, keyValue.Value);
                                    break;
                                }
                            }
                        }

                        LinxMovimentoViewModel lojaMovimentoAnterior = listaLojasMovimento.Find(c => c.portal == linxLojasmoviementoViewModel.portal
                            && c.cnpj_emp == linxLojasmoviementoViewModel.cnpj_emp
                            && c.documento == linxLojasmoviementoViewModel.documento
                            && c.serie == linxLojasmoviementoViewModel.serie
                            && c.codigo_modelo_nf == linxLojasmoviementoViewModel.codigo_modelo_nf
                            && c.cod_produto == linxLojasmoviementoViewModel.cod_produto
                            && c.cod_barra == linxLojasmoviementoViewModel.cod_barra
                            && c.ordem == linxLojasmoviementoViewModel.ordem
                            && c.operacao == "S"
                            );

                        if (listaLojasMovimento.Count > 0)
                        {
                            if (lojaMovimentoAnterior != null)
                            {
                                if (Int64.Parse(linxLojasmoviementoViewModel.timestamp) > Int64.Parse(lojaMovimentoAnterior.timestamp))
                                {
                                    listaLojasMovimento.Remove(lojaMovimentoAnterior);
                                    listaLojasMovimento.Add(linxLojasmoviementoViewModel);
                                }
                            }
                            else
                            {
                                listaLojasMovimento.Add(linxLojasmoviementoViewModel);
                            }
                        }
                        else
                        {
                            listaLojasMovimento.Add(linxLojasmoviementoViewModel);
                        }

                    }

                    //var lojaMovimentoAnteriord = listaLojasMovimento.Where(c => c.cod_vendedor.Trim() == "7" && c.operacao.Trim() == "DS" && c.cod_produto == "122694").ToList();



                    foreach (var item in listaLojasMovimento)
                    {
                        if (item.operacao == "DS")
                        {
                            lojaMovimentoData.InsertLojaMovimentoDevoulucao(item);
                        }
                        else
                        {
                            lojaMovimentoData.InsertLojaMovimento(item);
                        }
                    


                    }

                    novoTimestamp = listaLojasMovimento.Max(s => Int64.Parse(s.timestamp));
                    listaLojasMovimento.Clear();
                    ultimoTimestamp = timestamp;

                    DateTime dataIntegracao = DateTime.Now;

                    atualizaTimestamp.AtualizaTimestam("LinxMovimento", portal.PORTAL, portal.CNPJ, novoTimestamp, ultimoTimestamp, dataIntegracao);

                    //atualizaTimestamp.AtualizaTimestam("LinxMovimento", "11598", "34062678000110", novoTimestamp, ultimoTimestamp, dataIntegracao);
                }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }

        public void ExecutarLojasMovimentoParametro(string CargaPortal, string cargaCnpj, string dataIni, string dataFim, bool legado, bool cargaFull, bool cargaParcail )
        {
            try
            {
                GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
                List<LinxGrupoLojasViewModelcs> portais = getparametrosLojas.GetIdPortalCnpj(legado,cargaFull,cargaParcail);
                List<LinxMovimentoViewModel> listaLojasMovimento = new List<LinxMovimentoViewModel>();
                LinxLojasMovimentoData lojaMovimentoData = new LinxLojasMovimentoData();
                AtualizaTimestamp atualizaTimestamp = new AtualizaTimestamp();
                long ultimoTimestamp = 0;
                long novoTimestamp;
                string xml = "";

                foreach (var portal in portais)
                {
                    //var timestamp = getparametrosLojas.GetTimestamp("LinxMovimento", portal.PORTAL, portal.CNPJ);

                    //if (timestamp == 0)
                    //{
                    //    Utility.VerifcaTimeStamp("LinxMovimento", portal.PORTAL, portal.CNPJ);
                    //}

                    if (legado && cargaFull )
                    {
                        xml = Utility.RemoveByteOrderMark(Call.lojasMovimento(portal.PORTAL, portal.CNPJ, 0, "1900-01-01", "2021-12-31"));
                    }
                    else if (legado && cargaParcail)
                    {
                        xml = Utility.RemoveByteOrderMark(Call.lojasMovimento(portal.PORTAL, portal.CNPJ, 0, "1900-01-01", "2021-12-31"));
                    }


                    //var xml = Utility.RemoveByteOrderMark(Call.lojasMovimento("11598", "34062678000110", 0, "2021-06-01", "2021-06-30"));

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
                            LinxMovimentoViewModel linxLojasmoviementoViewModel = new LinxMovimentoViewModel();

                            foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                            {
                                PropertyInfo[] props = typeof(LinxMovimentoViewModel).GetProperties();
                                foreach (PropertyInfo propertyInfo in props)
                                {
                                    DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                                    if (keyValue.Key.ToUpper().Trim() == att.Description.ToUpper().Trim())
                                    {
                                        propertyInfo.SetValue(linxLojasmoviementoViewModel, keyValue.Value);
                                        break;
                                    }
                                }
                            }

                            LinxMovimentoViewModel lojaMovimentoAnterior = listaLojasMovimento.Find(c => c.portal == linxLojasmoviementoViewModel.portal
                                && c.cnpj_emp == linxLojasmoviementoViewModel.cnpj_emp
                                && c.documento == linxLojasmoviementoViewModel.documento
                                && c.serie == linxLojasmoviementoViewModel.serie
                                && c.codigo_modelo_nf == linxLojasmoviementoViewModel.codigo_modelo_nf
                                && c.cod_produto == linxLojasmoviementoViewModel.cod_produto
                                && c.cod_barra == linxLojasmoviementoViewModel.cod_barra
                                && c.ordem == linxLojasmoviementoViewModel.ordem
                                && c.operacao == "S"
                                );

                            if (listaLojasMovimento.Count > 0)
                            {
                                if (lojaMovimentoAnterior != null)
                                {
                                    if (Int64.Parse(linxLojasmoviementoViewModel.timestamp) > Int64.Parse(lojaMovimentoAnterior.timestamp))
                                    {
                                        listaLojasMovimento.Remove(lojaMovimentoAnterior);
                                        listaLojasMovimento.Add(linxLojasmoviementoViewModel);
                                    }
                                }
                                else
                                {
                                    listaLojasMovimento.Add(linxLojasmoviementoViewModel);
                                }
                            }
                            else
                            {
                                listaLojasMovimento.Add(linxLojasmoviementoViewModel);
                            }

                        }

                        //var lojaMovimentoAnteriord = listaLojasMovimento.Where(c => c.cod_vendedor.Trim() == "7" && c.operacao.Trim() == "DS" && c.cod_produto == "122694").ToList();



                        foreach (var item in listaLojasMovimento)
                        {
                            if (item.operacao == "DS")
                            {
                                lojaMovimentoData.InsertLojaMovimentoDevoulucao(item);
                            }
                            else
                            {
                                lojaMovimentoData.InsertLojaMovimento(item);
                            }



                        }

                        novoTimestamp = listaLojasMovimento.Max(s => Int64.Parse(s.timestamp));
                        listaLojasMovimento.Clear();
                        ultimoTimestamp = 0;

                        DateTime dataIntegracao = DateTime.Now;

                        atualizaTimestamp.AtualizaTimestam("LinxMovimento", portal.PORTAL, portal.CNPJ, novoTimestamp, ultimoTimestamp, dataIntegracao);

                        //atualizaTimestamp.AtualizaTimestam("LinxMovimento", "11598", "34062678000110", novoTimestamp, ultimoTimestamp, dataIntegracao);
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }
    }
}
