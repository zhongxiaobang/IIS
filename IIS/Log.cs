using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS
{
    public class Log
    {
        public static void Info(string msg)
        {
            try
            {
                File.AppendAllLines("log.txt",new string[] {msg },Encoding.UTF8);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
