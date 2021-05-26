using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Players.InputProviders
{
    public class UnknownCommandException : Exception { }

    public class ConsoleInputProvider : IInputProvider
    {
        public GameSign NextInput()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Select sign: scissors (s), rock (r), paper (p):");
                    var input = Console.ReadLine();

                    switch (input)
                    {
                        case "s":
                        case "scissors":
                            return GameSign.Scissors;
                        case "p":
                        case "paper":
                            return GameSign.Paper;
                        case "r":
                        case "rock":
                            return GameSign.Rock;
                        default:
                            throw new UnknownCommandException();
                    }
                }
                catch (UnknownCommandException)
                {
                    Console.WriteLine("Wrong command was provided.");
                }
            }
        }
    }
}
