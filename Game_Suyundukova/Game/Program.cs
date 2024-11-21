using System.Runtime.CompilerServices;

namespace Game                               // _ пустая клетка P-персонаж E-враг Н-аптечка В-усиление(?)
{
    internal class Program
    {
       static int mapSize = 25;
        static char [,] map = new char[mapSize];
        static int playerY = mapSize / 2; // строки
        static int playerX = mapSize / 2;
        static byte enemies = 5;
        static byte Buff = 5;
        static int Healing = 5;

        enum Direction ( Left, Right, Up, Down )
        static void Main(string[] args)
        {
            GenerationMap();
            Move;
        }

        static void GenerationMap()
        {
            Random random = new Random();
            for(int i = 0; i < mapSize; i++) 
            { 
              for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }

            }
            //map[playerX, playerY]
            int x;
            int y;
            while(enemies > 0) 
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x,y] = 'E'
                        enemies--;
                }
            }
            while (Buf > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B'
                        Buf--;
                }
            }
            while (Buf > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B'
                        Buf--;
                }
            }
            while (Healing > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H'
                        Healing--;
                }
            }

            // код для расстановки баффов и аптечек 

            for (int i = 0;i < mapSize; i++)
            {
                for (int j = 0;j < mapSize; j++)
                {
                    Console.WriteLine(map[i,j]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
        static void Move()
    {
        while (true)
        {

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    playerY--;
                    break;
                    ///khduyucedy

            }
        }
    }
    static void UpdateMap()
    {
        Console.Clear
        for (int i = 0; i< mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
        }
    }
}