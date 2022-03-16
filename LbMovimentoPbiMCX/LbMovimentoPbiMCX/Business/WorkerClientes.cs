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
    public class WorkerClientes
    {
        public void ExecutarClientesFornecedores()
        {
            GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
            List<LinxGrupoLojasViewModelcs> portais = getparametrosLojas.GetIdPortalCnpj();
            List<LinxClientesViewModel> listaClientes = new List<LinxClientesViewModel>();
            LinxClientesData clientesFornecedoresData = new LinxClientesData();
            AtualizaTimestamp atualizaTimestamp = new AtualizaTimestamp();
            long ultimoTimestamp = 0;
            long novoTimestamp;

            try 
            {
                foreach (var portal in portais)
                {
                    var timestamp = getparametrosLojas.GetTimestamp("LinxClientesFornecedores", portal.PORTAL, portal.CNPJ);

                    if (timestamp == 0)
                    {
                        Utility.VerifcaTimeStamp("LinxClientesFornecedores", portal.PORTAL, portal.CNPJ);
                    }

                    var xml = Utility.RemoveByteOrderMark(Call.ClientesFornecedores(portal.PORTAL, portal.CNPJ, "2022-01-01", "2022-12-31", timestamp)); ;

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
                            LinxClientesViewModel linxClientesFornecedores = new LinxClientesViewModel();

                            foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                            {
                                PropertyInfo[] props = typeof(LinxClientesViewModel).GetProperties();
                                foreach (PropertyInfo propertyInfo in props)
                                {
                                    DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                                    if (keyValue.Key.ToUpper().Trim() == att.Description.ToUpper().Trim())
                                    {
                                        propertyInfo.SetValue(linxClientesFornecedores, keyValue.Value);
                                        break;
                                    }
                                }
                            }

                            listaClientes.Add(linxClientesFornecedores);

                        }

                        foreach (var cliente in listaClientes)
                        {
                            clientesFornecedoresData.InsertClientesFornecedores(cliente);
                        }

                        novoTimestamp = listaClientes.Max(s => Int64.Parse(s.timestamp));
                        listaClientes.Clear();
                        ultimoTimestamp = timestamp;

                        DateTime dataIntegracao = DateTime.Now;

                        atualizaTimestamp.AtualizaTimestam("LinxClientesFornecedores", portal.PORTAL, portal.CNPJ, novoTimestamp, ultimoTimestamp, dataIntegracao);

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
