using DevFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(p => p.ProductId);

            Property(p => p.ProductId).HasColumnName("ProductID");
            Property(p => p.ProductName).HasColumnName("ProductName");
            Property(p => p.CategoryId).HasColumnName("CategoryId");
            Property(p => p.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(p => p.UnitPrice).HasColumnName("UnitPrice");

        }
    }
}
