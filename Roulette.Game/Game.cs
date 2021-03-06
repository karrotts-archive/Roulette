using System;
using System.Collections.Generic;
using System.Text;

namespace RouletteGame
{
    public static class Game
    {
        public static double PlayRound(List<Bet> Bets, string result)
        {
            //quick convert to proper format
            result = result == "00" ? "37" : result;
            byte numResult = byte.Parse(result);

            double totalPayout = 0d;
            foreach (Bet bet in Bets)
            {
                if(IsWinningBet(bet, numResult))
                {
                    totalPayout += bet.WinAmount();
                }
            }
            return totalPayout;
        }

        public static byte Spin()
        {
            Random random = new Random();
            return (byte)random.Next(38, 76);
        }

        public static byte Spin(int seed)
        {
            Random random = new Random(seed);
            return (byte)random.Next(38, 76);
        }

        public static bool IsWinningBet(Bet bet, int result)
        {
            foreach (int i in bet.WinningNumbers)
            {
                if (i == result) return true;
            }
            return false;
        }
    }
}
