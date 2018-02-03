using Savory.Web;
using System.Web;
using System.Web.Mvc;

namespace Savory.TransformPortal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleExceptionAttribute());
        }
    }
}
