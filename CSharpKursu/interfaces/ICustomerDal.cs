using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    internal interface ICustomerDal
    {
        void add();
        void update();
        void delete();

    }

    class SqlserverCustomerDal : ICustomerDal
    {
        public void add()
        {
            Console.WriteLine("\n \n \n \tSql server eklendi");
        }

        public void delete()
        {
            Console.WriteLine("\n \n \n \tSql server silindi");
        }

        public void update()
        {
            Console.WriteLine("\n \n \n \tSql server güncellendi");

        }
    }

    class OracleCustomerDal : ICustomerDal
    {
        public void add()
        {
            Console.WriteLine("\n \n \n \tOracle server eklendi");
        }

        public void delete()
        {
            Console.WriteLine("\n \n \n \tOracle server silindi");
        }

        public void update()
        {
            Console.WriteLine("\n \n \n \tOracle server güncellendi");
        }
    }

     class CustomerManager
    {
        public void add(ICustomerDal customerDal)
        {
            customerDal.add();
        }
        public void update(ICustomerDal customerDal)
        {
            customerDal.update();
        }
        public void delete(ICustomerDal customerDal)
        {
            customerDal.delete();
        }
    }


}
