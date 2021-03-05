using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RouletteTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void SpinWithSeedDoesNotProvideRandomNumber()
        {
            Assert.AreEqual(RouletteGame.Game.Spin(12), RouletteGame.Game.Spin(12));
        }

        [TestMethod]
        public void IsWinningBetWithOneWinningValue()
        {
            RouletteGame.Bet bet = new RouletteGame.Bet()
            {
                WinningNumbers = new int[] { 1 },
                Payout = 35,
                BetAmount = 100
            };
            Assert.AreEqual(true, RouletteGame.Game.IsWinningBet(bet, 1));
        }

        [TestMethod]
        public void IsWinningBetWithNoWinningValue()
        {
            RouletteGame.Bet bet = new RouletteGame.Bet()
            {
                WinningNumbers = new int[] { 2 },
                Payout = 35,
                BetAmount = 100
            };
            Assert.AreEqual(false, RouletteGame.Game.IsWinningBet(bet, 1));
        }
    }
}
