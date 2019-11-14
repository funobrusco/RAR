using Microsoft.Extensions.Logging;
using System;
using System.Net.NetworkInformation;


namespace RAR.API.Utility
{
    public static class PingTest
    {
        public static bool PingHost(string hostName, ILogger logger, int timeout)
        {
            var pingable = false;
            Ping pinger = null;
            //const int timeout = 10000;
            try
            {
                pinger = new Ping();
                var reply = pinger.Send(hostName, timeout);
                if (reply != null) pingable = reply.Status == IPStatus.Success;
            }
            catch (Exception ex)
            {
                // Discard PingExceptions and return false;
                logger.LogError($"Error pinging remote host {hostName}, cant write in shared folder: " + ex.Message);
                pingable = false;
            }
            finally
            {
                pinger?.Dispose();
            }
            return pingable;
        }
    }
}
