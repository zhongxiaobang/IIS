using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

namespace IIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("127.0.0.1");
            Dns.GetHostAddresses(Dns.GetHostName())
            .Where(t => t.AddressFamily == AddressFamily.InterNetwork)
            .ToList()
            .ForEach(item => 
            {
                comboBox1.Items.Add(item.ToString());
            });

            comboBox1.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("端口不能为空","温馨提示");
                return;
            }
            if (!Regex.IsMatch(textBox1.Text,"^[0-9]{4,5}$"))
            {
                MessageBox.Show("端口必须是4-5位数的纯数字", "温馨提示");
                return;
            }
            int port = Convert.ToInt32(textBox1.Text);

            if (!(port > 1400 && port <= 65535))
            {
                MessageBox.Show("端口必须是1401-65535", "温馨提示");
                return;
            }
            try
            {
                IPAddress ipAddress = IPAddress.Parse(comboBox1.Text);
                IPEndPoint point = new IPEndPoint(ipAddress, port);

                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(point);
                serverSocket.Listen(10);
                ThreadPool.QueueUserWorkItem(ProcessRequert, serverSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "温馨提示");
            }
        }

        private void ProcessRequert(object state)
        {
            Socket socket = state as Socket;
            while (true)
            {
                Socket clientSocket = socket.Accept();

                byte[] data = new byte[1024 * 1024 * 2];
                int len = 0;
                len = clientSocket.Receive(data);

                string requestText = Encoding.Default.GetString(data, 0, len);

                HttpContext context = new HttpContext(requestText);

                HttpApplication application = new HttpApplication();

                application.ProcessRequest(context);

                clientSocket.Send(context.Response.GetResponseHeader());
                clientSocket.Send(context.Response.Body);

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
