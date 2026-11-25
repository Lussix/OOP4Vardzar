using System;

namespace OOP4Vardzar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Яке завдання запустити? Введіть 1 або 2:");
            int taskNumber = int.Parse(Console.ReadLine()!);

            if (taskNumber == 1)
            {
                Task1.Run();
            }
            else if (taskNumber == 2)
            {
                Console.WriteLine("Тут буде завдання 2");
            }
            else
            {
                Console.WriteLine("Немає такого завдання.");
            }

            Console.ReadLine();
        }
    }
}