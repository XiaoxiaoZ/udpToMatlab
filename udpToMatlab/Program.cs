using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace udpToMatlab
{
    class Program
    {

        static void Main(string[] args)
        {
            tcpclient t = new tcpclient();
            t.tcptest();
            

        }

        
    }
}
