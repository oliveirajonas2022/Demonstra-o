using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Calls;
using static Models.Deseralize;
using Integration_LB;
using System.ComponentModel;
using System.Reflection;
using Repository;

namespace Business
{
    public class WorkerLojaGrupos
    {
        LinxGrupoLojasData linxGrupoLojasData = new LinxGrupoLojasData();



        public void ExecutaLojaGrupo()
        {
            try
            {
                var xml = Utility.RemoveByteOrderMark(Call.LojaGrupos("8152"));

                Microvix mcxDate = DeserializeXml<Microvix>(xml);

                List<LinxGrupoLojasViewModelcs> listaLojasGrupos = new List<LinxGrupoLojasViewModelcs>();

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
                        LinxGrupoLojasViewModelcs linxGrupoLojasViewModelcs = new LinxGrupoLojasViewModelcs();

                        foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                        {
                            PropertyInfo[] props = typeof(LinxGrupoLojasViewModelcs).GetProperties();
                            foreach (PropertyInfo propertyInfo in props)
                            {
                                DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                                if (keyValue.Key.ToUpper() == att.Description.ToUpper())
                                {
                                    propertyInfo.SetValue(linxGrupoLojasViewModelcs, keyValue.Value);
                                    break;
                                }
                            }
                        }
                        listaLojasGrupos.Add(linxGrupoLojasViewModelcs);
                    }

                    foreach (var grupo in listaLojasGrupos)
                    {
                        if (!string.IsNullOrWhiteSpace(grupo.CNPJ))
                        {
                            linxGrupoLojasData.InsertGrupoLojas(grupo);

                            Utility.AjusteIntegracaoGrupo(grupo);
                        }
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
