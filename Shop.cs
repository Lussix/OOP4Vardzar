using System;
using System.Collections.Generic;

namespace OOP4Vardzar
{
    internal class Shop
    {
        public int Profit { get; private set; }
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product? FindRandomAffordable(Customer customer, Random rnd)
        {
            List<Product> available = new List<Product>();

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Quantity > 0 && customer.CanAfford(products[i]))
                {
                    available.Add(products[i]);
                }
            }

            if (available.Count == 0)
            {
                return null;
            }

            return available[rnd.Next(available.Count)];
        }

        public void Sell(Customer customer, Product product)
        {
            product.Quantity--;
            customer.Pay(product);
            Profit = Profit + product.Price;
        }

        public ShopReport MakeReport(List<Customer> customers)
        {
            ShopReport report = new ShopReport();
            report.Profit = Profit;

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].ItemsBought > report.TopItemsCount)
                {
                    report.TopItemsCount = customers[i].ItemsBought;
                    report.TopItemsCard = customers[i].CardNumber;
                }

                if (customers[i].MoneySpent > report.TopSpent)
                {
                    report.TopSpent = customers[i].MoneySpent;
                    report.TopSpenderCard = customers[i].CardNumber;
                }
            }

            return report;
        }
    }
}