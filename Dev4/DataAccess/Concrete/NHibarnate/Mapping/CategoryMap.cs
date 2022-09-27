using Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.NHibarnate.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            LazyLoad();

            Id(p => p.CategoryId).Column("CategoryID");

            Map(p => p.CategoryName).Column("CategoryName");
        }
    }
}
