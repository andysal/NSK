using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Nsk.Data.Hibernate
{
    class OpenSessionInViewStrategy : ISessionManagementStrategy
    {
        private readonly ISessionFactory sessionFactory;

        public OpenSessionInViewStrategy(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public ISession GetSession()
        {
            return sessionFactory.GetCurrentSession();
        }
    }
}
