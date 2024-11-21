namespace ConsoleApp42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<bool[]> cinemaHall1 = new List<bool[]>() { new bool[] { true, true }, new bool[] { true, false, true }, new bool[] { true, true } };
            List<bool[]> cinemaHall2 = new List<bool[]>() { new bool[] { true, false }, new bool[] { true, true, true } };
            List<bool[]> cinemaHall3 = new List<bool[]>() { new bool[] { false, false }, new bool[] { false, true, false } };

            List<List<bool[]>> cinema = new List<List<bool[]>>() { cinemaHall1, cinemaHall2, cinemaHall3 };

            Console.WriteLine("Введите номер зала: ");
            string cinemaHallNumber = Console.ReadLine();
            int cinemaHallIndex = int.Parse(cinemaHallNumber) - 1;

            List<bool[]> cinemaHall = cinema[cinemaHallIndex];

            for (int rowIndex = 0; rowIndex < cinemaHall.Count; rowIndex++)
            {
                bool[] row = cinemaHall[rowIndex];

                for (int seatIndex = 0; seatIndex < row.Length; seatIndex++)
                {
                    bool seat = row[seatIndex];

                    if (seat == false)
                    {
                        Console.Write("СВОБОДНО" + " ");
                    }
                    else
                    {
                        Console.Write("ЗАНЯТО" + " ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Введите ряд: ");
            string userRowNumber = Console.ReadLine();
            int userRowIndex = Convert.ToInt32(userRowNumber) - 1;

            Console.WriteLine("Введите место: ");
            string userSeatNumber = Console.ReadLine();
            int userSeatIndex = Convert.ToInt32(userSeatNumber) - 1;

            bool[] userRow = cinemaHall[userRowIndex];

            bool userSeat = userRow[userSeatIndex];

            Console.WriteLine(userSeat);

            if (userSeat == false)
            {
                List<bool[]> cinemaHall = true;
                //Console.Write("СВОБОДНО" + " ");
                Console.WriteLine(userSeat);

            }
            //else
            //{
            //    Console.Write("ЗАНЯТО" + " ");
            //}

        }
    }
    
}
