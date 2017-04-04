using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace Nsk.ServiceModel
{
    public class WcfUnityInstanceProvider : IInstanceProvider
    {
        private readonly IUnityContainer container;
        private readonly Type _serviceType;
     
        public WcfUnityInstanceProvider(IUnityContainer container, Type serviceType)
        {
            this.container = container;
            _serviceType = serviceType;
        }
     
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }
     
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return container.Resolve(_serviceType);
        }
     
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            container.Teardown(instance);
        }
    }
}