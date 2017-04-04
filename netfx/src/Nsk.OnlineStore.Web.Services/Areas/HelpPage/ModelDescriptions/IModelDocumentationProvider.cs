using System;
using System.Reflection;

namespace Nsk.OnlineStore.Web.Services.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}