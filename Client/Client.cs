using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using JetBrains.Annotations;

namespace Client
{
    internal sealed class Client : IDisposable
    {
        [NotNull] private readonly TcpClient _tcpClient;

        private bool _disposed;

        internal Client(ServerIp serverIp, Port serverPort)
        {
            _tcpClient = new TcpClient();

            var ipEndPoint = new IPEndPoint(serverIp.IpAddress, serverPort.PortNumber);
            _tcpClient.Connect(ipEndPoint);
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _tcpClient.Close();

            _disposed = true;
        }

        internal void Send(string filePath)
        {
            try
            {
                var clientSocket = _tcpClient.Client;

                var fileName = $"<FileName>{Path.GetFileName(filePath)}";

                clientSocket.Send(Encoding.Unicode.GetBytes(fileName));
                clientSocket.Send(File.ReadAllBytes(filePath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}