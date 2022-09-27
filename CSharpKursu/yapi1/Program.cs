using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yapi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager("mesaj 1");
            personManager.add();

            Console.ReadLine();
        }
    }


    class BaseClass
    {
        string message1;
        public BaseClass(string messeage1)
        {
            this.message1 = messeage1;

        }
        public void message()
        {
            Console.WriteLine("mesaj: {0}",this.message1);
        }

    }


    class PersonManager : BaseClass
    {
        public PersonManager(string messeage1) : base(messeage1)
        {

        }
        public void add()
        {
            Console.WriteLine("\n\n\n EKLENDİ");
            message();
        }
    }
}
