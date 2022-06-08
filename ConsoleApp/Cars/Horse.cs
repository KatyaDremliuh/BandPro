using System;

namespace ConsoleApp.Cars
{
    internal class Horse : IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Horse is running...");
        }
    }
}
