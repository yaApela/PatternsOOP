using System;
using System.Collections.Generic;

namespace PatternsOOP
{
    // НАСЛЕДОВАНИЕ, ИНКАПСУЛЯЦИЯ, ПОЛИМОРФИЗМ
    class Cookies : BoxForCookies
    {
        string type;
        double weight;
        double price;
        public Cookies(string Type, double Weight, double Price)
        {
            this.type = Type;
            this.weight = Weight;
            this.price = Price;
        }
        public Cookies()
        {
            this.type = "";
            this.weight = 0;
            this.price = 0;
        }
        public void ReleaseChocolate()
        {
            this.type = "Шоколадное";
            this.weight = 20.5;
            this.price = 5.5;
        }
        public override void getItem()
        {
            Console.WriteLine("Тип:" + this.type + " Цена:" + this.price + " Вес:" + this.weight);
        }
    }
    interface Ibox
    {
        void getItem();
    }

    class BoxForCookies : Ibox
    {
        List<Cookies> cookies;
        public BoxForCookies()
        {
            this.cookies = new List<Cookies>();
        }
        public BoxForCookies(List<Cookies> Cookies)
        {
            this.cookies = Cookies;
        }
        public virtual void getItem()
        {
            foreach (var item in cookies)
            {
                Console.WriteLine(item);
            }
        }
        public void getClassInfo()
        {
            Console.WriteLine("Этот класс предназначен для того чтобы в него складывали печеньки ^_^");
        }
    }
    abstract class Cook
    {
        public abstract string cookingType { get; }
        public abstract int cookingTime { get; }
    }

    class FastCook : Cook
    {
        public override string cookingType => "fast";
        public override int cookingTime => 45;
    }

    class SlowCook : Cook
    {
        public override string cookingType => "slow";
        public override int cookingTime => 120;
    }
}
