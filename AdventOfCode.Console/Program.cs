using AdventOfCode.Console.Clients;

namespace AdventOfCode.Console
{

    using Console = System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new NotQuiteLispClient().Solve());
            Console.ReadKey();
        }
    }
}
