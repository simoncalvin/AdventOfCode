using AdventOfCode.Console.Clients;

namespace AdventOfCode.Console
{

    using Console = System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            var day1 = new NotQuiteLispClient();

            Console.WriteLine($"Day 1 - Not Quite Lisp: { day1.SolveForFinalFloor() }, { day1.SolveForFirstBasementEntry() }");
            Console.ReadKey();
        }
    }
}
