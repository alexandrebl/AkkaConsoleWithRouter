using System;
using Akka.Actor;
using AkkaConsole.Domain;
using AkkaConsoleWithrouter.Actros.Support;

namespace AkkaConsole.Actros
{
    public class AvgActor : ReceiveActor
    {
        public AvgActor()
        {
            Receive<Data>(message =>
            {
                var result = (message.ValueA + message.ValueB) / 2;

                var printActor =  Context.ActorOf(Props.Create(() => new PrinterActor()));

                printActor.Tell($"Avg result: {result}");
            });
        }
    }
}
