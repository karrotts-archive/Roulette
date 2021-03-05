using System;

namespace Roulette.Game
{
    public class Bet
    {
        public byte[] WinningNumbers { get; set; }
        public double Payout { get; set; }
        public double BetAmount { get; set; }
        public double WinAmount() => Payout * BetAmount + BetAmount;
    }
}

// Blacks
// 2, 4, 6, 8, 10, 11, 13, 15, 17, 19, 20, 22, 24, 26, 29, 31, 33, 35

// Reds
// 1, 3, 5, 7, 9, 12, 14, 16, 18, 21, 23, 25, 27, 28, 30, 32, 34, 36
