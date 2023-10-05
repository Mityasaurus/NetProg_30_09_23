using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    internal class Program
    {
        private static int currentActiveUsers = 0;

        private static readonly ILogger logger = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        }).CreateLogger<Program>();

        private static readonly int maxQuotes = 5;
        private static readonly int maxUsers = 3;

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

                while (true)
                {
                    var client = await server.AcceptTcpClientAsync();
                    currentActiveUsers++;
                    Task.Run(() => HandleClientAsync(client, quotes));
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

        static async Task HandleClientAsync(TcpClient client, List<string> quotes)
        {
            var clientEndPoint = client.Client.RemoteEndPoint.ToString();

            logger.LogInformation($"Client connected: {clientEndPoint} at {DateTime.Now}");

            var stream = client.GetStream();

            using var streamReader = new StreamReader(stream);
            using var streamWriter = new StreamWriter(stream);



            int counter = 0;

            while (true)
            {
                var request = await streamReader.ReadLineAsync();
                if (request.ToLower() == "end")
                {
                    break;
                }

                string responce;

                if (currentActiveUsers > maxUsers)
                {
                    responce = "The server is overloaded. Try to connect later.";

                    await streamWriter.WriteLineAsync(responce);
                    await streamWriter.FlushAsync();

                    logger.LogWarning($"Users limit({maxUsers}) reached. Disconnecting {clientEndPoint}.");

                    break;
                }

                if (counter >= maxQuotes)
                {
                    responce = "You have reached the maximum number of requests allowed. Closing the connection...";

                    await streamWriter.WriteLineAsync(responce);
                    await streamWriter.FlushAsync();

                    logger.LogInformation($"Quote limit reached for {clientEndPoint}. Closing connection.");

                    break;
                }

                Random rand = new Random();
                responce = quotes[rand.Next(0, quotes.Count)];

                await streamWriter.WriteLineAsync(responce);
                await streamWriter.FlushAsync();

                logger.LogInformation($"Sent quote to {clientEndPoint}: {responce}");
                counter++;
            }

            client.Close();
            currentActiveUsers--;
            logger.LogInformation($"Client disconnected: {clientEndPoint} at {DateTime.Now}");
        }
    }
}