using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace Nsk.ServiceModel
{
    public class WcfUnityServiceHost : ServiceHost
    {
        private IUnityContainer unityContainer;
     
        public WcfUnityServiceHost(IUnityContainer unityContainer, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.unityContainer = unityContainer;
        }
     
        protected override void OnOpening()
        {
            base.OnOpening();
     
            if (this.Description.Behaviors.Find<WcfUnityServiceBehavior>() == null)
            {
                this.Description.Behaviors.Add(new WcfUnityServiceBehavior(this.unityContainer));
            }
        }
    }
}