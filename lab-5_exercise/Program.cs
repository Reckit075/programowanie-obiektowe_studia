using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_5_exercise
{
    //Cwiczenie 1 (2 punkty)
    //Zmodyfikuj klasę Exercise1 aby implementowała interfesj IEnumerable<T>
    //Zdefiniuj metodę GetEnumerator, aby zwracał kolejno pola Manager, MemberA, MemberB
    //Przykład
    //Exercise1<string> team = new Exercise1(){ Manager: "Adam", MemberA: "Ola", MemberB: "Ewa"};
    //foreach(var member in team){
    //    Console.WriteLine(member);
    //}
    //otrzymamy na ekranie
    //Adam
    //Ola
    //Ewa
    public class Exercise1<T> : IEnumerable<T>
    {
        public T Manager { get; init; }
        public T MemberA { get; init; }
        public T MemberB { get; init; }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Manager;
            yield return MemberA;
            yield return MemberB;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //Cwiczenie 2 (2 punkty)
    //Zdefiniuj indekser dla klasy CurrencyRates, aby umożliwiał przypisania i pobierania notowania dla danej waluty.
    //Zainicjuj tablice _rates, aby jej rozmiar byl równy liczbie stałych wyliczeniowych w klasie Currency i nie wymagał zmiany
    //gdy zostaną dodane następne stałe.
    //Przykład
    //CurrencyRates rates = new CurrencyRates();
    //rates[Currency.EUR] = 4.6m;
    //Console.WriteLine(rates[Currency.EUR]);

    enum Currency
    {
        PLN,
        USD,
        EUR,
        CHF
    }

    class CurrencyRates
    {
        //utwórz tablicę o rozmiarze równym liczbie stalych wyliczeniowych Currency
        private decimal[] _rates = new decimal[Enum.GetValues<Currency>().Length];

        public decimal this[Currency currency]
        {
            get
            {
                return _rates[(int)currency];
            }
            set
            {
                _rates[(int)currency] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // test zadania 1
             Exercise1<string> team = new Exercise1<string>()
             {
                 Manager = "Adam",
                 MemberA = "Ola",
                 MemberB = "Ewa"
             };

            // test zadania 2
            CurrencyRates rates = new CurrencyRates();
            rates[Currency.EUR] = 4.6m; 
            Console.WriteLine(rates[Currency.EUR]);
        }
    }
}
