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
using System.Net;
using System.Threading;
using System.Net.Sockets;


namespace lab3
{
    public partial class sever : Form
    {
        public sever()
        {
            InitializeComponent();
            Thread thdUDPSever = new Thread(new ThreadStart(severThread));
        }
        public void InfoMessage(string mess)
        {
            ListViewItem lv = new ListViewItem();
            lv.Text = mess;
            listView1.Items.Add(lv);
        }

        public void severThread()
        {
            UdpClient udpClient = new UdpClient(8080);
            while (true) { 
            IPEndPoint RemotelpEndPoint = new IPEndPoint(IPAddress.Any,0);
            Byte[] receiveBytes=udpClient.Receive(ref RemotelpEndPoint);
            string returnData =Encoding.ASCII.GetString(receiveBytes);
            string mess= RemotelpEndPoint.Address.ToString()+":"+ returnData.ToString();
            InfoMessage(mess);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
