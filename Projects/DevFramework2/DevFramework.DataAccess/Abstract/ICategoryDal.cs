using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.Entities.Concrete;

namespace DevFramework.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        
    }
}
