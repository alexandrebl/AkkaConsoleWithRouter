using System;
using System.Threading;
using Akka.Actor;
using AkkaConsole.Domain;
using AkkaConsole.Library;
using AkkaConsole.ValueObj;
using AkkaConsoleWithrouter.Actros.Support;

namespace AkkaConsole {
    internal class Program {
        private static void Main()
        {
            var rootActorSystem = ActorSystem.Create($"{nameof(OperatorActorManager)}");

            var operatorActorManager = new OperatorActorManager("OperatorActorPool", rootActorSystem);
            var operatorActorRouter = operatorActorManager.GetRouterInstance();

            rootActorSystem.ActorOf(Props.Create(() => new PrinterActor()), nameof(PrinterActor));

            var random = new Random(DateTime.UtcNow.Millisecond);            

            while (true) {
                operatorActorRouter.Tell(new RequestData {
                    ActionType = ActionType.Avg,
                    ValueA = random.Next(0, 100),
                    ValueB = random.Next(0, 100)
                });

                operatorActorRouter.Tell(new RequestData {
                    ActionType = ActionType.Sum,
                    ValueA = random.Next(0, 100),
                    ValueB = random.Next(0, 100)
                });

                Thread.Sleep(10000);
            }
        }
    }
}
