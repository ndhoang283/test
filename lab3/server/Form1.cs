using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UdpClient udpClient;
        public void serverThread()
        {
            udpClient = new UdpClient(Int32.Parse(textBox1.Text));
            MessageBox.Show("Listening");
            while (true)
            {
                IPEndPoint RemotelpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemotelpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                string mess = RemotelpEndPoint.Address.ToString() + ":" + returnData.ToString();
                InfoMessage(mess);
            }
        }
        public void InfoMessage(string mess)
        {
            ListViewItem item = new ListViewItem();
            item.Text = mess;
            listView1.Items.Add(item);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            udpClient.Close();
        }
    }
}
