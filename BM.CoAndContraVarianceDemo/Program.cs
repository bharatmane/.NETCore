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

    //For covariance with delegates
    internal delegate Animal ReturnAnimalDelegate();
    internal delegate Bird ReturnBirdDelegate();

    //For contra variance with delegates
    internal delegate void TakeAnimalDelegate(Animal animal);
    internal delegate void TakeBirdDelegate(Bird bird);

    class Program
    {
        //For covariance with delegates
        public static Bird GetBird() => new Bird();
        public static Animal GetAnimal() => new Animal();

        //For contra variance with delegates
        public static void Eat(Animal animal) => animal.Eat();
        public static void Fly(Bird bird) => bird.Fly();

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

            //2. Contra variance with Delegates : reverses the assignment compatibility
            TakeBirdDelegate tbDelegate1 = Fly;      //valid
            TakeBirdDelegate tbDelegate2 = Eat;      //valid

            tbDelegate2(new Bird());                 //valid

            //Below stuff won't work because every animal can eat but it can't fly
            //TakeAnimalDelegate taDelegate1 = Fly;   //invalid
            //taDelegate1(new Animal());              //invalid





        }
    }
}
