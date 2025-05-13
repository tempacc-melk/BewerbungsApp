using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsAppGUI
{
    internal static class Program
    {
        private static TcpListener tcpv4;
        private static TcpListener tcpv6;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        internal static void StartListener ()
        {
            tcpv6 = new(IPAddress.IPv6Loopback, 50000);
            tcpv4 = new(IPAddress.Loopback, 50000);
            if (tcpv6 != null) 
            {
                tcpv6.Start();
            } 
            else
            {
                tcpv4.Start();
            }
        }
        internal static void CloseListener()
        {
            tcpv4?.Stop();
            tcpv6?.Stop();
        }
        internal static string GetListenerMsg ()
        {
            string output = string.Empty;

            try
            {
                if (tcpv4 != null)
                {
                    _ = LoadStream(tcpv4.AcceptTcpClient());
                }
                else
                {
                    _ = LoadStream(tcpv6.AcceptTcpClient());
                }

            }
            catch (SocketException se)
            {
                output = $"Socket exception: \n{se}";
            }


            return output;
        }

        private static string LoadStream(TcpClient tcp)
        {
            StringBuilder output = new ();
            NetworkStream stream = tcp.GetStream();

            byte[] buffer = new byte[tcp.ReceiveBufferSize];
            try
            {
                int bytesRead = stream.Read(buffer, 0, tcp.ReceiveBufferSize);
                while (bytesRead > 0) 
                {
                    output.Append (Encoding.UTF8.GetString(buffer, 0, bytesRead));
                    bytesRead = stream.Read (buffer,0, tcp.ReceiveBufferSize);
                }
            }
            catch (IOException ioe)
            {
                Debug.WriteLine(ioe);
            }
            return output.ToString();
        }

        private static void SendMessageToConsole ()
        {
            // wip
        }
        
    }
}