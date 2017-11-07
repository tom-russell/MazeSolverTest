using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolverNS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use the small maze as default if user does not provide input args
            string filePath = "mazeTests/sparse_medium.txt";    
            if (args.Length > 0)
            {
                filePath = args[0];
            }

            // Parse the input maze
            Maze maze = FileParser.Parse(filePath);

            // Find and print a solution to the maze, if one exists
            MazeSolver ms = new MazeSolver(maze);
            ms.PrintSolution();

            Console.ReadLine();
        }
    }
}
