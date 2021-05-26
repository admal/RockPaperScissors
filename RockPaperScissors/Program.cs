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
            //For more sophisticated solutions a dependency injection would be setup and used
            var humanPlayer = new Player(new ConsoleInputProvider(), "Human");
            var aiPlayer = new Player(new RandomInputProvider(), "AI");
            var outputProvider = new ConsoleOutputProvider();
            var frontend = new ConsoleFrontend(outputProvider);

            IGame game = new Game(frontend, humanPlayer, aiPlayer, RuleSet.DefaultRuleSet);
            game.Play();
        }
    }
}
