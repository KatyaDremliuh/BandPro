using System;

namespace ConsoleApp.Cars
{
    internal class Horse : IMoveble
    {
        public void Move()
        {
            Console.WriteLine("Horse is running...");
        }
    }
}
