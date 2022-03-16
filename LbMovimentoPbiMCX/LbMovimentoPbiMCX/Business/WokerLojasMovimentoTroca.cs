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
    public class WokerLojasMovimentoTroca
    {
        public void ExecutarLojasMovimentoTroca()
        {
            GetParametrosLojas getparametrosLojas = new GetParametrosLojas();
            List<LinxGrupoLojasViewModelcs> portais = getparametrosLojas.GetIdPortalCnpj();
            List<LinxMovimentoTrocasViewModel> listaLojasTrocasMovimento = new List<LinxMovimentoTrocasViewModel>();
            LinxLojasMovimentoTrocasData lojaMovimentoTrocaData = new LinxLojasMovimentoTrocasData();

            foreach (var portal in portais)
            {
                var xml = Utility.RemoveByteOrderMark(Call.lojasMovimentoTrocas("8090", "10967749000166", "2020-01-10", "2020-03-30","0"));

                Microvix mcxDate = DeserializeXml<Microvix>(xml);
                var data = mcxDate.ResponseData;
                foreach (var item in data.R)
                {
                    int qtdData = data.C.D.Count();

                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                    for (int i = 0; i < qtdData; i++)
                    {
                        keyValuePairs.Add(mcxDate.ResponseData.C.D[i], item.D[i]);
                    }
                    LinxMovimentoTrocasViewModel linxLojasmoviementoTrocaViewModel = new LinxMovimentoTrocasViewModel();

                    foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
                    {
                        PropertyInfo[] props = typeof(LinxMovimentoTrocasViewModel).GetProperties();
                        foreach (PropertyInfo propertyInfo in props)
                        {
                            DescriptionAttribute att = (DescriptionAttribute)propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                            if (keyValue.Key.ToUpper().Trim() == att.Description.ToUpper().Trim())
                            {
                                propertyInfo.SetValue(linxLojasmoviementoTrocaViewModel, keyValue.Value);
                                break;
                            }
                        }
                    }

                    listaLojasTrocasMovimento.Add(linxLojasmoviementoTrocaViewModel);


                }

                lojaMovimentoTrocaData.InsertLojaMovimentoTrocas(listaLojasTrocasMovimento);
                listaLojasTrocasMovimento.Clear();

            }



        }

    }
}
