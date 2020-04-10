using System;
using DC.Core;
using DC.SQLServices;
using Microsoft.Extensions.Configuration;

namespace DC
{
    class Program
    {
        static void Main(string[] args)
        {        
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connecitonString = config.GetConnectionString("Database");
            ProductManager productManager = new ProductManager(new ProductRepository(connecitonString));

            Execute(productManager);           
        }

        private static void Execute(ProductManager productManager)
        {
            var key = 'y';

            while (key == 'y')
            {
                Console.WriteLine("Enter? y/n");
                key = Convert.ToChar(Console.ReadLine());

                if (key == 'y')
                {
                    Console.WriteLine("Enter:");
                    var note = Console.ReadLine();

                    var product1 = new Product(note.Substring(0, note.IndexOf(' ')), note.Substring(note.IndexOf(' ') + 1));

                    if (productManager.AddProduct(product1))
                    {
                        Console.WriteLine("Sucсess");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                else
                {
                    break;
                }
            }

            var products = productManager.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} - {product.NameProduct}");
            }

            Console.WriteLine("Enter product ID:");
            string item = Console.ReadLine();

            var product2 = productManager.GetProduct(item);

            Console.WriteLine($"Your product: {product2?.Id} - {product2?.NameProduct}");


            Console.ReadLine();
        }
    }
}
