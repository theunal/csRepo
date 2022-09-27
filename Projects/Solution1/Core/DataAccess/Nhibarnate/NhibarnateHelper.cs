using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Nhibarnate
{
    public abstract class NhibarnateHelper : IDisposable
    {
        private static ISessionFactory sessionFactory;

        public virtual ISessionFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = DinamikFactory()); }
        }

        protected abstract ISessionFactory DinamikFactory();

        public virtual ISession OpenSession()
        {
            return DinamikFactory().OpenSession();
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
