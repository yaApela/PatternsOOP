using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOOP
{
    // ПАТТЕРН ФАБРИЧНЫЙ МЕТОД
    class Forest // основной класс - лес в котором может быть множесто типов животных
    {
        private IAnimals[] animals;

        public Forest(IAnimals[] Animals)
        {
            this.animals = Animals;
        }

        public void GetInfoForAnimals()
        {
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine($"{i + 1}) Название животного: {animals[i].name}, Вес животного: {animals[i].weight}.");
                animals[i].Sound();
            }
        }
    }

    interface IAnimalsFactories
    {
        public IAnimals Create();
    }

    class ManyAnimalsForest : IAnimalsFactories
    {
        private Random random = new Random();
        private readonly List<Type> _animals = new List<Type>()
        {
            typeof(Deer),
            typeof(Moose),
            typeof(Hog)
        };
        public IAnimals Create()
        {
            var _animalIndex = random.Next(0, _animals.Count);
            var typeOfEnemy = _animals[_animalIndex];
            return Activator.CreateInstance(typeOfEnemy) as IAnimals;
        }
    }

    class FewAnimalsForest : IAnimalsFactories
    {
        private Random random = new Random();
        private readonly List<Type> _animals = new List<Type>()
        {
            typeof(Deer),
            typeof(Hog)
        };
        public IAnimals Create()
        {
            var _animalIndex = random.Next(0, _animals.Count);
            var typeOfEnemy = _animals[_animalIndex];
            return Activator.CreateInstance(typeOfEnemy) as IAnimals;
        }
    }

    interface IAnimals
    {
        public string name { get; }
        public double weight { get; }
        public void Sound();
    }

    class Deer : IAnimals
    {
        public string name => "Олень";
        public double weight => 120;

        public void Sound()
        {
            Console.WriteLine("Звуки оленя...");
        }
    }
    class Moose : IAnimals
    {
        public string name => "Лось";
        public double weight => 150;

        public void Sound()
        {
            Console.WriteLine("Звуки лося...");
        }
    }
    class Hog : IAnimals
    {
        public string name => "Кабан";
        public double weight => 90;

        public void Sound()
        {
            Console.WriteLine("Звуки кабана...");
        }
    }
}
