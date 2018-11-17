using System;
using Akka.Actor;
using AkkaConsole.Domain;

namespace AkkaConsole.Actros {
    public class AvgActor : ReceiveActor {
        public AvgActor()
        {
            Receive<Data>(message => {
                Console.WriteLine($"Avg: A - {message.ValueA} / B - {message.ValueB} / Result: {(message.ValueA + message.ValueB) / 2}");
            });
        }

        public static Props Props() {
            return Akka.Actor.Props.Create(() => new AvgActor());
        }
    }
}
