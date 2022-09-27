using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer customer = new Customer()
            //{
            //    id = 1,
            //    ad = "yusuf",
            //    soyad = "unal",
            //    adres = "silivri"
            //};

            //Student student = new Student()
            //{
            //    id = 1,
            //    ad = "ede",
            //    soyad = "yılmaz",
            //    department = "tekstil"
            //};

            //PersonManager personManager = new PersonManager();
            //personManager.add(student);
            //personManager.add(customer);





            CustomerManager customerManager = new CustomerManager();
            customerManager.add(new SqlserverCustomerDal());
            customerManager.update(new OracleCustomerDal());
            customerManager.delete(new SqlserverCustomerDal());


            Console.ReadLine();

        }
    }

    interface IPerson
    {
        int id { get; set; }
        string ad { get; set; }
        string soyad { get; set; }



    }

    class Customer : IPerson
    {
        public int id { get; set; }
        public string ad { get; set; }

        public string soyad { get; set; }
        public string adres { get; set; }
    }

    class Student : IPerson
    {
        public int id { get; set; }
        public string ad { get; set; }

        public string soyad { get; set; }
        public string department { get; set; }
    }

    class PersonManager
    {
        public void add(IPerson person)
        {
            Console.WriteLine(person.ad);
        }


    }




}
