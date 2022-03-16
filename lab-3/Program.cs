using System;

namespace lab_3
{
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





    class Program
    {
        static void Main(string[] args)
        {
            Product[] shop = new Product[4];
            shop[0] = new Computer() { Price = 2000, Vat = 23};
            shop[1] = new Paint() { PriceUnit = 15, Capacity=5, Vat = 15 };
            shop[2] = new Computer() { Price = 1780, Vat = 23 };
            shop[3] = new Paint() { PriceUnit = 18, Capacity = 8, Vat = 15 };
        }
    }
}
