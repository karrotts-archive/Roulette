using System;
using System.Collections.Generic;
using System.Text;

namespace RouletteGame
{
    public enum BetType : byte
    {
        Numbers,
        Evens,
        Odds,
        Reds,
        Blacks,
        Lows,
        Highs,
        Dozens,
        Columns,
        Street,
        Doubles,
        Split,
        Corner
    }

    public class BetInformation
    {
        public readonly Dictionary<BetType, BetDetails> Information;
        
        BetInformation()
        {
            Information.Add(BetType.Numbers, new BetDetails(new List<byte[]>(), 35));
            Information.Add(BetType.Evens, new BetDetails(new List<byte[]>()
            {
                new byte[] {2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36}
            }, 1));
            Information.Add(BetType.Odds, new BetDetails(new List<byte[]>()
            {
                new byte[] {1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35}
            }, 1));
            Information.Add(BetType.Reds, new BetDetails(new List<byte[]>()
            {
                new byte[] {1, 3, 5, 7, 9, 12, 14, 16, 18, 21, 23, 25, 27, 28, 30, 32, 36}
            }, 1));
            Information.Add(BetType.Blacks, new BetDetails(new List<byte[]>()
            {
                new byte[] {1, 3, 5, 7, 9, 12, 14, 16, 18, 21, 23, 25, 27, 28, 30, 32, 36}
            }, 1));
            Information.Add(BetType.Lows, new BetDetails(new List<byte[]>()
            { 
                new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18}
            }, 1));
            Information.Add(BetType.Highs, new BetDetails(new List<byte[]>()
            {
                new byte[] { 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36}
            }, 1));
            Information.Add(BetType.Dozens, new BetDetails(new List<byte[]>()
            {
                new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12},
                new byte[] { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24},
                new byte[] { 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36}
            }, 2));
            Information.Add(BetType.Columns, new BetDetails(new List<byte[]>()
            {
                new byte[] { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34},
                new byte[] { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35},
                new byte[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36}
            }, 2));

        }
    }

    public class BetDetails
    {
        List<byte[]> WinningSets;
        byte Payout;

        public BetDetails(List<byte[]> WinningSets, byte Payout)
        {
            this.WinningSets = WinningSets;
            this.Payout = Payout;
        }
    }
}
