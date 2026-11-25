using System;
using System.Collections.Generic;

namespace OOP4Vardzar
{
    internal class Task1
    {
        public static void Run()
        {
            Console.Write("Скільки покупців? ");
            int count = int.Parse(Console.ReadLine()!);

            Random rnd = new Random();

            Shop shop = new Shop();
            shop.AddProduct(new Product("Хліб", 25, 30));
            shop.AddProduct(new Product("Молоко", 40, 25));
            shop.AddProduct(new Product("Яйця", 60, 20));
            shop.AddProduct(new Product("Яблука", 50, 25));
            shop.AddProduct(new Product("Шоколад", 80, 15));
            shop.AddProduct(new Product("Олія", 90, 10));
            shop.AddProduct(new Product("Сир", 150, 10));
            shop.AddProduct(new Product("Риба", 200, 8));
            shop.AddProduct(new Product("Кава", 250, 8));
            shop.AddProduct(new Product("М'ясо", 300, 6));

            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                int card = rnd.Next(1, 1001);
                int money = rnd.Next(1000, 10001);
                customers.Add(new Customer(card, money));
                Console.WriteLine("Покупець, картка " + card + ", грошей: " + money);
            }

            bool someoneBought = true;
            while (someoneBought)
            {
                someoneBought = false;

                for (int i = 0; i < customers.Count; i++)
                {
                    Product? product = shop.FindRandomAffordable(customers[i], rnd);
                    if (product != null)
                    {
                        shop.Sell(customers[i], product);
                        someoneBought = true;
                    }
                }
            }

            ShopReport report = shop.MakeReport(customers);

            Console.WriteLine();
            Console.WriteLine("Прибуток магазину: " + report.Profit);
            Console.WriteLine("Найбільше товарів купив: картка " + report.TopItemsCard + " (" + report.TopItemsCount + " шт.)");
            Console.WriteLine("Найбільше витратив: картка " + report.TopSpenderCard + " (" + report.TopSpent + " грн)");
        }
    }
}