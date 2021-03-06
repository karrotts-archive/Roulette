using System;
using System.Threading;
using RouletteGame;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer.Initialize();
            Console.WriteLine(Renderer.SpinnerAnimation(Game.Spin()));
        }
    }
}
