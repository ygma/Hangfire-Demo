using System;

namespace ClassLibrary
{
    public class Consumer
    {
        readonly Dependency _dependency;

        public Consumer(Dependency dependency)
        {
            _dependency = dependency;
        }

        public void Consume(string line)
        {
            Console.WriteLine(line);
        }
    }
}