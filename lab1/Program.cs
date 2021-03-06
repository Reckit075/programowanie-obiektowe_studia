using System;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person { FirstName = "aaaa" };
            //Person person2 = new Person();
            //Console.WriteLine(person2 == null ? "NULL" : "OBJECT");
            Person person3 = Person.OfName("Mateusz");
            Money money = Money.OfWithException(10, Money.Currency.PLN);
            Console.WriteLine(money);
        }
    }
    public class Person
    {
        private string firstName;

        Person(string _firstName)
        {
            firstName = _firstName;
        }
        private Person() { }

        public static Person OfName(string name)
        {
            if (name != null && name.Length >= 2)
            {
                return new Person(name);
            }
            else
            {
                throw new ArgumentOutOfRangeException("za krotkie imie");
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != null && value.Length >= 2)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("za krotkie imie");
                }
            }
        }
    }

    public class Money
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }
        public static Money operator*(Money money, decimal factor)
        {
            return Money.Of(money._value * factor, money.Currency);
        }
        public static Money operator *(decimal factor, Money money)
        {
            return Money.Of(money._value * factor, money.Currency);
        }
        public static Money operator +(Money a, Money b)
        {
            if(a.Currency != b.Currency)
            {
                throw new ArgumentException("Different Currences");
            }
            return Money.Of(a.Value + b.Value, a.Currency);
        }
        public static bool operator >(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Different Currences");
            }
            return a.Value > b.Value;
        }
        public static bool operator <(Money a, Money b)
        {
            IsSameCurrencies();
            return a.Value < b.Value;
        }

        private static void IsSameCurrencies()
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Different Currences");
            }
        }

        public static Money OfWithException(decimal value, Currency currency)
        {
            Money money = Of(value, currency); //tutaj domyslnie jest Money -> Money.Of
            if (money != null)
            {
                return money;
            }
            else
            {
                throw new ArgumentOutOfRangeException("niepoprawna wartosc");
            }
        }
        public decimal Value
        {
            get { return _value; }
        }
        public enum Currency
        {
            PLN = 1,
            USD = 2,
            EUR = 3
        }
    }
}
