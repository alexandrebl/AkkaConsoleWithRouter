using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using AkkaConsoleWithrouter.Domain;

namespace AkkaConsoleWithrouter.Actros.Support
{
    public class PrinterActor : ReceiveActor
    {
        private static object obj = new object();
        public PrinterActor()
        {
            Receive<PrintData>(messsge =>
            {
                lock (obj)
                {
                    Console.ForegroundColor = messsge.ConsoleColor;
                    Console.WriteLine($"{DateTime.UtcNow:o} -> {messsge.Message} ||||| from: {Sender.Path}");
                }
            });
        }
    }
}
