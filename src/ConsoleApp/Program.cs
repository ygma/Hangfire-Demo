using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                Console.WriteLine(line);
            }
        }
    }
}
