using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class RenderingParameterExtensions
    {
        public static string ToJson(this RenderingParameters renderingParameters)
        {
            if (renderingParameters is IEnumerable<KeyValuePair<string, string>> keyValues)
            {
                var renderingParams = new JObject();
                foreach (var keyValue in keyValues)
                {
                    renderingParams.Add(keyValue.Key, keyValue.Value);
                }

                return JsonConvert.SerializeObject(renderingParams);
            }

            return string.Empty;
        }
    }
}
