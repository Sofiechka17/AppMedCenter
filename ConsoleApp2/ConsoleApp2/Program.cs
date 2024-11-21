using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите пароль:");
        string password = Console.ReadLine();

        // Проверка длины пароля
        if (password.Length < 8)
        {
            Console.WriteLine("Длина пароля должна быть 8 символов или более");
        }
        else
        {
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasSpecialChar = false;
            bool hasDigit = false;

            // Проверка наличия символов верхнего и нижнего регистра, спец символов и цифр
            foreach (char c in password)
            {
                if (Char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (Char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (IsSpecialChar(c))
                {
                    hasSpecialChar = true;
                }
                else if (Char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }

            // Вывод результата проверки
            if (hasUpperCase && hasLowerCase && hasSpecialChar && hasDigit)
            {
                Console.WriteLine("Пароль прошел проверку");
            }
            else
            {
                Console.WriteLine("Пароль не соответствует требованиям");
            }
        }

        Console.ReadLine();
    }

    static bool IsSpecialChar(char c)
    {
        char[] specialChars = { '!', '-', '_', '.' };
        return Array.IndexOf(specialChars, c) != -1;
    }
}