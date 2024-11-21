using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount(1000);
            acc1.AccountNotify += DisplayMessage;

            acc1.Put(1000);
            acc1.Take(100);
            acc1.Take(100000);
        }
        public static void DisplayMessage(string text) =>
            Console.WriteLine(text);
    }
}