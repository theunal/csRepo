using MvcWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class CartModel
    {
        private List<CartLineModel> cartLineModels = new List<CartLineModel>();
        public List<CartLineModel> CartLineModels => cartLineModels;


        public void AddProduct(Product product,int quantity)
        {
            var line = cartLineModels.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (line == null)
            {
                cartLineModels.Add(new CartLineModel() { Product = product,Quantity = quantity});
            }else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            cartLineModels.RemoveAll(p => p.Product.Id == product.Id);
        }

        public void DecreaseProduct(Product product, int quantity)
        {
            var line = cartLineModels.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (line.Quantity == 1)
            {
                DeleteProduct(product);
            }
            else
            {
                line.Quantity -= quantity;
            }
        }

        public decimal Total()
        {
            return cartLineModels.Sum(p => p.Product.Price * p.Quantity);
        }
        public void Clear()
        {
            cartLineModels.Clear();
        }


    }

    public class CartLineModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}