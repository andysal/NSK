using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Nsk.Web.Mvc
{
    public class UnityFilterProvider : IFilterProvider 
    {
        private readonly IUnityContainer container;

        public UnityFilterProvider(IUnityContainer container)
        {
            Contract.Requires<ArgumentNullException>(container!=null, "container");
            Contract.Ensures(this.container == container);

            this.container = container;
        }

        #region IFilterProvider Members

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return container.ResolveAll<Filter>(null);
        }

        #endregion
    }
}
