using System;

namespace BM.CoAndContraVarianceDemo
{
    public class Animal
    {
        public void Eat() => Console.Write("Eat");
    }
    public class Bird: Animal
    {
        public void Fly() => Console.Write("Fly");
    }

    internal delegate Animal ReturnAnimalDelegate();
    internal delegate Bird ReturnBirdDelegate();
    
    class Program
    {
        public static Bird GetBird() => new Bird();
        public static Animal GetAnimal() => new Animal();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
