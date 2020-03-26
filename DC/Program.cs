using System;
using System.Collections.Generic;
namespace DC
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> some_dictionary = new Dictionary<string, string>();
          
            Console.WriteLine("Enter 1 note");
            string mess1 = Console.ReadLine();

            Console.WriteLine("Enter 2 note");
            string mess2 = Console.ReadLine();
           
            Console.WriteLine("Enter 3 note");
            string mess3 = Console.ReadLine();
           
            Console.WriteLine("Enter 4 note");
            string mess4 = Console.ReadLine();
          
            Console.WriteLine("Enter 5 note");
            string mess5 = Console.ReadLine();
            
            some_dictionary.Add(mess1.Substring(0, mess1.IndexOf(' ')), mess1.Substring(mess1.IndexOf(' ') + 1));
            some_dictionary.Add(mess2.Substring(0, mess2.IndexOf(' ')), mess2.Substring(mess2.IndexOf(' ') + 1));
            some_dictionary.Add(mess3.Substring(0, mess3.IndexOf(' ')), mess3.Substring(mess3.IndexOf(' ') + 1));
            some_dictionary.Add(mess4.Substring(0, mess4.IndexOf(' ')), mess4.Substring(mess4.IndexOf(' ') + 1));
            some_dictionary.Add(mess5.Substring(0, mess5.IndexOf(' ')), mess5.Substring(mess5.IndexOf(' ') + 1));

            foreach (KeyValuePair<string, string> pair in some_dictionary)
            {
                Console.WriteLine($" {pair.Key} - {pair.Value}");
            }
            Console.ReadLine();
        }
    }
}
