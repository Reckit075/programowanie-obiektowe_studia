using System;

namespace lab_3
{

    // <--------- cw 2 --------->
    public abstract class Person
    {

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string BirthDate { get; init; }
    }
    class Student: Person
    {
        public decimal StudentId { get; init; }
    }
    class Lecturer : Person
    {
        public decimal AcademicDegree {get; init; }
    }

    class StudentLecturerGroup:Person
    {
        public decimal Name { get; init; }
    }

    // <--------- # cw 2 ------------>


    // <--------- cw 1 --------->
    public abstract class Product
    {
        public virtual decimal Price { get; init; }
        public abstract decimal GetVatPrice();
    }

    class Computer: Product
    {
        public decimal Vat { get; init; }

        public override decimal GetVatPrice()
        {
            return Price * Vat / 100m;
        }
    }

    class Paint: Product
    {
        public decimal Vat { get; init; }

        public decimal Capacity { get; init; }
        public decimal PriceUnit { get; init; }

        public override decimal GetVatPrice()
        {
            return PriceUnit * Capacity * Vat / 100m;
        }

        public override decimal Price
        {
            get
            {
                return PriceUnit * Capacity;
            }
        }
    }

    class Butter : Product
    {
        public override decimal GetVatPrice()
        {
            return 2m;
        }
    }

    // <--------- # cw 1 --------->

    // <--------- cw 3 --------->
    interface IFly
    {
        void fly();

    }
    interface ISwim
    {
        void Swim();
    }
    class Duck : ISwim, IFly
    {
        public void fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    class Hydroplane : IFly, ISwim
    {
        public void fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
    // <--------- # cw 3 --------->

    // <--------- cw 4 --------->
    interface IAggregate
    {
        IIterator CreateIterator();
    }

    interface IIterator
    {
        bool HasNext();
        bool GetNext();
    }
    // <--------- # cw 4 --------->

    class Program
    {
        static void Main(string[] args)
        {
            // <--------- uzycie cw 1 --------->
            Product[] shop = new Product[4];
            shop[0] = new Computer() { Price = 2000, Vat = 23};
            shop[1] = new Paint() { PriceUnit = 15, Capacity=5, Vat = 15 };
            shop[2] = new Computer() { Price = 1780, Vat = 23 };
            shop[3] = new Butter();

            decimal sumVat = 0;
            decimal sumPrice = 0;

            foreach (var product in shop)
            {
                sumVat += product.GetVatPrice(); //polimorfizm
                sumPrice += product.Price;

                //starsza wersja testowania czy jest instancja
                if (product is Computer)
                {
                    Computer computer = (Computer)product;
                }

                //nowsza wersja tesotwania czy jest instancja
                Computer computer2 = product as Computer;
                if (computer2 != null)
                {
                    Console.WriteLine("computer price -> " + computer2.Price);
                }
                // wersja bez ifa -> Console.WriteLine(computer2?.Vat);
            }

            Console.WriteLine("sumVat -> " + sumVat);
            Console.WriteLine("sumPrice -> " + sumPrice);

            // <--------- # cw 1 --------->


            // <--------- uzycie cw 3 --------->
            IFly[] flyingObject = new IFly[2];

            Duck duck = new Duck();

            flyingObject[0] = duck;
            flyingObject[1] = new Hydroplane();

            ISwim[] swimmingObject = new ISwim[2];
            swimmingObject[0] = duck;
            // <--------- # cw 3 --------->
        }
    }
}
