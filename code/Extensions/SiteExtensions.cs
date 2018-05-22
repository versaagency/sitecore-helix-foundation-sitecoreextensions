using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class SiteExtensions
    {
        static readonly IEnumerable<string> _sitecoreSites = new[] { "shell", "login", "admin", "service", "modules_shell", "modules_website" };

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
                .Where(ent => !_sitecoreSites.Contains(ent.Name))
                .Where(ent => !string.IsNullOrEmpty(ent.RootPath))
                .FirstOrDefault(x => item.Paths.FullPath.StartsWith(x.RootPath));
    }
}
