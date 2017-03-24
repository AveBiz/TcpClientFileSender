using System;
using System.IO;
using System.Net;

namespace Client
{
    internal static class UserInputWorker
    {
        internal static string GetFilePathFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Enter file path: ");

                var userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    WritePortIsInvalid();
                    continue;
                }

                if (!File.Exists(userInput))
                {
                    Console.WriteLine("File didn't exists");
                    continue;
                }

                FileStream fileStream;

                try
                {
                    fileStream = File.OpenRead(userInput);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    continue;
                }

                if (!fileStream.CanRead)
                {
                    Console.WriteLine("Can't read this file");
                }

                fileStream.Close();

                return userInput;
            }
        }

        internal static Port GetPortFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Enter port number: ");

                var userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    WritePortIsInvalid();
                    continue;
                }

                int portNumber;
                if (!int.TryParse(userInput, out portNumber))
                {
                    WritePortIsInvalid();
                    continue;
                }

                var port = new Port {PortNumber = portNumber};

                if (port.IsPortNumberValid())
                {
                    return port;
                }

                WritePortIsInvalid();
            }
        }


        internal static ServerIp GetIpFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Enter ip address: ");

                var userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    WriteIpIsInvalid();
                    continue;
                }

                IPAddress ipAddress;
                if (!IPAddress.TryParse(userInput, out ipAddress))
                {
                    WriteIpIsInvalid();
                    continue;
                }

                var clientIp = new ServerIp {IpAddress = ipAddress};

                return clientIp;
            }
        }

        private static void WritePortIsInvalid()
        {
            Console.WriteLine("Port number is invalid\n");
        }

        private static void WriteIpIsInvalid()
        {
            Console.WriteLine("Ip address is invalid\n");
        }
    }
}