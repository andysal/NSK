using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Nsk.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Nsk.Web
{
    public class BaseHttpApplication : HttpApplication
    {
        static IUnityContainer container = new UnityContainer();
        
        static BaseHttpApplication()
        {
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);

            #region MVC1 style
            UnityControllerFactory factory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);
            #endregion

            #region MVC3 style
            //container.RegisterInstance<ModelMetadataProvider>(ModelMetadataProviders.Current);
            //container.RegisterInstance<IControllerFactory>(new UnityControllerFactory(container));
            //container.RegisterInstance<IViewPageActivator>(new UnityViewPageActivator(container));
            //container.RegisterInstance<IFilterProvider>(new UnityFilterProvider(container));

            //UnityDependencyResolver resolver = new UnityDependencyResolver(container);
            //DependencyResolver.SetResolver(resolver);
            #endregion
        }
    }
}
