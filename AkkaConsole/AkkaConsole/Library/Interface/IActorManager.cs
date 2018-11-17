using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;

namespace AkkaConsole.Library.Interface {
    public interface IActorManager
    {
        IActorRef GetRouterInstance();
    }
}
