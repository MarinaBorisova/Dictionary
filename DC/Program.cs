using System;
using System.Collections.Generic;
namespace DC
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> some_dictionary = new Dictionary<string, string>();
            var key = 'y';
            string note, item, value;

            while (key == 'y')
            {
                Console.WriteLine("Enter? y/n");
                key = Convert.ToChar(Console.ReadLine());

                if (key == 'y')
                {
                    Console.WriteLine("Enter:");
                    note = Console.ReadLine();

                    item = note.Substring(0, note.IndexOf(' '));
                    value = note.Substring(note.IndexOf(' ') + 1);

                    if (some_dictionary.ContainsKey(item) || some_dictionary.ContainsValue(value))
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        Console.WriteLine("Success");
                        some_dictionary.Add(item, value);
                    }
                }
                else
                {
                    break;
                }
            }
          
            foreach (KeyValuePair<string, string> pair in some_dictionary)
            {
                Console.WriteLine($" {pair.Key} - {pair.Value}");
            }
            Console.ReadLine();
        }
    }
}
