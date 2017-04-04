using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;

namespace Nsk.Domain.Repositories
{
    /// <summary>
    /// Defines the code contract for IRepository&lt;T&gt;
    /// </summary>
    /// <typeparam name="T">The type of the elements managed by the repository</typeparam>
    [ContractClassFor(typeof(IRepository<>))] 
    internal sealed class RepositoryContract<T> : IRepository<T> where T : IAggregateRoot
    {
        public void Add(T item)
        {
            Contract.Requires<ArgumentNullException>(item != null, "item");
            Contract.Requires<ArgumentException>(item.CanBeSaved);
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            Contract.Requires<ArgumentNullException>(item != null, "item");
            Contract.Requires<ArgumentException>(item.CanBeDeleted);
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            Contract.Requires<ArgumentNullException>(item != null, "item");
            Contract.Requires<ArgumentException>(item.CanBeSaved);
            throw new NotImplementedException();
        }

        #region IEnumerable members

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRepository members

        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<T> Include(System.Linq.Expressions.Expression<Func<T, object>> subSelector)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
