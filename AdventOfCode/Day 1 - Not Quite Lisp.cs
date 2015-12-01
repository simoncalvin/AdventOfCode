using System.Linq;

namespace AdventOfCode
{
    public class NotQuiteLisp
    {
        public object Solve(string input)
        {
            return input.Sum(x => x == '(' ? 1 : x == ')' ? -1 : 0);
        }
    }
}
