﻿using System;

class App
{
    public static void Main(string[] args)
    {

        //zadanie 1
        (int, int) point1 = (2, 4);
        Direction4 dir = Direction4.UP;
        var point2 = Exercise1.NextPoint(dir, point1, (1440, 760));

        Console.WriteLine(point2);

        //zadanie 2
        (int, int) point = (1, 1);
        Direction8 direction = Exercise2.DirectionTo(Exercise2.screen, point, 1);
        Console.WriteLine(direction);
    }
}

enum Direction8
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    UP_LEFT,
    DOWN_LEFT,
    UP_RIGHT,
    DOWN_RIGHT
}

enum Direction4
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

//Cwiczenie 1   X
//Zdefiniuj metodę NextPoint, która powinna zwracać krotkę ze współrzędnymi piksela przesuniętego jednostkowo w danym kierunku względem piksela point.
//Krotka screenSize zawiera rozmiary ekranu (width, height)
//Przyjmij, że początek układu współrzednych (0,0) jest w lewym górnym rogu ekranu, a prawy dolny ma współrzęne (witdh, height) 
//Pzzykład
//dla danych wejściowych 
//(int, int) point1 = (2, 4);
//Direction4 dir = Direction4.UP;
//var point2 = NextPoint(dir, point1);
//w point2 powinny być wartości (2, 3);
//Jeśli nowe położenie jest poza ekranem to metoda powinna zwrócić krotkę z point

class Exercise1
{
    public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
    {
        int x = point.Item1;
        int y = point.Item2;

        int screenHeight = screenSize.Item2;
        int screenWidth = screenSize.Item1;

        switch (direction)
        {
            case Direction4.UP:
                y--;
                break;
            case Direction4.RIGHT:
                x++;
                break;
            case Direction4.DOWN:
                y++;
                break;
            case Direction4.LEFT:
                x--;
                break;
        }
        if (y < 0 || y >= screenHeight || x < 0 || x >= screenWidth )
        {
            return point;
        }
        return (x, y);
    }
}
//Cwiczenie 2   X
//Zdefiniuj metodę DirectionTo, która zwraca kierunek do piksela o wartości value z punktu point. W tablicy screen są wartości
//pikseli. Początek układu współrzędnych (0,0) to lewy górny róg, więc punkt o współrzęnych (1,1) jest powyżej punktu (1,2) 
//Przykład
// Dla danych weejsciowych
// static int[,] screen =
// {
//    {1, 0, 0},
//    {0, 0, 0},
//    {0, 0, 0}
// };
// (int, int) point = (1, 1);
// po wywołaniu - Direction8 direction = DirectionTo(screen, point, 1);
// w direction powinna znaleźć się stała UP_LEFT

class Exercise2
{
    public static int[,] screen =
    {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

    private static (int, int) point = (1, 1);
    
    private Direction8 direction = DirectionTo(screen, point, 1);
    
    public static Direction8 DirectionTo(int[,] screen, (int, int) point,  int value)
    {
        int x = point.Item1;
        int y = point.Item2;

        int coordsX = 0;
        int coordsY = 0;

        for (int i = 0; i < screen.GetLength(0); i++)
        {
            for (int j = 0; j < screen.GetLength(1); j++)
            {
                if (screen[i, j] == value)
                {
                    coordsX = i;
                    coordsY = j;
                }
            }
        }
        if (coordsX < x)
        {
            if (coordsY >= y)
            {
                return Direction8.DOWN_LEFT;
            }
            else
            {
                return Direction8.UP_LEFT;
            }
        }
        else
        {
            if (coordsY >= y)
            {
                return Direction8.DOWN_RIGHT;
            }
            else
            {
                return Direction8.UP_RIGHT;
            }
        }
    }
}

//Cwiczenie 3
//Zdefiniuj metodę obliczającą liczbę najczęściej występujących aut w tablicy cars
//Przykład
//dla danych wejściowych
// Car[] _cars = new Car[]
// {
//     new Car(),
//     new Car(Model: "Fiat", true),
//     new Car(),
//     new Car(Power: 100),
//     new Car(Model: "Fiat", true),
//     new Car(Power: 125),
//     new Car()
// };
//wywołanie CarCounter(Car[] cars) powinno zwrócić 3
record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);

class Exercise3
{
    public static int CarCounter(Car[] cars)
    {
        return 0;
    }
}

record Student(string LastName, string FirstName, char Group, string StudentId = "");
//Cwiczenie 4
//Zdefiniuj metodę AssignStudentId, która każdemu studentowi nadaje pole StudentId wg wzoru znak_grupy-trzycyfrowy-numer.
//Przykład
//dla danych wejściowych
//Student[] students = {
//  new Student("Kowal","Adam", 'A'),
//  new Student("Nowak","Ewa", 'A')
//};
//po wywołaniu metody AssignStudentId(students);
//w tablicy students otrzymamy:
// Kowal Adam 'A' - 'A001'
// Nowal Ewa 'A'  - 'A002'
//Należy przyjąc, że są tylko trzy możliwe grupy: A, B i C
class Exercise4
{
    public static void AssignStudentId(Student[] students)
    {
        
    }
}