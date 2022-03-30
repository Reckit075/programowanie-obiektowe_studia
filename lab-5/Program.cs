using System;

namespace lab_4
{

    enum Degree
    {
        BardzoDobry = 50,
        DobryPlus = 45,
        Dobry = 40,
        DostatecznyPlus = 35,
        Dostateczny = 30,
        Niedostateczny = 20
    }

    public record Student(string Name, int Points, string Group);

    class Program
    {
        static void Main(string[] args)
        {
            Degree ocena = Degree.BardzoDobry;
            Console.WriteLine(ocena);
            string[] vs = Enum.GetNames<Degree>();
            Console.WriteLine(string.Join(",",vs));

            Degree[] degrees = Enum.GetValues<Degree>();
            foreach (Degree i in degrees)
            {
                Console.WriteLine($"{i} {(int)i}");
            }



            Console.WriteLine("Wpisz ocene: ");
            string input = Console.ReadLine();
            try
            {
                Degree degree = Enum.Parse<Degree>(input);
                Console.WriteLine($"Wpisałeś {input} o wartości {(int)degree}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("wpisales nieznana ocenę");
            }
            string usDegree;
            switch(ocena)
            {
                case  Degree.BardzoDobry:
                usDegree = "A";
                break;

                case Degree.Dobry:
                usDegree = "B";
                break;
            }
            usDegree = ocena switch
            {
                Degree.BardzoDobry => "A",
                Degree.DobryPlus => "B+",
                Degree.Dobry => "B",
                Degree.DostatecznyPlus => "C+",
                Degree.Dostateczny => "C",
                _ => "F",     //default
            };
            Console.WriteLine(usDegree);



            int points = 57;
            Degree result;
            if(points >= 50 && points< 60)
            {
                result = Degree.Dostateczny;
            }

            result = points switch
            {
                >= 50 and < 60 => Degree.Dostateczny,
                >= 60 and < 70 => Degree.DostatecznyPlus,
                >= 70 and < 80 => Degree.Dobry,
                >= 80 and < 90 => Degree.DobryPlus,
                >= 90 and < 100 => Degree.BardzoDobry,
                _ => Degree.Niedostateczny
            };

            Student[] students =
            {
                new Student(Name:"Mateusz", Points: 14, Group: "G"),
                new Student(Name:"Tomek", Points: 99, Group: "G"),
                new Student(Name:"Jakub", Points: 44, Group: "B"),
                new Student(Name:"Monika", Points: 65, Group: "C"),
                new Student(Name:"Sławomir", Points: 35, Group: "Q"),
            };

            Console.WriteLine(students[1] == new Student("Ewa", 123, "E");

            foreach (Student oneStudent in students)
	        {
                Console.WriteLine(oneStudent);
	        };

            (string, bool)[] results = new (string, bool)[students.Length];
            for (int i = 0; i < students.Length; i++)
			{
                Student st = students[i];
                results[i] = (st.Name,
                    st switch
                    {
                        { Points: >= 100, Group:"E"} => true,
                        { Points: >= 65, Group:"C"} => true,
                        { Points: >= 35, Group:"Q"} => true,
                        _=> false
                    }
                )
			}
            
        }
    }
}
