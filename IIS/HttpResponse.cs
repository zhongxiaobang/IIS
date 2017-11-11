using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS
{
    public class HttpResponse
    {
        public string StateCode { get; set; }
        public string StateDes { get; set; }
        public string ContentType { get; set; }
        public byte[] Body { get; set; }
        public byte[] GetResponseHeader()
        {
            string stringRequestHeader = string.Format(@"HTTP/1.1 {0} {1}
                    Date: Sat, 31 Dec 2005 23:59:59 GMT
                    Content-Type:{2}
                    Content-Length:{3}

", StateCode,StateDes,ContentType,Body.Length);
            return Encoding.Default.GetBytes(stringRequestHeader);
        }
    }
}
