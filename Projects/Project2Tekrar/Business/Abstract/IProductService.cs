﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetProductsByCategory(int CategoryID);
        List<Product> GetProductsByProductName(string text);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
