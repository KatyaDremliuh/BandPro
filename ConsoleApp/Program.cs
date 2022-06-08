using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ConsoleApp.Cars;
using ConsoleApp.Fight;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            List<Car> allCars = new List<Car>();
            allCars.Add(new Bmw(Color.White));
            allCars.Add(new Bmw(Color.Yellow));
            allCars.Add(new Mazda(Color.Black));

            foreach (Car car in allCars)
            {
                car.Drive();
                car.TurnLight();
            }

            // 05

            List<Person> people = new()
            {
                new Ivan(),
                new Khabib(),
            };

            foreach (Person person in people)
            {
                person.ChallengeToCombat();
                person.StartFight();
            }

            Console.WriteLine();
            string name = "Ivan";

            Sum(500, out int param1, out int param2, 2000);
            Console.WriteLine($"Sum of money = {param1}, {param2}");

            double savings = 5000;
            double scotchPrice = 12.8;
            ReduceSavings(savings, scotchPrice, out double currentRest);
            Console.WriteLine($"{name} had had {savings} $. " + $"\nThan he invested {scotchPrice} $ for scotch. "
                + $"\nHis current balance is {currentRest}.");
        }

        private static void Sum(int otherMoney, out int param1, out int param2, int otherMoney1 = 1000)
        {
            int bankAccount = 100;
            int cash = 900;

            param1 = bankAccount + cash + otherMoney + otherMoney1;
            param2 = 888;
        }

        private static void ReduceSavings(double savings, double scotchPrice, out double rest)
        {
            rest = savings - scotchPrice;
        }
    }
}