using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{ 
    public class EfQueryableRepository<T> : IQueryableRepository<T> 
        where T : class, IEntity, new()
    {
        private DbContext context;
        private IDbSet<T> entities;

        public EfQueryableRepository(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Table => Entities;

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }
        
    }
}
