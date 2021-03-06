using System;
using System.Collections.Generic;
using System.Text;
using RouletteGame;

namespace Roulette
{
    public class GameController
    {
        public double Money { get; set; }
        public List<Bet> Bets { get; set; }
        public string LastWinningNumber { get; set; }
        public BetInformation information { get; set; }
        public string Message { get; set; }

        public GameController(double StartingMoney)
        {
            Message = "";
            Money = StartingMoney;
            Bets = new List<Bet>();
            information = new BetInformation();
        }

        public void PlayRound()
        {
            string result = Renderer.SpinnerAnimation(Game.Spin());
            double winAmount = Game.PlayRound(Bets, result);
            if (winAmount > 0)
                Message = $"  Congrats! You have won ${winAmount}!  ";
            else
                Message = $"  No money rewarded. Play Again!  ";
            Money += winAmount;
            LastWinningNumber = result;
            Bets = new List<Bet>();
        }
    }
}
