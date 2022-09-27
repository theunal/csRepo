using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.NHibarnate
{
    public class NhEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private NHibarnateHelper helper;

        public NhEntityRepositoryBase(NHibarnateHelper helper)
        {
            this.helper = helper;
        }


        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = helper.OpenSession())
            {
                return filter == null ?
                    session.Query<TEntity>().ToList() :
                    session.Query<TEntity>().Where(filter).ToList();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = helper.OpenSession())
            {
                return session.Query<TEntity>().FirstOrDefault(filter);
            }
        }






        public TEntity Add(TEntity entity)
        {
            using (var session = helper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }
        public TEntity Update(TEntity entity)
        {
            using (var session = helper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }
        public void Delete(TEntity entity)
        {
            using (var session = helper.OpenSession())
            {
                session.Delete(entity);
            }
        }

    }
}
