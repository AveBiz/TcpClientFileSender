using System;
using NetworkExtension;

namespace Client
{
    internal static class Program
    {
        private static void Main()
        {
            using (var client = new Client(ConnectionInfo.GetIpFromUserInput(), ConnectionInfo.GetPortFromUserInput()))
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