using System;
using System.Globalization;
using System.Collections.Generic;
using Order2.Entities;

namespace Order2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            List<Product> products = new List<Product>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (C / U / I)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (type == 'C')
                {
                    products.Add(new Product(name, price));
                }
                else if (type == 'I')
                {
                    Console.Write("Customs fee: ");
                    double customs = double.Parse(Console.ReadLine());

                    products.Add(new ImportedProduct(name, price, customs));
                }
                else if (type == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    products.Add(new UsedProduct(name, price, date));
                }
            }

            Console.WriteLine();

            Console.WriteLine("PRICE TAGS:");

            foreach (Product item in products)
            {
                Console.WriteLine(item.PriceTag());
            }
        }
    }
}
