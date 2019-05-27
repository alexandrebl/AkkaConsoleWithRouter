using System;
using Akka.Actor;
using AkkaConsole.Domain;
using AkkaConsole.Factory;
using AkkaConsole.ValueObj;
using AkkaConsoleWithrouter.Actros.Support;
using AkkaConsoleWithrouter.Domain;

namespace AkkaConsole.Actros {
    public class OperatorActor : ReceiveActor
    {
        public OperatorActor()
        {
            var actorFactory = new ActorFactory(Context);

            Receive<RequestData>(message => {
                var actor = actorFactory.GetInstance(message.ActionType);

                var data = new Data(message.ValueA,message.ValueB);

                var printActor = Context.ActorSelection($"/user/{nameof(PrinterActor)}");

                printActor.Tell(new PrintData($"Operation type: {message.ActionType}", ConsoleColor.Yellow));
            });
        }
    }
}
