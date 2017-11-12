using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS
{
    public class HttpApplication : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string url = context.Request.Url;
                int index = url.IndexOf("?");
                if (index > 0)
                {
                    url = url.Substring(0, index);
                }
                else
                {
                    url = url.Remove(0, 1);
                }

                //默认index
                if (url == "")
                {
                    url += "index.html";
                }

                string path = AppDomain.CurrentDomain.BaseDirectory + url;

                if (!File.Exists(path))
                {
                    context.Response.StateCode = "404";
                    context.Response.StateDes = "not found";
                    context.Response.ContentType = "text/html;charset=utf-8";
                    context.Response.Write(Encoding.UTF8.GetBytes("找不到资源"));
                }
                else
                {
                    context.Response.StateCode = "200";
                    context.Response.StateDes = "OK";
                    context.Response.ContentType = HttpUtils.GetContentType(path);
                    context.Response.Write(File.ReadAllBytes(path));
                }

                Form1.GetInstance().Msg("请求地址：" + context.Request.Url);
            }
            catch (Exception ex)
            {
                context.Response.StateCode = "500";
                context.Response.StateDes = "Internal Server Error";
                context.Response.ContentType = "text/html;charset=utf-8";
                context.Response.Write(Encoding.UTF8.GetBytes(ex.Message));

                Form1.GetInstance().Msg(ex.Message);
            }
            
        }
    }
}
