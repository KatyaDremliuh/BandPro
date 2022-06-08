using System;
using System.Drawing;

namespace ConsoleApp.Cars
{
    public abstract class Car : IMoveable
    {
        protected Color Color;

        public Color MyColor
        {
            get { return Color; }

            set
            {
                if (value == Color.Red)
                {
                    Console.WriteLine("Car cannot be red");
                    return;
                }

                Color = value;
            }
        }

        public Car(Color myColor)
        {
            MyColor = myColor;
        }

        public abstract void Drive();

        public void Move()
        {
            Console.WriteLine("Движение");
        }

        public abstract void TurnLight();
    }
}
