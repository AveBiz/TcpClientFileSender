using System;

namespace Client
{
    internal static class Program
    {
        private static void Main()
        {
            var port = UserInputWorker.GetPortFromUserInput();
            var clientIp = UserInputWorker.GetIpFromUserInput();

            using (var client = new Client(clientIp, port))
            {
                try
                {
                    client.Send(UserInputWorker.GetFilePathFromUserInput());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}