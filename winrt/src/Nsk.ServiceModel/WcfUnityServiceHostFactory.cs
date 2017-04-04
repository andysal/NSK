using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.ServiceModel.Activation;

namespace Nsk.ServiceModel
{
    public class WcfUnityServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);

            return new WcfUnityServiceHost(container, serviceType, baseAddresses);
        }
    }
}