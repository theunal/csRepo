using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[2]
            {
                new Customer{ad = "yusuf"}, new Student{ad = "zeki"}
            };

            foreach (var item in people)
            {
                Console.WriteLine(item.ad);
            }

            Console.ReadLine(  );



        }
    }

    class Person
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        

    }

    class Customer : Person
    {
        public string city { get; set; }
    }
    class Student : Person
    {
        public string department { get; set; }
    }



}

