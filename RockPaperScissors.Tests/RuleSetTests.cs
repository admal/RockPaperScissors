using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.Rules;
using System.Collections.Generic;

namespace RockPaperScissors.Tests
{
    [TestClass]
    public class RuleSetTests
    {
        [TestMethod]
        public void NoRules()
        {
            //arrange
            var ruleSet = new RuleSet(new Dictionary<GameSign, GameSign>());

            //act
            var result = ruleSet.Beats(GameSign.Paper, GameSign.Rock);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NotEmptyRuleSet_NotExistingRuleProvided()
        {
            //arrange
            var ruleSet = new RuleSet(
                new Dictionary<GameSign, GameSign>() { { GameSign.Paper, GameSign.Rock } }
            );

            //act
            var result = ruleSet.Beats(GameSign.Scissors, GameSign.Paper);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NotEmptyRuleSet_ExistingRuleProvided_RockBeatsScissors()
        {
            //arrange
            var ruleSet = new RuleSet(
                new Dictionary<GameSign, GameSign>() { 
                    { GameSign.Paper, GameSign.Rock }, 
                    { GameSign.Rock, GameSign.Scissors } 
                }
            );

            //act
            var result = ruleSet.Beats(GameSign.Rock, GameSign.Scissors);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotEmptyRuleSet_ExistingRuleProvided_ScissorsDoesNotBeatRock()
        {
            //arrange
            var ruleSet = new RuleSet(
                new Dictionary<GameSign, GameSign>() { 
                    { GameSign.Paper, GameSign.Rock }, 
                    { GameSign.Rock, GameSign.Scissors },
                    { GameSign.Scissors, GameSign.Paper }
                }
            );

            //act
            var result = ruleSet.Beats(GameSign.Scissors, GameSign.Rock);

            //assert
            Assert.IsFalse(result);
        }
    }
}
