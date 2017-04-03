using System;
using System.Net;
using JetBrains.Annotations;
using NetworkExtension;

namespace Client
{
    internal struct ServerInfo
    {
        public ServerInfo([NotNull] IPAddress ipAddress, Port port)
        {
            if (ipAddress == null)
            {
                throw new ArgumentNullException(nameof(ipAddress));
            }

            IpAddress = ipAddress;
            Port = port;
        }

        internal Port Port { get; }

        [NotNull]
        internal IPAddress IpAddress { get; }
    }
}