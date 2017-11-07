using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolverNS
{
    /// <summary>
    /// Solves the input maze, using a breadth first search to find a solution (not necessarily the most efficient).
    /// The solution is stored as an ordered List<Vector>, where each Vector is a step taken from start to end point. 
    /// If the solution is an empty list, no solution is possible.
    /// </summary>
    class MazeSolver
    {
        private Maze m;
        public List<Vector> solution;

        public MazeSolver(Maze maze)
        {
            this.m = maze;
            solution = new List<Vector>();

            Solve();
        }

        // Attempts to find a solution for the maze. If a solution can be found, a list of the moves taken is returned,
        // else an empty list is return.
        private void Solve()
        {
            bool success = RecursiveSolver(m.start.x, m.start.y);
            if (success == true)    
            {
                // The start location is not required in the solution moveset
                solution.RemoveAt(0);
            }
        }

        // Solve the maze using a recursive depth-first search.
        private bool RecursiveSolver(int x, int y)
        {
            // If this position is a wall, this route is invalid
            if (IsWall(x, y)) return false;

            // If this position has already been used in the current solution attempt, return false to avoid a loop
            if (PositionAlreadyUsed(x, y))
            {
                return false;
            }

            // Add this new step/position to the current solution
            solution.Add(new Vector(x, y));

            // If an adjacent cell is the end, we have found a solution to the maze (return true)
            if (IsEnd(x, y))
            {
                return true;
            }

            // Depth-first search of the maze (directions prioritised Left -> Down -> Right -> Up).
            // If a solution is found the 'true' is passed up the function stack, ending the search
            if (RecursiveSolver(x + 1, y) == true)
            {
                return true;
            }
            else if (RecursiveSolver(x, y + 1) == true)
            {
                return true;
            }
            else if (RecursiveSolver(x - 1, y) == true)
            {
                return true;
            }
            else if (RecursiveSolver(x, y - 1) == true)
            {
                return true;
            }
            else // Return false if this path is invalid
            {
                solution.RemoveAt(solution.Count - 1);
                return false;
            }
        }

        // Returns true if the given cell position is a wall
        private bool IsWall(int x, int y)
        {
            if (m.maze[y][x] == 1)
            {
                return true;
            }
            else return false;
        }

        // Returns true if an adjacent cell is the end point
        private bool IsEnd(int x, int y)
        {
            Vector end = m.end;
            
            if (x == end.x + 1 && y == end.y ||
                x == end.x - 1 && y == end.y ||
                x == end.x && y == end.y + 1 ||
                x == end.x && y == end.y - 1)
            {
                return true;
            }
            else return false;
        }

        // Returns true if the input position has already been used in the current route
        private bool PositionAlreadyUsed(int x, int y)
        {
            foreach (Vector step in solution)
            {
                if (x == step.x && y == step.y)
                {
                    return true;
                }
            }
            return false;
        }

        // Prints the maze with solution steps represented as 'X'. 
        // If no solution was available print the basic empty maze.
        public void PrintSolution()
        {
            if (solution.Count == 0)
            {
                ArrayPrinter.Print(m.AsCharArray());
                Console.WriteLine("No solution found!");
            }
            else
            {
                Char[][] charMaze = m.AsCharArray();
                foreach (Vector step in solution)
                {
                    charMaze[step.y][step.x] = 'X';
                }
                
                ArrayPrinter.Print(charMaze);
                Console.WriteLine("Solved!");
            }
        }
    }
}
