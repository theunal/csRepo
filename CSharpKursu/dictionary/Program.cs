using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string,string> sozluk = new Dictionary<string,string>();
            sozluk.Add("book", "kitap");
            sozluk.Add("table", "masa");
            sozluk.Add("pc", "bilgisayar");

            Console.WriteLine("\t ANAHTAR");
            foreach (var item in sozluk)
            {
           
                Console.WriteLine("\n\n\n\t "+item.Key);

               
            }
            Console.WriteLine("\t\t DEĞER");
            foreach (var item in sozluk)
            {
        

               
                Console.WriteLine("\n\n\n\t\t " + item.Value);
            }

            var count = sozluk.Count;
            Console.WriteLine(count);

           var cont =  sozluk.ContainsKey("table");
            Console.WriteLine(cont);
            Console.ReadLine();


        }
    }
}
