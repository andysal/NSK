using System.Web.Mvc;

namespace Nsk.OnlineStore.Web.Site.Areas.My
{
    public class MyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "My";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "My_default",
                url: "My/{controller}/{action}/{id}",
                defaults: new { controller="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Nsk.OnlineStore.Web.Site.Areas.My.Controllers" }
            );
        }
    }
}