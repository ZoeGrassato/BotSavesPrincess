using System;
using System.Collections.Generic;
using System.Linq;

namespace StackTrace
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var dictionairy = new string[,]
            //{
            //    //{"-", "-", "-","-", "p" },
            //    //{"-", "-","-","-", "-" },
            //    //{"-", "-","-","-", "-" },
            //    //{"-", "-","-","-", "-" },
            //    //{"-", "-","-","-", "-" }

            //     {"p", "-","-" },
            //    {"-","-", "-" },
            //    {"-","-", "-" }
            //};

            //int m;

            //m = int.Parse(Console.ReadLine());

            String[] grid = new String[] { "p", "-", "-", "-", "-", "-", "-", "-", "-" };
            //for (int i = 0; i < m; i++)
            //{
            //    grid[i] = Console.ReadLine();
            //}

            displayPathtoPrincess(3, grid);
        }

        static string[,] ConvertToMatrix(String[] matrixItems, int n)
        {
            var final = new string[n, n];
            int columnIteration = 0;

            for (int i = 0; i < n -1; i++)
            {
                for(int j = 0; j < n - 1; j++)
                {
                    final[i, j] = matrixItems[columnIteration];
                    columnIteration++;
                }
            }
            return final;
        }

        static void displayPathtoPrincess(int n, String[] stringItems)
        {
            var convertedMatrix = ConvertToMatrix(stringItems, n);
            var column = -1;
            var row = FindRow(convertedMatrix, ref column);
            ProcessItemsForPrinting( row, column, n);
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

        static void ProcessItemsForPrinting( int rowNumber, int columnNumber, int n)
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
