using RockPaperScissors.Players;
using RockPaperScissors.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public class RoundResult
    {
        public Player Winner { get; set; }
        public GameSign Player1Sign { get; set; }
        public GameSign Player2Sign { get; set; }
    }

    public class Game
    {
        private Player _player1;
        private Player _player2;
        private RuleSet _rules;
        private int _roundsToWin;

        public Game(Player player1, Player player2, RuleSet rules, int roundsToWin = 2)
        {
            _player1 = player1;
            _player2 = player2;
            _rules = rules;
            _roundsToWin = roundsToWin;
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
    }
}
