using System;
using System.Collections.Generic;
using System.Text;
using RouletteGame;

namespace Roulette
{
    public static class Menus
    {
        public static void Header(GameController controller)
        {
            Console.Clear();
            Renderer.CenterText("  Welcome To Wes's Casino!  ", ConsoleColor.White, ConsoleColor.Black);
            Renderer.CenterText($"  CASH: ${controller.Money}  ", ConsoleColor.Green, ConsoleColor.Black);
            Renderer.CenterText($"  Last Number: {controller.LastWinningNumber}  ", ConsoleColor.Blue, ConsoleColor.White);
        }
        public static void DisplayMenu(List<string> options, int current)
        {
            if (current > options.Count - 1 || current < 0)
                current = 0;

            for(int i = 0; i < options.Count; i++)
            {
                if (i == current)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.Write(options[i]);
                Console.BackgroundColor = Renderer.DefaultBackgroundColor;
                Console.WriteLine("");
            }
        }

        public static int Clamp(int maxValue, int minValue, int currentValue)
        {
            if (currentValue > maxValue)
                return maxValue;
            if (currentValue < minValue)
                return minValue;
            return currentValue;
        }

        public static void MainMenu(GameController controller)
        {
            int current = 0;
            List<string> options = new List<string>()
            {
                "\tPlay Round",
                "\tPlace Bets",
                "\tView Current Bets",
                "\tExit Game"
            };

            do
            {
                Header(controller);
                Renderer.Line();
                Console.WriteLine("");
                Menus.DisplayMenu(options, current);
                Renderer.Line();

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case (ConsoleKey.UpArrow):
                        current = current <= 0 ? options.Count - 1 : --current;
                        break;
                    case (ConsoleKey.DownArrow):
                        current = current >= options.Count - 1 ? 0 : ++current;
                        break;
                    case (ConsoleKey.Enter):
                        switch(options[current])
                        {
                            case "\tPlay Round":
                                controller.PlayRound();
                                break;
                            case "\tPlace Bets":
                                BetMenu(controller);
                                break;
                            case "\tView Current Bets":
                                break;
                            case "\tExit Game":
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

            } while (true);
        }
        
        public static void BetMenu(GameController controller)
        {
            int current = 0;
            List<string> options = new List<string>();
            foreach(string type in Enum.GetNames(typeof(BetType)))
            {
                options.Add("\t* " + type);
            }

            int numberOfPages = options.Count / 5;
            int currentPage = 0;

            do
            {
                List<string> page = options.GetRange(currentPage * 5, Clamp(5, 0, options.Count - currentPage * 5));
                if (currentPage < numberOfPages)
                    page.Add("\tNext Page");
                if (currentPage > 0)
                    page.Add("\tPrevious Page");
                page.Add("\tExit Menu");

                Header(controller);
                Renderer.Line();
                Console.WriteLine("");
                DisplayMenu(page, current);
                Renderer.Line();

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case (ConsoleKey.UpArrow):
                        current = current <= 0 ? page.Count - 1 : --current;
                        break;
                    case (ConsoleKey.DownArrow):
                        current = current >= page.Count - 1 ? 0 : ++current;
                        break;
                    case (ConsoleKey.Enter):
                        switch(page[current])
                        {
                            case "\tNext Page":
                                currentPage++;
                                break;
                            case "\tPrevious Page":
                                currentPage--;
                                break;
                            case "\tExit Menu":
                                current = -1;
                                break;
                        }
                        break;
                    default:
                        break;
                }
            } while (current >= 0);
        }
    }
}
