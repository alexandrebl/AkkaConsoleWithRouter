using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;

namespace AkkaConsoleWithrouter.Actros.Support
{
    public class PrinterActor : ReceiveActor
    {
        public PrinterActor()
        {
            Receive<string>(messsge =>
            {
                Console.WriteLine($"{DateTime.UtcNow:o} -> {messsge}");
            });
        }
    }
}
