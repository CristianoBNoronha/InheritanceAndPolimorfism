using System;
using System.Collections.Generic;
using ExercicioHerançaEPolimorfismo1.Entities;
using System.Globalization;

namespace ExercicioHerançaEPolimorfismo1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.WriteLine("Common, used or imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Product product = new Product(name, price);
                if (ch == 'c')
                {
                    list.Add(product);
                }
                if (ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Product usedProduct = new UsedProduct(name, price, date);
                    list.Add(usedProduct);
                }
                if (ch == 'i')
                {
                    Console.WriteLine("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Product importedProduct = new ImportedProduct(name, price, customsFee);
                    list.Add(importedProduct);
                }            
               
            }
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product p in list)
            {
                Console.WriteLine(p.PriceTag());
            }

        }
    }
}
