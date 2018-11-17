using System;
using Akka.Actor;
using AkkaConsole.Domain;

namespace AkkaConsole.Actros {
    public class SumActor: ReceiveActor {

        public SumActor()
        {
            Receive<Data>(message =>
            {
                Console.WriteLine($"Sum: A - {message.ValueA} / B - {message.ValueB} / Result: {message.ValueA + message.ValueB}");
            });
        }

        public static Props Props() {
            return Akka.Actor.Props.Create(() => new AvgActor());
        }
    }
}
