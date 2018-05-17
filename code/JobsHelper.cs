using Sitecore.Jobs.AsyncUI;

namespace Sitecore.Foundation.SitecoreExtensions
{
    public static class JobsHelper
    {
        public static bool IsPublishing()
        {
            return JobContext.IsJob && JobContext.Job.Category == "publish";
        }
    }
}
