using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    public class Spinner
    {
        public SpinnerGridItem[,] SpinnerGrid = new SpinnerGridItem[30, 11];
        public List<SpinnerGridItem> items;
        string highlightedText;

        public Spinner(string highlightedText)
        {
            items = new List<SpinnerGridItem>()
            {
                new SpinnerGridItem(0, 0, ConsoleColor.Red, "12"),
                new SpinnerGridItem(1, 0, ConsoleColor.Black, "29"),
                new SpinnerGridItem(2, 0, ConsoleColor.Red, "25"),
                new SpinnerGridItem(3, 0, ConsoleColor.Black, "10"),
                new SpinnerGridItem(4, 0, ConsoleColor.Red, "27"),
                new SpinnerGridItem(5, 0, ConsoleColor.Green, "00"),
                new SpinnerGridItem(6, 0, ConsoleColor.Red, " 1"),
                new SpinnerGridItem(7, 0, ConsoleColor.Black, "13"),
                new SpinnerGridItem(8, 0, ConsoleColor.Red, "36"),
                new SpinnerGridItem(9, 0, ConsoleColor.Black, "24"),
                new SpinnerGridItem(10, 0, ConsoleColor.Red, " 3"),
                new SpinnerGridItem(0, 1, ConsoleColor.Black, " 8"),
                new SpinnerGridItem(10, 1, ConsoleColor.Black, "15"),
                new SpinnerGridItem(0, 2, ConsoleColor.Red, "19"),
                new SpinnerGridItem(10, 2, ConsoleColor.Red, "34"),
                new SpinnerGridItem(0, 3, ConsoleColor.Black, "31"),
                new SpinnerGridItem(10, 3, ConsoleColor.Black, "22"),
                new SpinnerGridItem(0, 4, ConsoleColor.Red, "18"),
                new SpinnerGridItem(10, 4, ConsoleColor.Red, " 5"),
                new SpinnerGridItem(0, 5, ConsoleColor.Black, " 6"),
                new SpinnerGridItem(10, 5, ConsoleColor.Black, "17"),
                new SpinnerGridItem(0, 6, ConsoleColor.Red, "21"),
                new SpinnerGridItem(10, 6, ConsoleColor.Red, "32"),
                new SpinnerGridItem(0, 7, ConsoleColor.Black, "33"),
                new SpinnerGridItem(10, 7, ConsoleColor.Black, "20"),
                new SpinnerGridItem(0, 8, ConsoleColor.Red, "16"),
                new SpinnerGridItem(10, 8, ConsoleColor.Red, " 7"),
                new SpinnerGridItem(0, 9, ConsoleColor.Black, " 4"),
                new SpinnerGridItem(1, 9, ConsoleColor.Red, "23"),
                new SpinnerGridItem(2, 9, ConsoleColor.Black, "35"),
                new SpinnerGridItem(3, 9, ConsoleColor.Red, "14"),
                new SpinnerGridItem(4, 9, ConsoleColor.Black, " 2"),
                new SpinnerGridItem(5, 9, ConsoleColor.Green, " 0"),
                new SpinnerGridItem(6, 9, ConsoleColor.Black, "28"),
                new SpinnerGridItem(7, 9, ConsoleColor.Red, " 9"),
                new SpinnerGridItem(8, 9, ConsoleColor.Black, "26"),
                new SpinnerGridItem(9, 9, ConsoleColor.Red, "30"),
                new SpinnerGridItem(10, 9, ConsoleColor.Black, "11"),
            };

            for(int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    SpinnerGrid[i, j] = new SpinnerGridItem(Renderer.DefaultBackgroundColor , "      ");
                }
            }

            foreach(SpinnerGridItem item in items)
            {
                //Console.WriteLine($"DEBUG ({item.x}, {item.y}) Color: {item.color} Value: {item.text}");

                if (item.text == highlightedText)
                    item.color = ConsoleColor.Yellow;

                item.y *= 3;
                
                for (int i = item.y; i < item.y + 3; i++)
                {
                    string text = i > item.y && i < item.y + 2 ? $"  {item.text}  " : "      ";
                    SpinnerGrid[i, item.x] = new SpinnerGridItem(item.color, text);
                }
            }
        }
    }

    public class SpinnerGridItem
    {
        public int x, y;
        public ConsoleColor color;
        public string text;

        public SpinnerGridItem(ConsoleColor color, string text)
        {
            this.color = color;
            this.text = text;
        }

        public SpinnerGridItem(int x, int y, ConsoleColor color, string text)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.text = text;
        }
    }
}
