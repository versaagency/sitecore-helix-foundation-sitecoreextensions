using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class DictionaryExtensions
    {
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> dict)
        {
            return dict.Aggregate(new NameValueCollection(), (seed, current) =>
            {
                seed.Add(current.Key, current.Value);
                return seed;
            });
        }
    }
}
