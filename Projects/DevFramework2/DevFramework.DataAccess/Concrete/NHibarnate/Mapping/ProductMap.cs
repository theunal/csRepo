using DevFramework.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.NHibarnate.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            LazyLoad();
            Id(p => p.ProductId).Column("ProductID");

            Map(p => p.ProductName).Column("ProductName");
            Map(p => p.CategoryId).Column("CategoryID");
            Map(p => p.QuantityPerUnit).Column("QuantityPerUnit");
            Map(p => p.UnitPrice).Column("UnitPrice");
        }
    }
}
