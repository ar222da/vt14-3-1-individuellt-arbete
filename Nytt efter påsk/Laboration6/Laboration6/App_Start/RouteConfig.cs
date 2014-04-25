using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Laboration6.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Students", "", "~/Pages/Studenter.aspx");
            routes.MapPageRoute("Furniture", "Möbler", "~/Pages/Möbler.aspx");
            routes.MapPageRoute("Bookings", "Bokningar", "~/Pages/Bookings.aspx");
        }
    }
}