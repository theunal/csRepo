using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attritubes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerDal customerDal = new CustomerDal();
            customerDal.add(new Customer
            {
                id = 7, name = "yusuf", lastname = "unal", age = 22
            });
            Console.ReadLine();
        }
        
    }

    class Customer
    {
        public int id { get; set; }
        [RequiredProperty]
        public string name { get; set; }
        [RequiredProperty]
        public string lastname { get; set; }
        [RequiredProperty]
        public int age { get; set; }
    }


      class CustomerDal
    {
        public void add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3}",customer.id,customer.lastname ,customer.name, customer.age);
        }
    }

    class RequiredPropertyAttribute: Attribute
    {

    }

}


