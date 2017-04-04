using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace Nsk.Web.Mvc
{
    class UnityControllerActivator : IControllerActivator
    {
        private readonly IUnityContainer container;

        public UnityControllerActivator(IUnityContainer container)
        {
            Contract.Requires<ArgumentNullException>(container!=null, "container");
            Contract.Ensures(this.container == container);

            this.container = container;
        }

        #region IControllerActivator Members

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            Contract.Requires<ArgumentNullException>(requestContext != null, "requestContext");
            Contract.Requires<ArgumentNullException>(controllerType != null, "controllerType");

            return container.Resolve(controllerType) as IController;
        }

        #endregion
    }
}
