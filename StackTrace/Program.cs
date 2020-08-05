using System;
using System.Collections.Generic;
using System.Linq;

namespace StackTrace
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictionairy = new string[,]
            {
                {"-", "-", "-","-", "p" },
                {"-", "-","-","-", "-" },
                {"-", "-","-","-", "-" },
                {"-", "-","-","-", "-" },
                {"-", "-","-","-", "-" }
            };
            DisplayPathtoPrincess(3, dictionairy);
        }
        static void DisplayPathtoPrincess(int n, string[,] matrix)
        {
            var column = -1;
            var row = FindRow(matrix, ref column);
            ProcessItemsForPrinting(matrix, row, column, n);
        }

        static int FindRow(string[,] matrix, ref int column)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var rowItems = MapSingleRowForSearching(matrix, i);
                if (rowItems.Contains("p"))
                {
                    column = rowItems.IndexOf("p");
                    return 0;
                }
            }
            return -1;
        }

        static List<string> MapSingleRowForSearching(string[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
               .Select(x => matrix[rowNumber, x])
               .ToList();
        }

        static void ProcessItemsForPrinting(string[,] matrix, int rowNumber, int columnNumber, int n)
        {
            int startingPoint = (n / 2);
            int difference = startingPoint - columnNumber;

            for (int i = 0; i < Math.Abs(difference); i++)
            {
                if (rowNumber - startingPoint >= 0) Console.WriteLine("UP");
                if (rowNumber - startingPoint < 0) Console.WriteLine("DOWN");
            }

            for (int i = 0; i < Math.Abs(difference); i++)
            {
                if (columnNumber - startingPoint < 0) Console.WriteLine("LEFT");
                if (columnNumber - startingPoint >= 0) Console.WriteLine("RIGHT");
            }
        }
    }
}
