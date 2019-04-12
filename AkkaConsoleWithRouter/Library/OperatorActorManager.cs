using System;
using Akka.Actor;
using Akka.Routing;
using AkkaConsole.Actros;
using AkkaConsole.Library.Interface;

namespace AkkaConsole.Library {
    public sealed class OperatorActorManager : IActorManager {

        

        private readonly IActorRef _actorRouter;
        public OperatorActorManager(string poolName, ActorSystem actorSystem, int poolSize = 20)
        {
            _actorRouter = actorSystem.ActorOf(Props.Create<OperatorActor>().WithRouter(new RoundRobinPool(poolSize)), poolName);
        }

        public IActorRef GetRouterInstance()
        {
            return _actorRouter;
        }
    }
}
