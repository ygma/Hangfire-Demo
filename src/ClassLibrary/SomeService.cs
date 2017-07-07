using System;

namespace ClassLibrary
{
    public class SomeService
    {
        public void Print(string s)
        {
            Console.WriteLine($"In consumer: {s}");
        }
    }
}