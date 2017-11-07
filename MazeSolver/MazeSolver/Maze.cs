using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolverNS
{
    /// <summary>
    /// Maze class contains the maze itself as an integer array, and additional information such as dimensions and 
    /// start/end points.
    /// </summary>
    class Maze
    {
        public int[][] maze { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }
        public Vector start { get; private set; }
        public Vector end { get; private set; }

        public Maze(int[][] maze, int width, int height, Vector start, Vector end)
        {
            this.maze = maze;
            this.width = width;
            this.height = height;
            this.start = start;
            this.end = end;
        }

        // Returns the maze as a char array, where:
        // '#' = representing walls
        // ' ' = navigable space
        // 'S' = starting point in the maze
        // 'E' = end point in the maze
        public char[][] AsCharArray()
        {
            char[][] charMaze = new char[height][];

            for (int i = 0; i < height; i++)
            {
                charMaze[i] = new char[width];
                for (int j = 0; j < width; j++)
                {
                    charMaze[i][j] = maze[i][j] == 0 ? ' ' : '#';
                }
            }

            // Change the start and end points to their respective characters
            charMaze[start.y][start.x] = 'S';
            charMaze[end.y][end.x] = 'E';

            return charMaze;
        }
    }
}
