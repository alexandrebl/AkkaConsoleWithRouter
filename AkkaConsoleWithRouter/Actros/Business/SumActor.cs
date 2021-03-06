﻿using System;
using Akka.Actor;
using AkkaConsole.Domain;
using AkkaConsole.Library;
using AkkaConsoleWithrouter.Actros.Support;
using AkkaConsoleWithrouter.Domain;

namespace AkkaConsole.Actros {
    public class SumActor: ReceiveActor {

        public SumActor()
        {
            Receive<Data>(message =>
            {
                var result = message.ValueA + message.ValueB;

                var printActor = Context.ActorSelection($"/user/{nameof(PrinterActor)}");

                printActor.Tell(new PrintData($"Sum result: {result}", ConsoleColor.Cyan));

                Context.Self.GracefulStop(new TimeSpan(1000));
            });
        }
    }
}
