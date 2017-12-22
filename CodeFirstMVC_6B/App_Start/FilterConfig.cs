using System.Web;
using System.Web.Mvc;

namespace CodeFirstMVC_6B
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
