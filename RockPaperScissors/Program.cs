using RockPaperScissors.Frontends;
using RockPaperScissors.Frontends.OutputProviders;
using RockPaperScissors.Players;
using RockPaperScissors.Players.InputProviders;
using RockPaperScissors.Rules;
using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Scissors Paper Rock the game!");
            Console.WriteLine("Rules:");
            Console.WriteLine("Paper beats Rock");
            Console.WriteLine("Rock beats Scissors");
            Console.WriteLine("Scissors beats Paper");
            Console.WriteLine();

            //For more sophisticated solutions a dependency injection would be setup and used
            var humanPlayer = new Player(new ConsoleInputProvider(), "Human");
            var aiPlayer = new Player(new RandomInputProvider(), "AI");
            var outputProvider = new ConsoleOutputProvider();
            var frontend = new ConsoleFrontend(outputProvider);

            IGame game = new Game(frontend, humanPlayer, aiPlayer, RuleSet.DefaultRuleSet);
            game.Play();

            //while (true)
            //{
            //    var roundResult = game.NextRound();
            //    if (roundResult.Winner != null)
            //    {
            //        Console.WriteLine($"{humanPlayer.Name}: {roundResult.Player1Sign}");
            //        Console.WriteLine($"{aiPlayer.Name}: {roundResult.Player2Sign}");
            //        Console.WriteLine($"Winner: {roundResult.Winner.Name}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{roundResult.Player1Sign} = {roundResult.Player2Sign}: Draw");
            //    }
            //    Console.WriteLine($"{humanPlayer.Name} {humanPlayer.Score} : {aiPlayer.Score} {aiPlayer.Name}");
            //    Console.WriteLine();

            //    var gameWinner = game.GetWinner();
            //    if (gameWinner != null)
            //    {
            //        Console.WriteLine($"{gameWinner.Name} won the game!");
            //        return;
            //    }
            //}
        }
    }
}
