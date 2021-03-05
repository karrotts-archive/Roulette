using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Roulette.Tests
{
    [TestClass]
    public class BetTests
    {
        [TestMethod]
        public void BetWinningAmountCheck()
        {
            RouletteGame.Bet bet = new RouletteGame.Bet()
            {
                BetAmount = 10,
                Payout = 2
            };

            Assert.AreEqual(30, bet.WinAmount());
        }

        [TestMethod]
        public void BetWinningAmountCheck2()
        {
            RouletteGame.Bet bet = new RouletteGame.Bet()
            {
                BetAmount = 10,
                Payout = 1
            };

            Assert.AreEqual(20, bet.WinAmount());
        }
    }
}
