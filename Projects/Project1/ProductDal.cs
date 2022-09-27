using Project1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class ProductDal
    {
        public List<Product> getProduct(String key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                return context.Products.Where(p => p.ProductName.Contains(key)).ToList();
                

            }


            
        }
    }
}
