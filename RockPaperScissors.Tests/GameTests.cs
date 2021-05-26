using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors.Frontends;
using RockPaperScissors.Players;
using RockPaperScissors.Rules;
using System.Collections.Generic;

namespace RockPaperScissors.Tests
{
    [TestClass]
    public class GameTests
    {
        private RuleSet _rules;
        private Mock<IFrontend> _frontendMock;

        private const string Player1Name = "Player1";
        private const string Player2Name = "Player2";

        [TestInitialize]
        public void TestInit()
        {
            _rules = new RuleSet(new Dictionary<GameSign, GameSign>()
            {
                { GameSign.Paper, GameSign.Rock },
                { GameSign.Rock, GameSign.Scissors },
                { GameSign.Scissors, GameSign.Paper }
            });

            _frontendMock = new Mock<IFrontend>();
        }

        [TestMethod]
        [DataRow(GameSign.Rock, GameSign.Scissors, Player1Name, DisplayName ="Player1 wins")]
        [DataRow(GameSign.Paper, GameSign.Scissors, Player2Name, DisplayName ="Player2 wins")]
        [DataRow(GameSign.Paper, GameSign.Paper, null, DisplayName ="Draw")]
        public void TestRound(GameSign player1Sign, GameSign player2Sign, string expectedWinnerName)
        {
            //arrange
            var inputProvider1Mock = new Mock<Players.InputProviders.IInputProvider>();
            inputProvider1Mock.Setup(x => x.NextInput()).Returns(player1Sign);

            var inputProvider2Mock = new Mock<Players.InputProviders.IInputProvider>();
            inputProvider2Mock.Setup(x => x.NextInput()).Returns(player2Sign);

            var player1 = new Player(inputProvider1Mock.Object, Player1Name);
            var player2 = new Player(inputProvider2Mock.Object, Player2Name);
            var game = new Game(_frontendMock.Object, player1, player2, _rules);

            //act
            var result = game.NextRound();

            //assert
            Assert.AreEqual(expectedWinnerName, result.Winner?.Name);

            switch (expectedWinnerName)
            {
                case Player1Name:
                    Assert.AreEqual(1, player1.Score);
                    Assert.AreEqual(0, player2.Score);
                    break;
                case Player2Name:
                    Assert.AreEqual(0, player1.Score);
                    Assert.AreEqual(1, player2.Score);
                    break;
                default:
                    Assert.AreEqual(0, player1.Score);
                    Assert.AreEqual(0, player2.Score);
                    break;
            }
        }

        [TestMethod]
        public void GetWinnerTest_Player1Winner()
        {
            //arrange
            var roundsToWin = 2;
            var inputProvider1Mock = new Mock<Players.InputProviders.IInputProvider>();
            inputProvider1Mock.Setup(x => x.NextInput()).Returns(GameSign.Paper);

            var inputProvider2Mock = new Mock<Players.InputProviders.IInputProvider>();
            inputProvider2Mock.Setup(x => x.NextInput()).Returns(GameSign.Rock);

            var player1 = new Player(inputProvider1Mock.Object, Player1Name);
            var player2 = new Player(inputProvider2Mock.Object, Player2Name);
            var game = new Game(_frontendMock.Object, player1, player2, _rules, roundsToWin);

            //act
            game.NextRound();
            game.NextRound();

            var gameWinner = game.GetWinner();

            //assert
            Assert.AreEqual(gameWinner.Name, Player1Name);
            Assert.AreEqual(gameWinner.Score, roundsToWin);
        }

        [TestMethod]
        public void GameLoopTest()
        {
            //arrange
            var roundsToWin = 2;
            var inputProvider1Mock = new Mock<Players.InputProviders.IInputProvider>();
            inputProvider1Mock.Setup(x => x.NextInput()).Returns(GameSign.Paper);

            var inputProvider2Mock = new Mock<Players.InputProviders.IInputProvider>();
            inputProvider2Mock.Setup(x => x.NextInput()).Returns(GameSign.Rock);

            var player1 = new Player(inputProvider1Mock.Object, Player1Name);
            var player2 = new Player(inputProvider2Mock.Object, Player2Name);
            var game = new Game(_frontendMock.Object, player1, player2, _rules, roundsToWin);

            //act
            game.Play();

            var gameWinner = game.GetWinner();

            //assert
            Assert.AreEqual(gameWinner.Name, Player1Name);
            Assert.AreEqual(gameWinner.Score, roundsToWin);
        }
    }
}
