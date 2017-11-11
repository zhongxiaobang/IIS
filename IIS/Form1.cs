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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "温馨提示");
            }
        }
    }
}
