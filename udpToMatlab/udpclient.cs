using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace udpToMatlab
{
    class tcpclient
    {
        // Use this for initialization
        internal Boolean socketReady = false;
        public TcpClient mySocket;
        public NetworkStream theStream;
        public StreamWriter theWriter;
        public StreamReader theReader;
        public String Host = "localhost";
        public Int32 Port = 55000;
        public tcpclient()
        {
            
        }
        public void tcptest()
        {
            Console.WriteLine("Hello World!");
            tcpclient u = new tcpclient();
            u.Start();
            while (true)
            {
                //Thread.Sleep(1000);
                u.Update();
            }
        }
        public void Start()
        {

            setupSocket();
            Console.WriteLine("socket is set up");
        }
        // Update is called once per frame
        public void Update()
        {
            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            writeSocket(unixTime.ToString());
            Console.WriteLine(unixTime.ToString() + " is sent");
        }

        public void setupSocket()
        {
            try
            {
                mySocket = new TcpClient(Host, Port);
                theStream = mySocket.GetStream();
                theWriter = new StreamWriter(theStream);
                socketReady = true;
  
            }
            catch (Exception e)
            {
                Console.WriteLine("Socket error: " + e);
            }
        }
        public void writeSocket(string the_line_arg)
        {
            if (!socketReady)
                return;
            string complete_line = the_line_arg;
            try
            {
                theWriter.Write(complete_line);
                theWriter.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("Writer error: " + e);
            }

        }
    }
}
