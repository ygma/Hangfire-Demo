using System;
using Hangfire;

namespace ConsoleApp
{
    internal class Producer
    {
        public bool Produce(IBackgroundJobClient backgroundJobClient)
        {
            var line = Console.ReadLine();

            if (line.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            backgroundJobClient.Enqueue<Consumer>(c => c.Consume(line));
            return true;
        }
    }
}