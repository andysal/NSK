using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace Nsk.Data.Hibernate
{
    public class SessionPerInstanceStrategy : ISessionManagementStrategy
    {
        private static Configuration cfg;
        private static ISessionFactory sessionFactory;
        private ISession session = null;

        static SessionPerInstanceStrategy()
		{
            cfg = new Configuration();
            cfg.Configure();
            
            sessionFactory = cfg.BuildSessionFactory();
		}

        public ISession GetSession()
        {
            if (session == null)
            {
                session = sessionFactory.OpenSession();
            }
            return session;
        }
    }
}
