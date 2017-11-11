using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS
{
    public class HttpRequest
    {
        public HttpRequest(string requestStr)
        {
            string[] lines = requestStr.Replace("\r\n", "\r").Split('\r');
            HttpMethod = lines[0].Split(' ')[0];
            Url = lines[0].Split(' ')[1];
            HttpVersion = lines[0].Split(' ')[2];
        }

        public string HttpMethod { get; set; }
        public string Url { get; set; }
        public string HttpVersion { get; set; }
        public Dictionary<string,string> Header { get; set; }
        public Dictionary<string,string> Body { get; set; }
    }
}
