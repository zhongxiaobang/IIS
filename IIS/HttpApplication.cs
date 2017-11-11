using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS
{
    public class HttpApplication : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.StateCode = "200";
            context.Response.StateDes = "OK";
            context.Response.ContentType = "text/html; charset=utf-8";
            context.Response.Body = Encoding.Default.GetBytes("你好");
        }
    }
}
