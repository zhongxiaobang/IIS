using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS
{
    public class HttpContext
    {
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }

        public HttpContext(string requestText)
        {
            Request = new HttpRequest(requestText);
            Response = new HttpResponse();
        }
    }
}
