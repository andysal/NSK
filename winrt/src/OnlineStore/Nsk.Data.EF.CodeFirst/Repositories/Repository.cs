using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Nsk.Domain;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;

namespace Nsk.Data.EF.CodeFirst.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        public Repository()
        {
            this.ActiveContext = new NskEntities();
        }

        //[Dependency]
        public NskEntities ActiveContext { get; private set; }

        private DbSet<T> set = null;

        public DbSet<T> Set
        {
            get
            {
                if (set == null)
                {
                    set = this.ActiveContext.Set<T>();
                }
                return set;
            }
        }

        public void Add(T item)
        {
            this.Set.Add(item);
            this.ActiveContext.SaveChanges();
        }

        public void Remove(T item)
        {
            this.Set.Remove(item);
            this.ActiveContext.SaveChanges();
        }

        public void Update(T item)
        {
            this.ActiveContext.SaveChanges();
        }

        public IQueryable<T> Include(Expression<Func<T, object>> subSelector)
        {
            return this.Set.Include(subSelector);        
        }

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this.Set.AsQueryable().AsEnumerable().GetEnumerator();
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
                return (this.Set.AsQueryable() as IQueryable).ElementType;
            }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get
            {
                return (this.Set.AsQueryable() as IQueryable).Expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return (this.Set.AsQueryable() as IQueryable).Provider;
            }
        }

        #endregion
    }
}
