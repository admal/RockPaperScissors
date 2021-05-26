using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Players
{
    public class Player
    {
        private InputProviders.IInputProvider _inputProvider;
        public int Score { get; private set; }
        public readonly string Name;

        public Player(InputProviders.IInputProvider inputProvider, string name)
        {
            Score = 0;
            _inputProvider = inputProvider;
            Name = name;
        }

        public void IncreaseScore()
        {
            Score++;
        }

        public GameSign NextSign()
        {
            var sign = _inputProvider.NextInput();
            return sign;
        }
    }
}
