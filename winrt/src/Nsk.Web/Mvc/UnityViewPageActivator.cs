using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Nsk.Web.Mvc
{
    class UnityViewPageActivator : IViewPageActivator
    {
        private IUnityContainer container;

        public UnityViewPageActivator(IUnityContainer container)
        {
            Contract.Requires<ArgumentNullException>(container != null, "container");
            Contract.Ensures(this.container == container);

            this.container = container;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            Contract.Requires<ArgumentNullException>(controllerContext != null, "controllerContext");
            Contract.Requires<ArgumentNullException>(type != null, "type");

            return container.Resolve(type);
        }
    }
}
