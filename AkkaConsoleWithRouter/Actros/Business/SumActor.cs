using System;
using Akka.Actor;
using AkkaConsole.Domain;
using AkkaConsole.Library;
using AkkaConsoleWithrouter.Actros.Support;

namespace AkkaConsole.Actros {
    public class SumActor: ReceiveActor {

        public SumActor()
        {
            Receive<Data>(message =>
            {
                var result = message.ValueA + message.ValueB;

                var printActor = Context.ActorSelection($"/user/{nameof(PrinterActor)}");

                printActor.Tell( $"Sum result: {result}");
            });
        }
    }
}
