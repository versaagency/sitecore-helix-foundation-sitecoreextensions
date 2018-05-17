using System;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class SiteExtensions
    {
        public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            var startItem = site.GetStartItem();
            return startItem?.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
        }

        public static Item GetRootItem(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            return site.Database.GetItem(Context.Site.RootPath);
        }

        public static Item GetStartItem(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            return site.Database.GetItem(Context.Site.StartPath);
        }

        public static Web.SiteInfo GetSite(this Item item)
            => Configuration.Factory.GetSiteInfoList()
                .FirstOrDefault(x => item.Paths.FullPath.StartsWith(x.RootPath));
    }
}
