using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;
using Nsk.Data.EF.Poco.Model;
using System.Reflection;


namespace Nsk.Data.EF.Poco.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IAggregateRoot
    {
        public Repository()
        {
            ActiveContext = new NskContext();
        }

        protected abstract void AddObject(T item);
        protected abstract void DeleteObject(T item);
        protected abstract ObjectQuery<T> GetObjectQuery();

        internal NskContext ActiveContext { get; set; }

        internal ObjectQuery<T> ObjectQuery
        {
            get
            {
                return this.GetObjectQuery();
            }
        }

        public void Add(T item)
        {
            this.AddObject(item);
            this.ActiveContext.SaveChanges();
        }

        public void Remove(T item)
        {
            this.DeleteObject(item);
            this.ActiveContext.SaveChanges();
        }

        public void Update(T item)
        {
            this.ActiveContext.SaveChanges();
        }

        public IQueryable<T> Include(Expression<Func<T, object>> subSelector)
        {
            return (this.ObjectQuery as ObjectQuery<T>).Include(((subSelector.Body as MemberExpression).Member as PropertyInfo).Name);
        }

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this.ObjectQuery.AsEnumerable().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of IQueryable

        public Type ElementType
        {
            get
            {
                return (this.ObjectQuery as IQueryable).ElementType;
            }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get
            {
                return (this.ObjectQuery as IQueryable).Expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return (this.ObjectQuery as IQueryable).Provider;
            }
        }

        #endregion
    }
}
