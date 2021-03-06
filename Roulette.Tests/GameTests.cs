using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RouletteGame;

namespace Roulette.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void SpinWithSeedDoesNotProvideRandomNumber()
        {
            Assert.AreEqual(Game.Spin(12), Game.Spin(12));
        }

        [TestMethod]
        public void IsWinningBetWithOneWinningValue()
        {
            Bet bet = new Bet()
            {
                WinningNumbers = new byte[] { 1 },
                Payout = 35,
                BetAmount = 100
            };
            Assert.AreEqual(true, Game.IsWinningBet(bet, 1));
        }

        [TestMethod]
        public void IsWinningBetWithNoWinningValue()
        {
            RouletteGame.Bet bet = new RouletteGame.Bet()
            {
                WinningNumbers = new byte[] { 2 },
                Payout = 35,
                BetAmount = 100
            };
            Assert.AreEqual(false, RouletteGame.Game.IsWinningBet(bet, 1));
        }
    }
}
