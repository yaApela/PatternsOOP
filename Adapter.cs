using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOOP
{
    // ПАТТЕРН АДАПТЕР
    public class FunctionalityClass // класс с нужным для нас функционалом, но менять этот класс мы не можем по тем или иным причинам
    {
        internal void DriveCar()
        {
            Console.WriteLine("Машина едет!");
        }
    }

    interface IAdapter // интерфейс реализуемый новым классом
    {
        public void Drive();
    }

    public class NewClass : FunctionalityClass, IAdapter // класс в который мы хотим запихнуть этот функционал
    {
        public void Drive() // метод реализующий метод интерфейса
        {
            this.DriveCar(); // вызываем в методе метод класса который не можем изменить чтобы подстроить его под интерфейс
        }
    }
}
