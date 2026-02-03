using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal abstract class Animal
    {
        public abstract void MakeSound();
        public abstract void Move();
    }
    internal class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
        public override void Move()
        {
            Console.WriteLine("The dog runs.");
        }
    }
    internal class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
        public override void Move()
        {
            Console.WriteLine("the cat is scratching.");
        }
    }
    internal class Bird : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("TWEEET!");
        }
        public override void Move()
        {
            Console.WriteLine("The bird flies.");
        }
    }
}