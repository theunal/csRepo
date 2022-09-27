using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; } // fiyat
        public Int16 UnitsInStock { get; set; } // stok miktarı
        public string QuantityPerUnit { get; set; } //örnek kola kutusunda 6 tane kola var


    }
}
