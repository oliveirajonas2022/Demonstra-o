using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrIntegracaoMcx.Models
{
    public class LogIntegracaoViewModel
    {
     
        public String INTEGRACAO { get; set; }
        public DateTime DATA_LOG { get; set; }
        public String MSG_LOG { get; set; }

        public String STATUS { get; set; }

        public DateTime DATA_INI_INT { get; set; }

        public DateTime DATA_FIM_INT { get; set; }


    }
}
