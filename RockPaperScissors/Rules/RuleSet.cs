using System.Collections.Generic;

namespace RockPaperScissors.Rules
{
    public class RuleSet
    {
        private IDictionary<GameSign, GameSign> _rules;

        public static RuleSet DefaultRuleSet => new RuleSet(new Dictionary<GameSign, GameSign>()
            {
                { GameSign.Paper, GameSign.Rock },
                { GameSign.Rock, GameSign.Scissors },
                { GameSign.Scissors, GameSign.Paper }
            });

        public RuleSet(IDictionary<GameSign, GameSign> rules)
        {
            _rules = rules;
        }

        public bool Beats(GameSign sign1, GameSign sign2)
        {
            if (_rules.ContainsKey(sign1) == false)
            {
                return false;
            }
            return _rules[sign1] == sign2;
        }
    }
}
