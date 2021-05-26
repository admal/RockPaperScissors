using RockPaperScissors.Players;

namespace RockPaperScissors
{
    public class RoundResult
    {
        public Player Winner { get; set; }
        public GameSign Player1Sign { get; set; }
        public GameSign Player2Sign { get; set; }
    }
}
