using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(p => p.CategoryId);

            Property(p => p.CategoryId).HasColumnName("CategoryID");
            Property(p => p.CategoryName).HasColumnName("CategoryName");
        }
    }
}
