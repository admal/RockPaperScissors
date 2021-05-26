using RockPaperScissors.Frontends;
using RockPaperScissors.Players;
using RockPaperScissors.Rules;

namespace RockPaperScissors
{
    public interface IGame
    {
        void Play();
    }

    public class Game : IGame
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly RuleSet _rules;
        private readonly int _roundsToWin;
        private readonly IFrontend _frontend;

        public Game(IFrontend frontend, Player player1, Player player2, RuleSet rules, int roundsToWin = 2)
        {
            _player1 = player1;
            _player2 = player2;
            _rules = rules;
            _roundsToWin = roundsToWin;
            _frontend = frontend;
        }

        public RoundResult NextRound()
        {
            var player1Sign = _player1.NextSign();
            var player2Sign = _player2.NextSign();

            var result = new RoundResult()
            {
                Player1Sign = player1Sign,
                Player2Sign = player2Sign
            };

            if (_rules.Beats(player1Sign, player2Sign))
            {
                result.Winner = _player1;
                _player1.IncreaseScore();
                return result;
            }
            else if (_rules.Beats(player2Sign, player1Sign))
            {
                result.Winner = _player2;
                _player2.IncreaseScore();
                return result;
            }
            else
            {
                return result;
            }
        }

        public Player GetWinner()
        {
            if (_player1.Score >= _roundsToWin)
            {
                return _player1;
            }

            if (_player2.Score >= _roundsToWin)
            {
                return _player2;
            }

            return null;
        }

        public void Play()
        {
            _frontend.WriteManual();

            while (true)
            {
                var roundResult = NextRound();
                _frontend.WriteRoundResult(_player1, _player2, roundResult);

                var gameWinner = GetWinner();
                if (gameWinner != null)
                {
                    _frontend.WriteWinner(gameWinner);
                    return;
                }
            }
        }
    }
}
