using System;
using System.Collections.Generic;
using RouletteGame;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController controller = new GameController(5000);
            Renderer.Initialize();
            Menus.MainMenu(controller);
        }
    }
}
