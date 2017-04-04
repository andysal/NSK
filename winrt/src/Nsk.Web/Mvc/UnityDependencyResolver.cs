using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Nsk.Web.Mvc
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            Contract.Requires<ArgumentNullException>(container != null, "container");
            Contract.Ensures(this.container == container);

            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            Contract.Requires<ArgumentNullException>(serviceType != null, "serviceType");

            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            Contract.Requires<ArgumentNullException>(serviceType != null, "serviceType");

            try
            {
                return container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }
    }
}
