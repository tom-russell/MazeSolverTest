using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolverNS
{
    /// <summary>
    /// Basic 2D vector class, represents a position in the maze based on x/y coordinates.
    /// </summary>
    class Vector
    {
        public int x;
        public int y;

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
