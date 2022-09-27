using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.NHibarnate
{
    public abstract class NHibarnateHelper : IDisposable
    {
        private static ISessionFactory sessionFactory;

        public virtual ISessionFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = DinamikFactory()); }
        }

        protected abstract ISessionFactory DinamikFactory();

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
