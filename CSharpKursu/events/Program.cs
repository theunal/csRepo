using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
     class Program
    {
        static void Main(string[] args)
        {
            Product hdd = new Product(50);
            hdd.Name = "TOSHIBA 2.5\" HDD";

            Product cpu = new Product(50);
            cpu.Name = "AMD CPU";
            cpu.StokControlEvent += Cpu_stokControlEvent;


            for (int i = 0; i < 5; i++)
            {
                hdd.Sell(10);
                cpu.Sell(10);

                Console.ReadLine();

            }
            Console.ReadLine();


        }

        private static void Cpu_stokControlEvent()
        {
            Console.WriteLine("Gsm about to finished!");
        }

        
    }
}
