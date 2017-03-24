using System.Linq;
using System.Net.NetworkInformation;

namespace Client
{
    internal static class PortExtensions
    {
        internal static bool IsPortNumberValid(this Port port)
        {
            var portNumber = port.PortNumber;

            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnections = ipGlobalProperties.GetActiveTcpConnections();

            return tcpConnections.All(tcpi => tcpi?.LocalEndPoint?.Port != portNumber);
        }
    }
}