using System;
using System.Linq;
using System.IO;

namespace ConsoleGame
{
    class Program
    {
        static int playerX;
        static int playerY;
        static int steps;
        static int[,] map;
        static int[] enemies;
        static int[] potions;
        static int[] buffs;

        static void Main(string[] args)
        {
            InitGame();
            while (true)
            {
                DrawMap();
                Console.WriteLine("Введите команду: ");
                string command = Console.ReadLine();

                if (command == "exit")
                {
                    SaveGame();
                    Console.WriteLine("Игра сохранена. Выходим...");
                    break;
                }
                else if (command == "w" || command == "a" || command == "s" || command == "d")
                {
                    MovePlayer(command);
                    UpdateGame();
                }
            }
        }

        private static void UpdateGame()
        {
            throw new NotImplementedException();
        }

        private static void MovePlayer(string command)
        {
            throw new NotImplementedException();
        }

        private static void SaveGame()
        {
            throw new NotImplementedException();
        }

        static void InitGame()
        {
            map = new int[25, 25];
            Random rand = new Random();
            playerX = 12;
            playerY = 12;
            steps = 0;
            enemies = new int[10];
            potions = new int[5];
            buffs = new int[3];

            // Генерация врагов
            for (int i = 0; i < 10; i++)
            {
                int x = rand.Next(0, 25);
                int y = rand.Next(0, 25);
                if (x == playerX && y == playerY)
                {
                    i--;
                    continue;
                }
                if (map[x, y] == 1)
                {
                    i--;
                    continue;
                }
                map[x, y] = 2;
                enemies[i] = x * 100 + y;
            }

            // Генерация аптечек
            for (int i = 0; i < 5; i++)
            {
                int x = rand.Next(0, 25);
                int y = rand.Next(0, 25);
                if (x == playerX && y == playerY)
                {
                    i--;
                    continue;
                }
                if (map[x, y] == 1 || map[x, y] == 2)
                {
                    i--;
                    continue;
                }
                map[x, y] = 3;
                potions[i] = x * 100 + y;
            }

            // Генерация баффов
            for (int i = 0; i < 3; i++)
            {
                int x = rand.Next(0, 25);
                int y = rand.Next(0, 25);
                if (x == playerX && y == playerY)
                {
                    i--;
                    continue;
                }
                if (map[x, y] == 1 || map[x, y] == 2 || map[x, y] == 3)
                {
                    i--;
                    continue;
                }
                map[x, y] = 4;
                buffs[i] = x * 100 + y;
            }
        }

        static void DrawMap()
        {
            Console.Clear();
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (i == playerX && j == playerY)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("P ");
                    }
                    else if (enemies.Contains(i * 100 + j))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("E ");
                    }
                    else if (potions.Contains(i * 100 + j))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("H ");
                    }
                    else if (buffs.Contains(i * 100 + j))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
            }
        }
    }
}