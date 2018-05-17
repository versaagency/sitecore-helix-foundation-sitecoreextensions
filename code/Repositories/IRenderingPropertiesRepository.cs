using Sitecore.Mvc.Presentation;

namespace Sitecore.Foundation.SitecoreExtensions.Repositories
{
    public interface IRenderingPropertiesRepository
    {
        T Get<T>(Rendering rendering);
    }
}
