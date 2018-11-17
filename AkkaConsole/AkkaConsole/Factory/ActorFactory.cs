using Akka.Actor;
using AkkaConsole.Actros;
using AkkaConsole.ValueObj;

namespace AkkaConsole.Factory {
    public class ActorFactory
    {
        private readonly IUntypedActorContext _untypedActorContext;
        public ActorFactory(IUntypedActorContext untypedActorContext)
        {
            _untypedActorContext = untypedActorContext;
        }

        public IActorRef GetInstance(ActionType actionType)
        {
            IActorRef actor = null;

            switch (actionType) {
                case ActionType.Sum:
                    actor = _untypedActorContext.ActorOf<SumActor>();
                    break;
                case ActionType.Avg:
                    actor = _untypedActorContext.ActorOf<AvgActor>();
                    break;
                default:
                    break;
            }

            return actor;
        }
    }
}
