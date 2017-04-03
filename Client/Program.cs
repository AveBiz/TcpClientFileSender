using System;
using NetworkExtension;

namespace Client
{
    internal static class Program
    {
        private static void Main()
        {
            var serverInfo = new ServerInfo(ConnectionInfo.GetIpFromUserInput(), ConnectionInfo.GetPortFromUserInput());

            using (var client = new Client(serverInfo))
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