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
            //Person person3 = Person.OfName("Mateusz");
            //Money money2 = Money.OfWithException(20, Currency.PLN);
            Money money = Money.OfWithException(10, Currency.PLN);
            //Console.WriteLine(money);
            //if (money > money2)
            {
                Console.WriteLine("moeny 1 wieksze");
            }
            //else
            {
                Console.WriteLine("money2 wieksze");
            }
            Console.WriteLine(money.ToString());

            IEquatable<Money> ie = money;

            Money[] pricies =
            {
                Money.Of(5, Currency.PLN),
            Money.Of(5, Currency.USD),
            Money.Of(2, Currency.EUR),
            Money.Of(4, Currency.PLN),
            Money.Of(15, Currency.PLN),
            Money.Of(15, Currency.PLN),
            Money.Of(145, Currency.USD),
        };
            Console.WriteLine("SORT");
            Array.Sort(pricies);
            foreach (var p in pricies)
            {
                Console.WriteLine(p.ToString());
            }

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
        public override string ToString()
        {
            return $"FirstName: {firstName}";
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

    public enum Currency
    {
        PLN = 1,
        USD = 2,
        EUR = 3
    }
    public class Money : IEquatable<Money>, IComparable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }
        public Currency Currency
        {
            get { return _currency; }
        }
        public decimal Value
        {
            get { return _value; }
        }
        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }
        public static Money? operator *(Money money, decimal factor)
        {
            return Money.Of(money._value * factor, money.Currency);
        }
        public static Money operator *(decimal factor, Money money)
        {
            return Money.Of(money._value * factor, money.Currency);
        }
        public static Money operator +(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return Money.Of(a.Value + b.Value, a.Currency);
        }
        public static bool operator >(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return a.Value > b.Value;
        }
        public static bool operator <(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return a.Value < b.Value;
        }
        private static void IsSameCurrencies(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Different Currences");
            }
        }
        public static Money? OfWithException(decimal value, Currency currency)
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

        public override string ToString()
        {
            return $"Value: {_value} Currency: {_currency}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public bool Equals(Money other)
        {
            return other != null &&
                   _value == other._value &&
                   _currency == other._currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value, _currency);
        }

        public int CompareTo(Money other)
        {
            int curResult = _currency.CompareTo(other._currency);
            if(curResult == 0)
            {
                return _value.CompareTo(other._value);
                //return _value.CompareTo(other._value); => sortowanie malejaco
            }
            else
            {
                return curResult;
            }
        }
    }
}
