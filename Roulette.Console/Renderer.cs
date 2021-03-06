using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Roulette
{
    public static class Renderer
    {
        public static ConsoleColor DefaultBackgroundColor = ConsoleColor.Gray;

        public static void Initialize()
        {
            Console.BackgroundColor = DefaultBackgroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public static void CenterText(string text, ConsoleColor backgroundColor, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - (text.Length / 2)) + "}", ""));
            Console.BackgroundColor = backgroundColor;
            Console.Write(text + "\n");
            Console.BackgroundColor = DefaultBackgroundColor;
        }

        public static void WriteLine(string text)
        {

        }

        public static void RenderRouletteSpinner(string highlightedNumber)
        {
            Spinner spinner = new Spinner(highlightedNumber);
            for (int i = 0; i < 30; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = DefaultBackgroundColor;
                Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - 30) + "}", ""));
                for (int j = 0; j < 11; j++)
                {
                    Console.BackgroundColor = spinner.SpinnerGrid[i, j].color;
                    Console.Write(spinner.SpinnerGrid[i, j].text);
                }
                Console.BackgroundColor = DefaultBackgroundColor;
                Console.Write("\n");
            }
        }

        public static void SpinnerAnimation()
        {
            string[] sequence = new string[]
            {
                    " 0", "28", " 9", "26", "30", "11", " 7", "20", "32", "17",
                    " 5", "22", "34", "15", " 3", "24", "36", "13", " 1", "00",
                    "27", "10", "25", "29", "12", " 8", "19", "31", "18", " 6",
                    "21", "33", "16", " 4", "23", "35", "14", " 2"
            };
            int sequenceNumber = 0;

            while (true)
            {
                Console.Clear();
                //Console.Beep();
                RenderRouletteSpinner(sequence[sequenceNumber]);
                sequenceNumber = sequenceNumber + 1 == sequence.Length ? 0 : sequenceNumber + 1;
                Thread.Sleep(1);
            }
        }

        public static void RenderRouletteBoard()
        {
        }
    }

    public class SpinnerRowItem
    {
        public ConsoleColor RowColor;
        public string Text;
        
        public SpinnerRowItem(string text, ConsoleColor color)
        {
            Text = text;
            RowColor = color;
        }
    }
}
