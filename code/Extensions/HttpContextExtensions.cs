using System.Linq;
using System.Web;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetClientIPAddress(this HttpContext context)
        {
            var ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                var addresses = ipAddress.Split(',');
                if (addresses.Any())
                {
                    return addresses.First();
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
