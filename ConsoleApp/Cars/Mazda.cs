﻿using System;
using System.Drawing;

namespace ConsoleApp.Cars
{
    public class Mazda : Car
    {
        public Mazda(Color myColor) : base(myColor)
        {
            Console.WriteLine("Ctor Mazda");
        }

        public override void TurnLight()
        {
            Console.WriteLine("Mazda turned on light");
        }

        public override void Drive()
        {
            Console.WriteLine("I drive Mazda");
        }
    }
}
