using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Nsk.Domain.Model;

namespace Nsk.Domain.Repositories
{
    /// <summary>
    /// Represents a repository of domain objects.
    /// </summary>
    /// <typeparam name="T">The type of elements in the repository</typeparam>
    [ContractClass(typeof(RepositoryContract<>))]
    public interface IRepository<T> : IQueryable<T> where T : IAggregateRoot 
    {
        void Add(T item);

        void Remove(T item);

        /// <summary>
        /// Update the persistent instance with the identifier of the given transient instance
        /// </summary>
        /// <param name="item">An instance containing updated state</param>
        void Update(T item);

    }
}
