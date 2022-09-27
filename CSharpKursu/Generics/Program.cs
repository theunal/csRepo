using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface IRepository<T> where T : class,IEntity, new()
    {
        List<T> GetAll();
        T Get(int id);
        void add(T item);
        void update(T item);
        void delete(T item);


    }
    interface IStudentDal : IRepository<Student>
    {

    }

    interface ICustomerDal : IRepository<Customer1>
    {

    }
    interface IProductDal : IRepository<Product>
    {

    }

    class CustomerDal : ICustomerDal
    {
        public void add(Customer1 item)
        {
            throw new NotImplementedException();
        }

        public void delete(Customer1 item)
        {
            throw new NotImplementedException();
        }

        public Customer1 Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer1> GetAll()
        {
            throw new NotImplementedException();
        }

        public void update(Customer1 item)
        {
            throw new NotImplementedException();
        }
    }
    class ProductDal : IProductDal
    {
        public void add(Product item)
        {
            throw new NotImplementedException();
        }

        public void delete(Product item)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void update(Product item)
        {
            throw new NotImplementedException();
        }
    }

    
    class Product : IEntity
    {

    }

    class Customer1 : IEntity
    {

    }
    class Student : IEntity
    {

    }
    interface IEntity
    {

    }

}
