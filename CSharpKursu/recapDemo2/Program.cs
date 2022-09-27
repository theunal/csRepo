using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recapDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.logger = new FileLogger();
            customerManager.add();

            Console.ReadLine();
        }
    }


    class CustomerManager
    {
        public ILogger logger;
        public void add()
        {
            logger.log();
            Console.WriteLine("\n\n\n Müşteri eklendi!");
        }
    }

    interface ILogger
    {
        void log();
        
    }

    class DatabaseLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("\n\n\n DATABASE LOGLANDI");
        }
    }

    class FileLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("\n\n\n FİLE LOGLANDI");
        }
    }

    class SmsLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("\n\n\n SMS LOGLANDI");
        }
    }
}
