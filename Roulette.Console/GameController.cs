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

        public GameController(double StartingMoney)
        {
            Money = StartingMoney;
            Bets = new List<Bet>();
        }

        public void PlayRound()
        {
            string result = Renderer.SpinnerAnimation(Game.Spin());
            Money += Game.PlayRound(Bets, result);
            LastWinningNumber = result;
        }
    }
}
