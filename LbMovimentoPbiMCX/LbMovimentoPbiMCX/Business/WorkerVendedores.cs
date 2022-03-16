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
    public class WorkerVendedores
    {
        public void ExecutarVendedores()
        {
            try
            {
                GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
                List<LinxGrupoLojasViewModelcs> portais = getparametrosLojas.GetIdPortalCnpj();
                List<LinxVendedoresViewModel> listaVendedores = new List<LinxVendedoresViewModel>();
                LinxVendedoresData linxVendedoresData = new LinxVendedoresData();
                AtualizaTimestamp atualizaTimestamp = new AtualizaTimestamp();
                long ultimoTimestamp = 0;
                long novoTimestamp;
                           


                foreach (var portal in portais)
                {
                    var timestamp = getparametrosLojas.GetTimestamp("Vendedores", portal.PORTAL, portal.CNPJ);

                    if (timestamp == 0)
                    {
                        Utility.VerifcaTimeStamp("Vendedores", portal.PORTAL, portal.CNPJ);
                    }


                    var xml = Utility.RemoveByteOrderMark(Call.Vendedores(portal.PORTAL, portal.CNPJ, timestamp));

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
                            LinxVendedoresViewModel linxVendedores = new LinxVendedoresViewModel();

                            foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                            {
                                PropertyInfo[] props = typeof(LinxVendedoresViewModel).GetProperties();
                                foreach (PropertyInfo propertyInfo in props)
                                {
                                    DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                                    if (keyValue.Key.ToUpper().Trim() == att.Description.ToUpper().Trim())
                                    {
                                        propertyInfo.SetValue(linxVendedores, keyValue.Value);
                                        break;
                                    }
                                }
                            }

                            listaVendedores.Add(linxVendedores);


                        }

                        foreach (var vendedores  in listaVendedores)
                        {
                            linxVendedoresData.InsertVendedores(vendedores);
                        }
                        novoTimestamp = listaVendedores.Max(s => Int64.Parse(s.timestamp));
                        listaVendedores.Clear();
                        ultimoTimestamp = timestamp;

                        DateTime dataIntegracao = DateTime.Now;

                        atualizaTimestamp.AtualizaTimestam("Vendedores", portal.PORTAL, portal.CNPJ, novoTimestamp, ultimoTimestamp, dataIntegracao);
                                                       
                 
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
