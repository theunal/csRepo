using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{

    public delegate void StokControl();
    public class Product
    {
        private int _stok;

        public Product(int stok)
        {
            _stok = stok;
        }

        public event StokControl StokControlEvent;
        public string Name { get; set; }
        public int Stok { get { return _stok; }
            

            set { 
                _stok = value;
                if (value <= 15 && StokControlEvent != null)
                    {
                    StokControlEvent();
                    }
            } 
}

        public void Sell(int amount)
        {
            Stok -= amount;
            Console.WriteLine(Name+" stok: "+_stok);
         
        }
    }




















}
