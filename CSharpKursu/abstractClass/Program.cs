using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Sqlserver();
            Database database2 = new Oracle();
            database.add();
            database.delete();
            database2.add();
            database2.delete();

            Console.ReadLine();

        }
    }

    abstract class Database
    {
        public void add()
        {
            Console.WriteLine("\n\n\n DEFAULT EKLENDİ");
        }
        public abstract void delete();
        
    }


    class Sqlserver : Database
    {
        public override void delete()
        {
            Console.WriteLine("\n\n\n SQLSERVER SİLİNDİ");
        }
    }

    class Oracle : Database
    {
        public override void delete()
        {
            Console.WriteLine("\n\n\n ORACLE SİLİNDİ");
        }
    }
}
