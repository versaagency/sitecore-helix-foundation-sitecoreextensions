using System.Web.Mvc;

namespace Sitecore.Foundation.SitecoreExtensions.Helpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString Icon(string iconClass)
        {
            return MvcHtmlString.Create($"<i class=\"icon icon-{iconClass}\"></i>");
        }
    }
}
