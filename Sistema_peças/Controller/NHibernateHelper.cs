using System;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace Sistema_peças.Controller
{
    internal class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                var cfg = new Configuration();
                cfg.Configure(); // Lê o arquivo hibernate.cfg.xml
                cfg.AddAssembly(Assembly.GetExecutingAssembly());
                _sessionFactory = cfg.BuildSessionFactory();
            }
            return _sessionFactory;
        }

        public static ISession OpenSession()
        {
            return GetSessionFactory().OpenSession();
        }
    }
}
