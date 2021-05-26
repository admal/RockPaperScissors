using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Players.InputProviders
{
    public class RandomInputProvider : IInputProvider
    {
        private Random _rnd;

        public RandomInputProvider()
        {
            _rnd = new Random();
        }

        public GameSign NextInput()
        {
            var sign = (GameSign)_rnd.Next(3);
            return sign;
        }
    }
}
