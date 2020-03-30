using System;
using System.Collections.Generic; 



namespace DC
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = 'y';
            string note;

            ProductManager productManager = new ProductManager();

            while (key == 'y')
            {
                Console.WriteLine("Enter? y/n");
                key = Convert.ToChar(Console.ReadLine());

                if (key == 'y')
                {
                    Console.WriteLine("Enter:");
                    note = Console.ReadLine();

                    productManager.AddProduct(note);
                    if (productManager.AddProduct(note))
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
            productManager.SeeDictionary();
            Console.ReadLine();
        }
    }
}
