using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaConsoleWithrouter.Domain
{
    public class PrintData
    {
        public string Message { get; }
        public ConsoleColor ConsoleColor { get; }

        public PrintData(string messagem, ConsoleColor consoleColor)
        {
            Message = messagem;
            ConsoleColor = consoleColor;
        }
    }
}
