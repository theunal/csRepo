using Core.DataAccess.NHibarnate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.NHibarnate.Helper
{
    public class SqlServerHelper : NHibarnateHelper 
    {
        protected override ISessionFactory DinamikFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
            .ConnectionString(p => p.FromConnectionStringWithKey("NorthwindContext")))
            .Mappings(p => p.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
            .BuildSessionFactory();
        }
    }
}
