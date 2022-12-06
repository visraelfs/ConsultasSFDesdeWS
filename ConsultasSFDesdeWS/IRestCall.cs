using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasSFDesdeWS
{
    interface IRestCall
    {
        string POST(string url, object jsonBody);
        string GET(string url);
    }
}
