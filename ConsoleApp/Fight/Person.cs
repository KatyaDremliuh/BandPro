using System;

namespace ConsoleApp.Fight
{
    public abstract class Person
    {
        public abstract void ChallengeToCombat();

        public virtual void StartFight()
        {
            Console.WriteLine("Fighting!");
        }
    }
}