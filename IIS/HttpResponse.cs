using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IIS
{
    public class HttpResponse
    {
        public string StateCode { get; set; }
        public string StateDes { get; set; }
        public string ContentType { get; set; }
        public Stream OutPutStream { get;}
        public HttpResponse()
        {
            OutPutStream = new MemoryStream();
        }
        public byte[] GetResponseHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("HTTP/1.1 {0} {1}", StateCode, StateDes));
            sb.AppendLine(string.Format("Date:{0}", DateTime.Now.ToString()));
            sb.AppendLine(string.Format("Content-Type:{0}", ContentType));
            sb.AppendLine(string.Format("Content-Length:{0}", OutPutStream.Length));
            sb.AppendLine();
            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            OutPutStream.Write(buffer, offset, count);
        }

        public void Write(byte[] buffer)
        {
            Write(buffer, 0, buffer.Length);
        }

        
    }
}
