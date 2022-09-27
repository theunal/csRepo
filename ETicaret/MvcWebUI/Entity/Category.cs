using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }

       
        [DisplayName("Kategori Adı:")]
        public string CategoryName { get; set; }

        [DisplayName("Kategori Açıklaması:")]
        public string Description { get; set; }



        public List<Product> Products { get; set; }

    }
}