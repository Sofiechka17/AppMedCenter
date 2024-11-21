using System;
using System.Collections.Generic;

namespace slovar
{
     class Program
    {
        static void Main(string[] args)
        {
            var tutor = new Program();
            tutor.AddWord("hello", "привет");
            tutor.AddWord("dog", "собака");
            tutor.AddWord("cat", "кошка");
            
            while (true)
            {
                var word = tutor.GetRandomEngWord();

            }

            if (tutor.CheckWord("dog", "собака")) ;
            {

            }
        }
    }
}
