using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Frontends.OutputProviders
{
    public class ConsoleOutputProvider : IOutputProvider
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
