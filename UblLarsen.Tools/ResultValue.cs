using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UblLarsen.Tools
{
    public class ResultValue
    {
        public string Operation { get; set; }

        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; }

        public string ResultedValue { get; set; }

        public List<ResultValue> lstSteps { get; set; }

        public string SingedXML { get; set; }
    }
}
