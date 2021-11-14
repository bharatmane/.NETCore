using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

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

    public class Human : Animal
    {
        public void Think() => Console.Write("Think");
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

        //For covariance with Generics
        internal interface IProcess<out T>
        {
            T Process();
        }

        public class AnimalProcess<T>:IProcess<T>
        {
            public T Process()
            {
                throw new NotImplementedException();
            }
        }

        internal interface IZoo<T>
        {
            void Add(T t);
        }

        internal class Zoo<T>:IZoo<T>
        {
            public void Add(T t)
            {
                //Log goes here
            }
        }

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

            //3. Covariance with arrays
            Animal[] animals = new Bird[10];          //valid

            //However, there's slit glitch here, if we assign animal array's
            //one of the element with Human class which is also derived from animal
            //we may not get compilation error but we would have runtime error
            //System.ArrayTypeMismatchException
            animals[0] = new Human();                 //no compilation error, but runtime


            //4. Covariance with Generics
            IProcess<Animal> animalProcess = new AnimalProcess<Animal>();
            IProcess<Bird> birdProcess = new AnimalProcess<Bird>();

            //animalProcess = birdProcess;            //by default it won't work
            //However, once we add out keyword to interface deceleration IProcess<out T>, it works
            animalProcess = birdProcess;

            IEnumerable<Animal> animalList = new List<Bird>();  //valid

            //5. contra Variance with Generics
            IZoo<Animal> animalZoo= new Zoo<Animal>();
            animalZoo.Add(new Animal());

            IZoo<Bird> birdZoo = new Zoo<Bird>();
            birdZoo.Add(new Bird());

            //this won't work as birdzoo can't have animals that are other than birds
            //birdZoo = animalZoo;              //invalid













        }
    }
}
