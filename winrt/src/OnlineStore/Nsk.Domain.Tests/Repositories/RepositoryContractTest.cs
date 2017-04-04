using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;

namespace Nsk.Domain.Tests.Repositories
{
    [TestClass]
    public class RepositoryContractTest
    {
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Repository_cannot_Add_objects_not_valid_for_storing()
        {
            FakeEntityObject item = new FakeEntityObject();
            FakeRepository repo = new FakeRepository();
            //var mock = new Mock<IRepository<FakeEntityObject>>();
            //var repo = mock.Object;
            repo.Add(item);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Repository_cannot_Add_null_objects()
        {
            FakeRepository repo = new FakeRepository();
            repo.Add(null);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Repository_cannot_Remove_objects_not_valid_for_deletion()
        {
            FakeEntityObject item = new FakeEntityObject();
            FakeRepository repo = new FakeRepository();
            repo.Remove(item);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Repository_cannot_Remove_null_objects()
        {
            FakeRepository repo = new FakeRepository();
            repo.Remove(null);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Repository_cannot_Save_objects_not_valid_for_storing()
        {
            FakeEntityObject item = new FakeEntityObject();
            FakeRepository repo = new FakeRepository();
            repo.Update(item);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Repository_cannot_Save_null_objects()
        {
            FakeRepository repo = new FakeRepository();
            repo.Update(null);
        }

        class FakeEntityObject : IAggregateRoot
        {
            bool IAggregateRoot.CanBeDeleted
            {
                get
                {
                    return false;
                }
            }

            bool IAggregateRoot.CanBeSaved
            {
                get
                {
                    return false;
                }
            }
        }

        class FakeRepository : IRepository<FakeEntityObject>
        {
            public IQueryable<FakeEntityObject> Include(System.Linq.Expressions.Expression<Func<FakeEntityObject, object>> subSelector)
            {
                throw new NotImplementedException();
            }

            public void Update(FakeEntityObject item)
            {
                throw new NotImplementedException();
            }

            public void Add(FakeEntityObject item)
            {
                throw new NotImplementedException();
            }

            public void Remove(FakeEntityObject item)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<FakeEntityObject> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

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
        }
    }
}
