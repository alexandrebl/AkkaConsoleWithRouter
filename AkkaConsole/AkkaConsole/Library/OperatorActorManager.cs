using System;
using Akka.Actor;
using Akka.Routing;
using AkkaConsole.Actros;
using AkkaConsole.Library.Interface;

namespace AkkaConsole.Library {
    public sealed class OperatorActorManager : IActorManager {

        private static readonly ActorSystem RootActorSystem = ActorSystem.Create($"{nameof(OperatorActorManager)}");

        private readonly IActorRef _actorRouter;
        public OperatorActorManager(string poolName, int poolSize = 20)
        {
            _actorRouter = RootActorSystem.ActorOf(Props.Create<OperatorActor>().WithRouter(new RoundRobinPool(poolSize)), poolName);
        }

        public IActorRef GetRouterInstance()
        {
            return _actorRouter;
        }
    }
}
