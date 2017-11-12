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
            
            if (lines.Length > 0)
            {
                if (!string.IsNullOrEmpty(lines[0]))
                {
                    string[] data = lines[0].Split(' ');
                    HttpMethod = data[0];
                    Url = data[1];
                    HttpVersion = data[2];
                }
            }
            if (lines.Length > 1)
            {
                if (!string.IsNullOrEmpty(lines[1]))
                {
                    int index = lines[1].IndexOf(":");
                    Header[lines[1].Substring(0, index)] = lines[1].Substring(index + 1);
                }
                
            }
            if (lines.Length > 2)
            {
                if (!string.IsNullOrEmpty(lines[2]))
                {
                    int index = lines[2].IndexOf(":");
                    Header[lines[2].Substring(0, index)] = lines[2].Substring(index + 1);
                }
            }
            if (lines.Length > 3)
            {
                if (!string.IsNullOrEmpty(lines[3]))
                {
                    int index = lines[3].IndexOf(":");
                    Header[lines[3].Substring(0, index)] = lines[3].Substring(index + 1);
                }
            }
            if (lines.Length > 4)
            {
                if (!string.IsNullOrEmpty(lines[4]))
                {
                    int index = lines[4].IndexOf(":");
                    Header[lines[4].Substring(0, index)] = lines[4].Substring(index + 1);
                }
            }
            if (lines.Length > 5)
            {
                if (!string.IsNullOrEmpty(lines[5]))
                {
                    int index = lines[5].IndexOf(":");
                    Header[lines[5].Substring(0, index)] = lines[5].Substring(index + 1);
                }
            }
            if (lines.Length > 6)
            {
                if (!string.IsNullOrEmpty(lines[6]))
                {
                    int index = lines[6].IndexOf(":");
                    Header[lines[6].Substring(0, index)] = lines[6].Substring(index + 1);
                }
            }
            if (lines.Length > 7)
            {
                if (!string.IsNullOrEmpty(lines[7]))
                {
                    int index = lines[7].IndexOf(":");
                    Header[lines[7].Substring(0, index)] = lines[7].Substring(index + 1);
                }
            }
            if (lines.Length > 8)
            {
                if (!string.IsNullOrEmpty(lines[8]))
                {
                    int index = lines[8].IndexOf(":");
                    Header[lines[8].Substring(0, index)] = lines[8].Substring(index + 1);
                }
            }
            if (lines.Length > 9)
            {
                if (!string.IsNullOrEmpty(lines[9]))
                {
                    int index = lines[9].IndexOf(":");
                    Header[lines[9].Substring(0, index)] = lines[9].Substring(index + 1);
                }
            }
            if (lines.Length > 10)
            {
                if (!string.IsNullOrEmpty(lines[10]))
                {
                    int index = lines[10].IndexOf(":");
                    Header[lines[10].Substring(0, index)] = lines[10].Substring(index + 1);
                }
            }
            if (lines.Length > 11)
            {
                if (!string.IsNullOrEmpty(lines[11]))
                {
                    int index = lines[11].IndexOf(":");
                    Header[lines[11].Substring(0, index)] = lines[11].Substring(index + 1);
                }
            }
            if (lines.Length > 12)
            {
                if (!string.IsNullOrEmpty(lines[12]))
                {
                    int index = lines[12].IndexOf(":");
                    Header[lines[12].Substring(0, index)] = lines[12].Substring(index + 1);
                }
            }
            if (lines.Length > 13)
            {
                if (!string.IsNullOrEmpty(lines[13]))
                {
                    int index = lines[13].IndexOf(":");
                    Header[lines[13].Substring(0, index)] = lines[13].Substring(index + 1);
                }
            }

            if (lines.Length > 14)
            {
                if (!string.IsNullOrEmpty(lines[14]))
                {
                    string[] data = lines[14].Split('&');
                    foreach (string item in data)
                    {
                        int index = item.IndexOf("=");
                        Parameter[item.Substring(0, index)] = item.Substring(index + 1);
                    }
                }
            }

            int indexOne = Url.IndexOf("?");
            if (indexOne > 0)
            {
                if (Url.Length > indexOne + 2)
                {
                    string[] data = Url.Substring(indexOne + 1).Split('&');
                    foreach (string item in data)
                    {
                        int index = item.IndexOf("=");
                        if (index > 0)
                        {
                            Parameter[item.Substring(0, index)] = item.Substring(index + 1);
                        }
                    }
                }
            }
        }

        public string HttpMethod { get; set; } = "";
        public string Url { get; set; } = "";
        public string HttpVersion { get; set; } = "";
        public Dictionary<string, string> Header { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Parameter { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Cookie { get; set; } = new Dictionary<string, string>();
    }
}
