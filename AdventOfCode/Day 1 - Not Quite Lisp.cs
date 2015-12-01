using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    /// <summary>
    ///  Day 1 - Not Quite Lisp
    /// </summary>
    public class NotQuiteLisp
    {
        /// <summary>
        /// Traverses the specified directions and returns the destination floor.
        /// </summary>
        /// <param name="directions">Directions for traversing the building.</param>
        /// <returns>The destination floor indicated by the directions.</returns>
        public int Traverse(string directions)
        {
            return directions.Sum(Chomp);
        }

        /// <summary>
        /// Traverses the specified directions and returns the position at which Santa will enter the basement for the first time.
        /// </summary>
        /// <param name="directions">Directions for traversing the building.</param>
        /// <returns>The position at which Santa will enter the basement for the first time.</returns>
        public int TraverseToBasement(string directions)
        {
            var current = 0;

            return directions.TakeWhile(x => (current += Chomp(x)) != -1).Count() + 1;
        }

        private static int Chomp(char x)
        {
            return x == '(' ? 1 : x == ')' ? -1 : 0;
        }
    }
}
