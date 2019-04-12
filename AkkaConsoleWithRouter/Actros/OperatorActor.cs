using System;
using Akka.Actor;
using AkkaConsole.Domain;
using AkkaConsole.Factory;
using AkkaConsole.ValueObj;

namespace AkkaConsole.Actros {
    public class OperatorActor : ReceiveActor
    {
        public OperatorActor()
        {
            var actorFactory = new ActorFactory(Context);

            Receive<RequestData>(message => {
                var actor = actorFactory.GetInstance(message.ActionType);

                var data = new Data()
                {
                    ValueA = message.ValueA,
                    ValueB = message.ValueB
                };

                actor.Tell(data);
            });
        }
    }
}
