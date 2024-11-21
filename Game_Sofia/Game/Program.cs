using System;

namespace PZ_17
{
    internal class Program
    {
        class ф
        {
            static string[,] map = new string[26, 26];
            static int personX = 12;
            static int personY = 12;

            static string person = "P";
            static string enemy = "E"; // враги
            static string empty = ".";
            static string borders = "()";

            static int counter = 0;

            private static void Main(string[] args)
            {
                Interface();
                GenerateMap();
                Move();
                UpdateMap();
            }
            public static void GenerateMap()
            {

                map[personY, personX] = person;
                CreateObject();
                UpdateMap();
            }

            public static void CreateObject()
            {
                Random random = new Random();
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (i == 0 && j < map.GetLength(1) || i < map.GetLength(1) && j == 0 || i == map.GetLength(1) - 1 && j < map.GetLength(1) || i < map.GetLength(0) && j == map.GetLength(1) - 1)
                        {
                            map[i, j] = borders;
                        }
                    }
                }
                for (int i = 0; i <= 10; i++)
                {
                    if (map[random.Next(25), random.Next(25)] != person && map[random.Next(25), random.Next(25)] != borders)
                    {
                        map[random.Next(25), random.Next(25)] = enemy;
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (map[random.Next(25), random.Next(25)] != enemy && map[random.Next(25), random.Next(25)] != person && map[random.Next(25), random.Next(25)] != borders)
                    {
                        map[random.Next(25), random.Next(25)] = medicine;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (map[random.Next(25), random.Next(25)] != enemy && map[random.Next(25), random.Next(25)] != borders && map[random.Next(25), random.Next(25)] != person && map[random.Next(25), random.Next(25)] != medicine)
                    {
                        map[random.Next(25), random.Next(25)] = buff;
                    }
                }
            }
            public static void UpdateGame()
            {
                Console.Clear();
                map[personY, personX] = person;
                Interface();
                UpdateMap();
                Move();
            }
            public static void UpdateMap()
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == borders)
                        {
                            Console.Write(map[i, j]);
                        }
                        else if (map[i, j] == person)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(map[i, j] + " ");
                            Console.ResetColor();
                        }
                        else if (map[i, j] == enemy)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j] + " ");
                            Console.ResetColor();
                        }
                        else if (map[i, j] == medicine)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j] + " ");
                            Console.ResetColor();
                        }
                        else if (map[i, j] == buff)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(map[i, j] + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            map[i, j] = empty;
                            Console.Write(map[i, j] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }

            public static void Move()
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        int lastY = personY;
                        if (map[personY, personX] == borders)
                        {
                            map[lastY, personX] = borders;
                            map[personY, personX] = person;
                        }
                        else
                        {
                            map[personY--, personX] = person;
                            counter++;
                            Fight();
                            map[lastY, personX] = empty;
                            Healing();
                            Buff();
                        }
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        int lastX = personX;
                        if (map[personY, personX] == borders)
                        {
                            map[personY, personX] = borders;
                            map[personY, personX++] = person;
                        }
                        else
                        {
                            map[personY, personX--] = person;
                            counter++;
                            Fight();
                            map[personY, lastX] = empty;
                            Healing();
                            Buff();
                        }

                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:

                        lastX = personX;
                        map[personY, personX++] = person;
                        counter++;
                        Fight();
                        map[personY, lastX] = empty;
                        Healing();
                        Buff();
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        lastY = personY;
                        map[personY++, personX] = person;
                        counter++;
                        Fight();
                        map[lastY, personX] = empty;
                        Healing();
                        Buff();
                        break;
                    default:
                        break;
                }
                if (bBool)
                {
                    buffSteps++;
                }
                if (buffSteps == 6)
                {
                    bBool = false;
                    powerPerson = 5;
                    buffSteps = 0;
                }
                UpdateGame();
            }


            static int fragCount = 0;
            public static void Fight()
            {
                if (map[personY, personX] == enemy)
                {
                    hpEnemy = 15;

                    while (hpPerson != 0 && hpEnemy != 0)
                    {
                        Console.Clear();
                        Interface();
                        UpdateMap();
                        if (hpPerson > 0)
                        {
                            if (hpEnemy == 5)
                            {
                                hpEnemy -= 5;
                            }
                            else hpEnemy -= powerPerson;
                            System.Threading.Thread.Sleep(1000);
                        }
                        Interface();
                        UpdateMap();
                        if (hpEnemy > 0)
                        {

                            hpPerson -= powerEnemy;
                            System.Threading.Thread.Sleep(1000);
                        }
                        else if (hpEnemy == 0)
                        {
                            fragCount++;
                        }
                    }
                }

            }



            static string medicine = "H";
            static int medicineCount = 0;
            public static void Healing()
            {
                if (map[personY, personX] == medicine)
                {
                    if (hpPerson + 10 <= 30)
                    {
                        hpPerson += 10;
                    }
                    else if (hpPerson + 5 == 30)
                    {
                        hpPerson += 5;
                    }
                }
            }



            static string buff = "b";
            static bool bBool = false;
            static byte buffSteps = 0;

            public static void Buff()
            {
                if (map[personY, personX] == buff)
                {
                    bBool = true;
                    if (powerPerson == 5)
                    {
                        powerPerson += 5;
                    }
                    else
                    {
                        buffSteps = 0;
                    }
                }
            }

            public static void SaveState()
            {

            }

            static int hpPerson = 30;
            static byte powerPerson = 5;


            static int hpEnemy = 0;
            static byte powerEnemy = 5;

            public static void Interface()
            {
                Console.WriteLine($"Кол-во шагов: {counter}");

                if (hpEnemy == 0)
                {
                    Console.WriteLine($"HP: {hpPerson}");
                }
                else
                {
                    Console.WriteLine($"HP: {hpPerson}\t HP ENEMY: {hpEnemy}");
                }
                Console.WriteLine($"DAMAGE: {powerPerson}");
            }

        }
    }
}