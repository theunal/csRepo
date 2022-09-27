using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{

    public delegate void MyDelegate();
    public delegate void MyDelegate2(String text);
    public delegate int MyDelegate3(int num1,int num2);

    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            Matematik matematik = new Matematik();

            //MyDelegate myDelegate = customerManager.hello;
            //myDelegate += customerManager.alert;
            //myDelegate += customerManager.alert;
            //myDelegate += customerManager.alert;
            //myDelegate();

            MyDelegate2 myDelegate2 = customerManager.hello2;
            myDelegate2 += customerManager.alert2;
            myDelegate2 += customerManager.alert2;
            myDelegate2("orospu cocugu");

            //MyDelegate3 myDelegate3 = matematik.carp;
            //myDelegate3 += matematik.topla;
            //var sonuc = myDelegate3(2, 3);
            //Console.WriteLine(sonuc);



            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        public void hello()
        {
            Console.WriteLine("hello");
        }
        public void alert()
        {
            Console.WriteLine("be careful");
        }

        public void hello2(String text)
        {
            Console.WriteLine(text);
        }
        public void alert2(String text)
        {
            Console.WriteLine(text);
        }


       

    }
    public class Matematik
    {
        public int topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }


}
