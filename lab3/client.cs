using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace lab3
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            Byte[] sendBytes = Encoding.ASCII.GetBytes("Hello World?");
            udpClient.Send(sendBytes, sendBytes.Length, tbHost.Text, 8080);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
