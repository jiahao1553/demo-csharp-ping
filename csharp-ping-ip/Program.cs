using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace csharp_ping_ip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ping's the local machine.
            Ping pingSender = new Ping();
            //IPAddress address = IPAddress.Loopback;
            IPAddress address = IPAddress.Parse("192.168.1.1");

            for (int i = 0; i < 5; i++)
            {
                PingReply reply = pingSender.Send(address);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine(reply.Status);
                    Console.WriteLine("Address: {0}", reply.Address.ToString());
                    Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                }
                else
                {
                    Console.WriteLine(reply.Status);
                }

                System.Threading.Thread.Sleep(5000);
            }
            
            Console.Read();
        }
    }
}
