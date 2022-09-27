using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibarnate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T>
        where T : class, IEntity, new()
    {
        private NHibernateHelper helper;
        private IQueryable<T> entities;

        public NhQueryableRepository(NHibernateHelper helper)
        {
            this.helper = helper;
        }
        public IQueryable<T> Table => Entities;

        public virtual IQueryable<T> Entities

        {
            get { return entities ?? (entities = helper.OpenSession().Query<T>()); }
        }
    }

    
}
