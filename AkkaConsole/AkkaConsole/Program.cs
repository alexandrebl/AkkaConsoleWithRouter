using System;
using System.Threading;
using Akka.Actor;
using AkkaConsole.Domain;
using AkkaConsole.Library;
using AkkaConsole.ValueObj;

namespace AkkaConsole {
    internal class Program {
        private static void Main(string[] args)
        {
            var operatorActorManager = new OperatorActorManager("OperatorActorPool");
            var operatorActorRouter = operatorActorManager.GetRouterInstance();

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

                operatorActorRouter.Tell(new RequestData {
                    ActionType = ActionType.Sum,
                    ValueA = random.Next(0, 100),
                    ValueB = random.Next(0, 100)
                });

                Thread.Sleep(1000);
                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}
