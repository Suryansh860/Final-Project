using System.Web;
using System.Web.Mvc;

namespace Emp_Travel_Booking_Sys
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
