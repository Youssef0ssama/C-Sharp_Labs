using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal interface IMovable
    {
        void Move();
        void Stop();
        int getSpeed();
    }
    class Car : IMovable
    {
        private int speed;
        public Car()
        {
            speed = 0;
        }
        public void Move()
        {
            speed = 60;
            Console.WriteLine($"Car is moving at speed {speed} km/h.");
        }
        public void Stop()
        {
            speed = 0;
            Console.WriteLine($"Car has stopped.");
        }
        public int getSpeed()
        {
            return speed;
        }
    }
    internal interface IChargable
    {
        void Charge();
    }
    class robot : IMovable, IChargable
    {
        private int speed;
        private int batteryLevel;
        public robot()
        {
            speed = 0;
            batteryLevel = 100;
        }
        public void Move()
        {
            if (batteryLevel > 0)
            {
                speed = 5;
                batteryLevel -= 10;
                Console.WriteLine($"Robot is moving at speed {speed} km/h. Battery level: {batteryLevel}%");
            }
            else
            {
                Console.WriteLine("Battery is empty. Please charge the robot.");
            }
        }
        public void Stop()
        {
            speed = 0;
            Console.WriteLine("Robot has stopped.");
        }
        public int getSpeed()
        {
            return speed;
        }
        public void Charge()
        {

            batteryLevel = 100;
            Console.WriteLine("Robot is fully charged.");
        }

    }
}