using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolverNS
{
    static class ArrayPrinter
    {
        // Print the input char array to console, formatted with spaces
        public static void Print(char[][] charArray)
        {
            Console.BufferHeight = 800; // Required for the large example to fully display in the console output

            int height = charArray.Length;
            int width = charArray[0].Length;

            // Print the output array
            for (int i = 0; i < height; i++)
            {
                StringBuilder line = new StringBuilder();
                for (int j = 0; j < width; j++)
                {
                    line.Append(charArray[i][j] + " ");
                }
                Console.WriteLine(line);
                line.Clear();
            }
        }
    }
}
