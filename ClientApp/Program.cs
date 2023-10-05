using System.Net.Sockets;

namespace ClientApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using TcpClient tcpClient = new TcpClient();
            try
            {
                await tcpClient.ConnectAsync("127.0.0.1", 8888);
                var stream = tcpClient.GetStream();

                using var streamReader = new StreamReader(stream);
                using var streamWriter = new StreamWriter(stream);

                while (true)
                {
                    string request = Console.ReadLine();

                    await streamWriter.WriteLineAsync(request);
                    await streamWriter.FlushAsync();

                    var responce = await streamReader.ReadLineAsync();
                    Console.Clear();
                    Console.WriteLine(responce);

                    if (request.ToLower() == "end")
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}