using RockPaperScissors.Frontends.OutputProviders;
using RockPaperScissors.Players;

namespace RockPaperScissors.Frontends
{ 
    public class ConsoleFrontend : IFrontend
    {
        private readonly IOutputProvider _outputProvider;

        public ConsoleFrontend(IOutputProvider outputProvider)
        {
            _outputProvider = outputProvider;
        }

        public void WriteManual()
        {
            _outputProvider.Write("Welcome to Scissors Paper Rock the game!");
            _outputProvider.Write("Rules:");
            _outputProvider.Write("Paper beats Rock");
            _outputProvider.Write("Rock beats Scissors");
            _outputProvider.Write("Scissors beats Paper");
            _outputProvider.Write();
        }

        public void WriteRoundResult(Player player1, Player player2, RoundResult roundResult)
        {
            if (roundResult.Winner != null)
            {
                _outputProvider.Write($"{player1.Name}: {roundResult.Player1Sign}");
                _outputProvider.Write($"{player2.Name}: {roundResult.Player2Sign}");
                _outputProvider.Write($"Winner: {roundResult.Winner.Name}");
            }
            else
            {
                _outputProvider.Write($"{roundResult.Player1Sign} = {roundResult.Player2Sign}: Draw");
            }

            _outputProvider.Write($"{player1.Name} {player1.Score} : {player2.Score} {player2.Name}");
            _outputProvider.Write();
        }

        public void WriteWinner(Player winner)
        {
            _outputProvider.Write($"{winner.Name} won the game!");
        }
    }
}
