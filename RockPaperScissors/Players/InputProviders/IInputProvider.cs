using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Players.InputProviders
{
    public interface IInputProvider
    {
        GameSign NextInput();
    }
}