using System;

namespace BM.CoAndContraVarianceDemo
{
    public class Animal
    {
        public void Eat() => Console.Write("Eat"); //Using expression body feature
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
            //1. Covariance with Delegates : Preserves the assignment compatibility
            Animal animal = new Bird();             //valid 
            ReturnAnimalDelegate ad1 = GetAnimal;   //valid 
            ReturnAnimalDelegate ad2 = GetBird;     //valid 
            animal = ad2();                         //valid

            //Bird bird = new Animal();             //invalid
            //ReturnBirdDelegate bd1 = GetAnimal;   //invalid
            //The reason is bd1.Eat() is fine, but bd1.Fly() won't be available
            //as the instance is animal

            



        }
    }
}
