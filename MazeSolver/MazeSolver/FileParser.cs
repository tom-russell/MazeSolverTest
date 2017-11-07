using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolverNS
{
    /// <summary>
    /// Parser for parsing in the maze input files. Returns a Maze object containing all relevant maze details. 
    /// </summary>
    static class FileParser
    {
        public static Maze Parse(string filePath)
        {
            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    // Parse the width and height of the maze from file
                    string[] widthHeight = file.ReadLine().Split(' ');
                    int width = Int32.Parse(widthHeight[0]);
                    int height = Int32.Parse(widthHeight[1]);

                    // Parse the start and end X/Y positions from file
                    string[] startXY = file.ReadLine().Split(' ');
                    int startX = Int32.Parse(startXY[0]);
                    int startY = Int32.Parse(startXY[1]);

                    string[] endXY = file.ReadLine().Split(' ');
                    int endX = Int32.Parse(endXY[0]);
                    int endY = Int32.Parse(endXY[1]);

                    // Parse the maze itself and store as an integer array
                    int[][] maze = new int[height][];
                    String line;
                    int row = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        maze[row] = new int[width];
                        string[] lineSplit = line.Split(' ');

                        for (int col = 0; col < width; col++)
                        {
                            maze[row][col] = Int32.Parse(lineSplit[col]);
                        }

                        row++;
                    }

                    return new Maze(maze, width, height, new Vector(startX, startY), new Vector(endX, endY));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Input argument file not found.");
                Environment.Exit(1);
                return null;
            }
        }
    }
}
