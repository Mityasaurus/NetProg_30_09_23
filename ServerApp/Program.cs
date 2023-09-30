using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var server = new TcpListener(IPAddress.Any, 8888);
            var quotes = new List<string>
            {
                "Два самых важных дня в вашей жизни - день, когда вы родились, и день, когда вы поняли, зачем.",
                "Величайший характеристикой человека является его способность быть настоящим с самим собой.",
                "Будущее зависит от того, что вы делаете сегодня.",
                "Самая невероятная машина, которой вы когда-либо управляли, - ваше собственное тело.",
                "Единственное место, где успех и работа идут вместе перед работой - в словаре.",
                "Жизнь - это что-то, что случается, когда вы заняты другими планами.",
                "Ваше время ограничено, не тратьте его, живя чужой жизнью.",
                "Последнее, что вы хотите, - это дойти до конца жизни и понять, что вы прожили ее в соответствии с чужими ожиданиями.",
                "Наибольший триумф - это тот, который приходит после самой большой борьбы.",
                "Будьте изменением, которое вы хотите видеть в мире."
            };

            try
            {
                server.Start();
                Console.WriteLine("Server started. Waiting for connections...");

                while(true)
                {
                    using var client = await server.AcceptTcpClientAsync();
                    Console.WriteLine("Client connected");
                    var stream = client.GetStream();

                    using var streamReader = new StreamReader(stream);
                    using var streamWriter = new StreamWriter(stream);

                    Random rand = new Random();
                    string responce = quotes[rand.Next(0, quotes.Count)];

                    await streamWriter.WriteLineAsync(responce);
                    await streamWriter.FlushAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Stop();
            }
        }
    }
}