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
    public class WorkerLojas
    {
        public void ExecutarLojas()
        {
            try
            {
                GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
                List<LinxGrupoLojasViewModelcs> portais = getparametrosLojas.GetIdPortalCnpj();
                List<LinxLojasViewModel> listaLojas = new List<LinxLojasViewModel>();
                LinxLojasData lojaData = new LinxLojasData();
                AtualizaTimestamp atualizaTimestamp = new AtualizaTimestamp();
                long ultimoTimestamp = 0;
                long novoTimestamp;


                foreach (var portal in portais)
                {
                    var timestamp = getparametrosLojas.GetTimestamp("LinxLojas", portal.PORTAL, portal.CNPJ);

                    if (timestamp == 0)
                    {
                        Utility.VerifcaTimeStamp("LinxLojas", portal.PORTAL, portal.CNPJ);
                    }

                    var xml = Utility.RemoveByteOrderMark(Call.Lojas(portal.PORTAL, portal.CNPJ, timestamp));

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
                            LinxLojasViewModel linxLojasViewModel = new LinxLojasViewModel();

                            foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                            {
                                PropertyInfo[] props = typeof(LinxLojasViewModel).GetProperties();
                                foreach (PropertyInfo propertyInfo in props)
                                {
                                    DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                                    if (keyValue.Key.ToUpper() == att.Description.ToUpper())
                                    {
                                        propertyInfo.SetValue(linxLojasViewModel, keyValue.Value);
                                        break;
                                    }
                                }
                            }

                            listaLojas.Add(linxLojasViewModel);

                        }

                        foreach (var lojas in listaLojas)
                        {
                            lojaData.InsertLojas(lojas);

                        }
                        novoTimestamp = listaLojas.Max(s => Int64.Parse(s.timestamp));
                        listaLojas.Clear();

                        ultimoTimestamp = timestamp;

                        DateTime dataIntegracao = DateTime.Now;

                        atualizaTimestamp.AtualizaTimestam("LinxLojas", portal.PORTAL, portal.CNPJ, novoTimestamp, ultimoTimestamp, dataIntegracao);
                                                               
                    }

                    
                }

            }
            catch(Exception ex)
            {
                string msg = ex.Message;

            }
         




        }




    }
}
