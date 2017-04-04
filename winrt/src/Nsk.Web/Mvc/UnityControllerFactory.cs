using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace Nsk.Web.Mvc
{
    /// <summary>
    /// Implements a custom factory for web controllers
    /// </summary>
    public class UnityControllerFactory : DefaultControllerFactory 
    {
        private readonly IUnityContainer container;

        public UnityControllerFactory(IUnityContainer container)
        {
            Contract.Requires<ArgumentNullException>(container!=null, "container");
            Contract.Ensures(this.container == container);

            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            Contract.Requires<ArgumentNullException>(requestContext != null, "requestContext");
            Contract.Requires<ArgumentNullException>(controllerType != null, "controllerType");

            return container.Resolve(controllerType) as IController;
        }
    }
}
