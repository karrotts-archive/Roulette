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
            Renderer.CenterText("  Welcome To Wes's Roulette Table!  ", ConsoleColor.White, ConsoleColor.Black);
            Renderer.CenterText($"  CASH: ${controller.Money}  ", ConsoleColor.Green, ConsoleColor.Black);
            Renderer.CenterText($"  Last Number: {controller.LastWinningNumber}  ", ConsoleColor.Blue, ConsoleColor.White);
            if (controller.Message != "")
            {
                Renderer.CenterText(controller.Message, ConsoleColor.Blue, ConsoleColor.White);
            }
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
                            default:
                                string result = page[current].Trim().Substring(2);
                                BetType bet = (BetType)Enum.Parse(typeof(BetType), result);
                                current = BetValueMenu(controller, bet);
                                break;
                        }
                        break;
                    default:
                        break;
                }
            } while (current >= 0);
        }

        public static int BetValueMenu(GameController controller, BetType type)
        {
            if (type == BetType.Numbers)
            {
                int status = 0;
                string message = "";
                while(status == 0)
                {
                    Console.Clear();
                    Header(controller);
                    Renderer.Line();
                    Console.WriteLine();
                    if (message != "")
                        Console.WriteLine(message);
                    Console.WriteLine("\tWhat number do you want to bet on? Type 'exit' to go back. \n");
                    Console.Write("\t>  ");
                    string result = Console.ReadLine();

                    if (result == "exit") return 0;
                    if (result == "00") result = "37";

                    bool isValid = false;

                    if(!isValid)
                    {
                        if (byte.TryParse(result, out byte value))
                        {
                            if (value >= 0 && value < 38)
                                isValid = true;
                        }
                    }

                    if(isValid)
                    {
                        Bet bet = new Bet();
                        bet.Payout = controller.information.Information[type].Payout;
                        bet.WinningNumbers = new byte[] { byte.Parse(result) };
                        status = BetAmountMenu(controller, bet);
                    }
                    message = $"Invalid input: {result}";
                }
                return -1;
            }
            else 
            {
                int current = 0;
                List<string> options = new List<string>();
                foreach(byte[] set in controller.information.Information[type].WinningSets)
                {
                    string s = "\t * { ";
                    for(int i = 0; i < set.Length; i++)
                    {
                        s += i < set.Length - 1 ? set[i].ToString() + ", " : set[i].ToString() + " }"; 
                    }
                    options.Add(s);
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

                    current = Clamp(page.Count - 1, 0, current);

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
                            switch (page[current])
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
                                default:
                                    Bet bet = new Bet();
                                    bet.Payout = controller.information.Information[type].Payout;
                                    bet.WinningNumbers = controller.information.Information[type].WinningSets[currentPage * 5 + current];
                                    BetAmountMenu(controller, bet);
                                    return -1;
                            }
                            break;
                        default:
                            break;
                    }

                } while (current >= 0);
            }
            return 0;
        }

        public static int BetAmountMenu(GameController controller, Bet bet)
        {
            string message = "";
            int status = 0;
            while(status == 0)
            {
                Header(controller);
                Renderer.Line();
                Console.WriteLine();
                if (message != "")
                    Console.WriteLine(message);
                Console.WriteLine("\tHow much do you want to bet? Type 'exit' to go back. \n");
                Console.Write("\t>  ");
                string result = Console.ReadLine();
                if (result == "exit") return 0;
                if (Double.TryParse(result, out double value))
                {
                    double leftover = controller.Money - value;
                    if (leftover >= 0)
                    {
                        controller.Money -= value;
                        bet.BetAmount = value;
                        controller.Bets.Add(bet);
                        controller.Message = $"${value} Bet Added. Payout: ${bet.WinAmount()}";
                        return -1;
                    }
                    message = "Insufficient Funds!";
                    continue;
                }
                message = $"Invalid Input: {result}";
            }
            return 0;
        }
    }
}
