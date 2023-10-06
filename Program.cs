using System;
using System.Collections.Generic;

namespace PatternsOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            BoxForCookies box1 = new Cookies("Ванильное", 20, 2.1);
            Cookies box2 = new Cookies("Ванильное", 20, 2.1);
            BoxForCookies box3 = new BoxForCookies();
            Ibox box4 = new BoxForCookies();

            box2.ReleaseChocolate(); //Код сработает!
            //box1.ReleaseChocolate(); Код не сработает, Инкапсуляция детка!

            // А ВОТ ЭТО РЕФЛЕКСИЯ ДЕТКА! ЕЙ ПОФИГ НА ИНКАПСУЛЦИЮ...
            var type = box1.GetType();
            var releas = type.GetMethod("ReleaseChocolate");
            var result = releas.Invoke(box1, null);


            box3.getItem(); // Тут запускается метод из класса BoxForCookies,
            box1.getItem(); // а тут запускается метод из класса Cookies, Это полиморфизм Детка!

            box3.getClassInfo(); // так можно запустить этот метод,
            // box4.getClassInfo(); а так нельзя потому что в интерфейс реализуемый классом BoxForCookies не входит метод getClassInfo().


            List<Cook> cook = new List<Cook>();
            cook.Add(new FastCook());
            cook.Add(new SlowCook());

            foreach (var item in cook)
            {
                Console.WriteLine($"Тип готовки: {item.cookingType}, Время готовки: {item.cookingTime}");
            }

            //ВЫПОЛНЕНИЕ ФАБРИЧНОГО ПАТТЕРНА
            Console.WriteLine("Выберите густоту населения леса: 1 - много 2 - мало 'животных': ");

            IAnimalsFactories[] factories = new IAnimalsFactories[] { // инициализируем уровни сложности, пользователь будет их выбирать
                new ManyAnimalsForest(),
                new FewAnimalsForest(),
            };

            int index = Convert.ToInt32(Console.ReadLine()) - 1; // -1 потому что нормальные люди всё ещё считают с 1)))

            IAnimals[] animals = new IAnimals[10]; 

            for (int i = 0; i < animals.Length; i++)
            {
                animals[i] = factories[index].Create();
            }

            Forest forest = new Forest(animals);

            forest.GetInfoForAnimals();

        }
    }
}
