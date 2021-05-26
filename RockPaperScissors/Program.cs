using RockPaperScissors.Players;
using RockPaperScissors.Rules;
using System;
using System.Collections.Generic;

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

            var rules = new RuleSet(new Dictionary<GameSign, GameSign>()
            {
                { GameSign.Paper, GameSign.Rock },
                { GameSign.Rock, GameSign.Scissors },
                { GameSign.Scissors, GameSign.Paper }
            });

            var humanPlayer = new Player(new Players.InputProviders.ConsoleInputProvider(), "Human");
            var aiPlayer = new Player(new Players.InputProviders.RandomInputProvider(), "AI");

            var game = new Game(humanPlayer, aiPlayer, rules);

            while (true)
            {
                var roundResult = game.NextRound();
                if (roundResult.Winner != null)
                {
                    Console.WriteLine($"{humanPlayer.Name}: {roundResult.Player1Sign}");
                    Console.WriteLine($"{aiPlayer.Name}: {roundResult.Player2Sign}");
                    Console.WriteLine($"Winner: {roundResult.Winner.Name}");
                }
                else
                {
                    Console.WriteLine($"{roundResult.Player1Sign} = {roundResult.Player2Sign}: Draw");
                }
                Console.WriteLine($"{humanPlayer.Name} {humanPlayer.Score} : {aiPlayer.Score} {aiPlayer.Name}");
                Console.WriteLine();

                var gameWinner = game.GetWinner();
                if (gameWinner != null)
                {
                    Console.WriteLine($"{gameWinner.Name} won the game!");
                    return;
                }
            }
        }
    }
}
