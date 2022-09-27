using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtualMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Database sql = new Sqlserver();
            Database oracle = new Oracle();
            sql.add();
            oracle.add();
            Console.ReadLine();

        }
    }


    class Database //baba
    {
        public virtual void add()
        {
            Console.WriteLine("eklendi");
        }
        public virtual void delete()
        {
            Console.WriteLine("silindi");
        }
    }

    class Sqlserver : Database // evlat 1
    {
        public override void add()
        {
            base.add();
            Console.WriteLine("sql eklendi");
            
        }
    }
    class Oracle : Database //evlat 2
    {

    }


}
