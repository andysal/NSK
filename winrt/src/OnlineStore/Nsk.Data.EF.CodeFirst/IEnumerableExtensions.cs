using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagedDesigns.Nsk.Data.EF.CodeFirst
{
    public static class EnumerableExtensions
    {
        public static ICollection<T> GetCollection<T>(this IEnumerable<T> data)
        {
            ICollection<T> internalColl = Activator.CreateInstance<ICollection<T>>();

            foreach (T value in data)
            {
                //if (predicate(value)) yield return value;
                internalColl.Add(value);
            }

            return internalColl;
        }
    }
}
