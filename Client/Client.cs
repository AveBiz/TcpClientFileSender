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

        internal Client([NotNull] IPAddress ipAddress, Port port)
        {
            if (ipAddress == null)
            {
                throw new ArgumentNullException(nameof(ipAddress));
            }

            _tcpClient = new TcpClient();

            _ipEndPoint = new IPEndPoint(ipAddress, port.PortNumber);
        }
        
        internal void Send(string filePath)
        {
            try
            {
                _tcpClient.Connect(_ipEndPoint);
                var clientSocket = _tcpClient.Client;

                SendFileName(filePath, clientSocket);

                try
                {
                    clientSocket.SendFile(filePath);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Somthing went wrong when open file");
                    throw;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong when sending");
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

            if (disposing)
            {
                _tcpClient.Close();
            }

            _disposed = true;
        }
    }
}