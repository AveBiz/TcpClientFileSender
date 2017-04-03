using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using JetBrains.Annotations;
using NetworkExtension;

namespace Client
{
    internal sealed class Client : Disposable
    {
        [NotNull] private readonly IPEndPoint _ipEndPoint;
        [NotNull] private readonly TcpClient _tcpClient;

        private bool _disposed;

        internal Client(ServerInfo serverInfo)
        {
            _tcpClient = new TcpClient();

            _ipEndPoint = new IPEndPoint(serverInfo.IpAddress, serverInfo.Port.PortNumber);
        }
        
        internal void Send(string filePath)
        {
            try
            {
                _tcpClient.Connect(_ipEndPoint);
                var clientSocket = _tcpClient.Client;

                SendFileName(filePath, clientSocket);

                clientSocket.SendFile(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void SendFileName(string filePath, Socket clientSocket)
        {
            var fileName = $"{PackageAttributes.FileName.GetPackageAttribute()}{Path.GetFileName(filePath)}";

            clientSocket.Send(Encoding.Unicode.GetBytes(fileName));
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _tcpClient.Close();

            _disposed = true;
        }
    }
}