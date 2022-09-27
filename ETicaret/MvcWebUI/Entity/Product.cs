using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class Product
    {
        public int Id { get; set; } 

        [DisplayName("Ürün Adı:")]
        public string Name { get; set; }

        [DisplayName("Ürün Açıklaması:")]
        public string Description { get; set; }

        [DisplayName("Ürün Fiyatı:")]
        public decimal Price { get; set; }

        [DisplayName("Ürün Stok Adet:")]
        public int Stock { get; set; }

        [DisplayName("Onaylı mı?")]
        public bool IsApproved { get; set; }

        [DisplayName("Anasayfada mı?")]
        public bool IsHome { get; set; }

        [DisplayName("Resim:")]
        public string image { get; set; }



        [DisplayName("Ürün Kategori:")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        


       
    
    }
}