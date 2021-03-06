using System;

namespace RouletteGame
{
    public class Bet
    {
        public byte[] WinningNumbers { get; set; }
        public double Payout { get; set; }
        public double BetAmount { get; set; }
        public double WinAmount() => Payout * BetAmount + BetAmount;
    }
}