using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibarnate
{
    public abstract class NHibernateHelper : IDisposable
    {
        private static ISessionFactory sessionFactory;


        public virtual ISessionFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = DinamikFactory()); }
        }

        protected abstract ISessionFactory DinamikFactory();
        // burada oracle veya sql server kullanılabilir oldugundan
        // direkt olarak yazamıyoruz bu yüzden protected abstract ile kim kullanacak
        // ise oracle veya sql server için kendi yazsın demiş oluyoruz

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
