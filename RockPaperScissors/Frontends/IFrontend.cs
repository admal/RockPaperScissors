﻿using RockPaperScissors.Players;

namespace RockPaperScissors.Frontends
{
    public interface IFrontend
    {
        void WriteRoundResult(Player player1, Player player2, RoundResult roundResult);
        void WriteWinner(Player winner);
    }
}
