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
            tcpv4 = new(System.Net.IPAddress.Loopback, 50000);
            tcpv6 = new(System.Net.IPAddress.IPv6Loopback, 50000);
            if (tcpv4 != null) 
            {
                tcpv4.Start();
                return;
            } 
            else
            {
                tcpv6.Start();
            }
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
            string output = string.Empty;

            NetworkStream stream = tcp.GetStream();

            int buffer = tcp.ReceiveBufferSize;

            while (buffer > 0)
            {
                buffer = tcp.ReceiveBufferSize;
            }

            if (buffer > 0)
            {

            }
            return output;
        }

        internal static void EnableListener ()
        {

        }

        internal static void DisableListener() 
        { 
        
        }
    }
}