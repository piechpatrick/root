﻿using Butterfly.Server;
using Butterfly.Server.Core;
using Butterfly.Server.Core.Instances;
using Butterfly.Server.Services;
using Butterfly.Server.Shell;
using System;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;

// State object for reading client data asynchronously  
public class StateObject
{
    // Client  socket.  
    public Socket workSocket = null;
    // Size of receive buffer.  
    public const int BufferSize = 3854;
    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];
    // Received data string.  
    public StringBuilder sb = new StringBuilder();
}

public class Program
{
    public static void Main(String[] args)
    {
        try
        {
            if (!Environment.UserInteractive)
            {
                var services = new ServiceBase[]
                {
                        new ButterflyService()
                };
                ServiceBase.Run(services);
            }
            else
            {
                var bootstrapper = new Bootstrapper();
                bootstrapper.Build();

                var butterflyServer = bootstrapper.Reslove<IButterflyServer>();
                butterflyServer.Start();
            }
        }
        catch (Exception e)
        {
            
        }
    }
}