using System;
using System.Collections.Generic;

namespace lab_6
{

    class Student
    {
        public string Name { get; set; }
        public int Ects { get; set; }

            public override bool Equals(object obj){
                return obj is Student student &&
                    Name == student.Name && 
                    Ects == student.Ects;
            }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("ewa");
            names.Add("kuba");
            names.Add("piotr");
            names.Add("piotr");
            names.Add("matek");


            names.Remove("piotr");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(names.Contains("matek"));
            Console.WriteLine(names.Remove("piotr"));

            ICollection<object> students = new List<object>();
            Student matek = new Student() { Name = "Matek", Ects = 15 };
            Student karol = new Student() { Name = "Karol", Ects = 15 };
            students.Add(matek);
            students.Add(karol);

            List<Student> list = (List<Student>)students; //rzutowanie jawne
            Console.WriteLine(list[0]);

            Dictionary<string, object> semiObj = new Dictionary<string, object>();
            semiObj["name"] = "adam";
            semiObj["points"] = 65;
            semiObj["student"] = list[0];
            string[] arr = { "ewa", "adam", "ewa", "karol", "ania", "ewa", "adam" };

            Dictionary<string, int> counters = new Dictionary<string, int>();
            foreach (var item in arr)
            {
                if (counters.ContainsKey(item))
                    counters[item]++;
            }

        }
    }
}
