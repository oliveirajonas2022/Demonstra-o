using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Timestamp
    {
        [Description("id_tabela")]
        public int id_tabela { get; set; }


        [Description("desc_tabela")]
        public string desc_tabela { get; set; }

        [Description("data_integracao")]
        public DateTime data_integracao { get; set; }

        [Description("time_stamp_maior")]
        public long  time_stamp_maior { get; set; }

        [Description("time_stamp_menor")]
        public long  time_stamp_menor { get; set; }

        [Description("portal")]
        public int portal  { get; set; }


        [Description("cnpj")]
        public string cnpj { get; set; }


    }
}
