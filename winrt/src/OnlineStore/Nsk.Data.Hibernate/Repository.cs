using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;

namespace Nsk.Data.Hibernate
{
    public class Repository<T> : IRepository<T> where T : IAggregateRoot
    {
        private readonly ISessionManagementStrategy sessionManagementStrategy;

        public Repository(ISessionManagementStrategy sessionManagementStrategy)
        {
            this.sessionManagementStrategy = sessionManagementStrategy;
        }

        protected ISessionManagementStrategy SessionManager
        {
            get
            {
                return sessionManagementStrategy;
            }
        }

        #region Implementation of IQueryable

        public Expression Expression
        {
            get { return SessionManager.GetSession().Query<T>().Expression; }
        }

        public Type ElementType
        {
            get { return SessionManager.GetSession().Query<T>().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return SessionManager.GetSession().Query<T>().Provider; }
        }

        #endregion



        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return SessionManager.GetSession().Query<T>().AsEnumerable().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Implementation of IRepository

        public IQueryable<T> Include(Expression<Func<T, object>> subSelector)
        {
            return SessionManager.GetSession().Query<T>().Fetch(subSelector);
        }

        public void Add(T item)
        {
            if (!SessionManager.GetSession().Query<T>().Contains(item))
            {
                SessionManager.GetSession().Save(item);
            }
        }

        public void Remove(T item)
        {
            SessionManager.GetSession().Delete(item);
        }

        public void Update(T item)
        {
            SessionManager.GetSession().Save(item);
        }

        #endregion
    }
}
