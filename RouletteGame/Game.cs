using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Game
{
    public static class Game
    {
        public static double PlayRound(List<Bet> Bets)
        {
            double totalPayout = 0d;
            byte result = Spin();
            foreach (Bet bet in Bets)
            {
                if(IsWinningBet(bet, result))
                {
                    totalPayout += bet.WinAmount();
                }
            }
            return totalPayout;
        }

        public static byte Spin()
        {
            Random random = new Random();
            return (byte)random.Next(0, 37);
        }

        public static byte Spin(int seed)
        {
            Random random = new Random(seed);
            return (byte)random.Next(0, 37);
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
