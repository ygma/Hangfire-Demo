using System;
using Hangfire;

namespace ConsoleApp
{
    internal class Producer
    {
        readonly IBackgroundJobClient backgroundJobClient;

        public Producer(IBackgroundJobClient backgroundJobClient)
        {
            this.backgroundJobClient = backgroundJobClient;
        }

        public bool Produce()
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