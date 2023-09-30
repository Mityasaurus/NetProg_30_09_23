using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ClientUI
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        IPEndPoint endPoint;
        List<Task> tasks = new List<Task>();
        bool switch_network = false;

        public Form1()
        {
            InitializeComponent();
        }
        private async Task ReadInfoFromServer()
        {
            if (!tcpClient.Connected)
            {
                ConnectionProcess(tb_IP.Text, int.Parse(tb_Port.Text));
            }

            var stream = tcpClient.GetStream();
            using var streamReader = new StreamReader(stream);
            string quote = await streamReader.ReadLineAsync();

            this.Invoke(() =>
            {
                tb_quote.Text = quote;
            });
        }
        private async void WriteInfoToServer(string message)
        {
            if(!tcpClient.Connected)
            {
                ConnectionProcess(tb_IP.Text, int.Parse(tb_Port.Text));
            }

            var stream = tcpClient.GetStream();
            using var streamWriter = new StreamWriter(stream);
            await streamWriter.WriteLineAsync(message);
            await streamWriter.FlushAsync();
        }
        private async void ConnectionProcess(string ip, int port)
        { 
            try
            {
                tcpClient = new TcpClient();
                endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                await tcpClient.ConnectAsync(endPoint);
            }
            catch
            {
                MessageBox.Show("Connection failed", "Error");
            }
        }
        private async void btnConnect_Click(object sender, EventArgs e)
        {

            var item = new Task(() => {
                ConnectionProcess(tb_IP.Text, int.Parse(tb_Port.Text));
            });
            
            item.Start();
            tasks.Add(item);
            //item.Wait();
        }

        private async void btnGetQuote_Click(object sender, EventArgs e)
        {
            if (!tcpClient.Connected)
            {
                ConnectionProcess(tb_IP.Text, int.Parse(tb_Port.Text));
            }

            //var stream = tcpClient.GetStream();

            try
            {
                //if (!switch_network == true)
                //{
                //    var item1 = Task.Run(() =>
                //    {
                //        ReadInfoFromServer();
                //    });
                //    tasks.Add(item1);
                //    switch_network = true;
                //}

                ReadInfoFromServer();

                WriteInfoToServer("200");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}