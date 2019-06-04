using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TAS_Group4_WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DashboardOperator",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "DashboardOperator", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DashboardManager",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "DashboardManager", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DateSelectorOperator",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "DateSelectorOperator", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "WeekSelectorManager",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "WeekSelectorManager", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TruckSearcher",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TruckSearch", action = "Index", id = UrlParameter.Optional }
            );

            // Report

            routes.MapRoute(
                name: "JournalTransaction",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "JournalTransaction", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GeneralLedger",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "GeneralLedger", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "IncomeStatement",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "IncomeStatement", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ReconcilationSheet",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "ReconcilationSheet", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "InventoryStockCard",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Report", action = "InventoryStockCard", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PurchaseOrder",
                url: "{controller}/{action}/{id}/{po}",
                defaults: new { controller = "Report", action = "PurchaseOrder", id = UrlParameter.Optional, po = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Invoice",
                url: "{controller}/{action}/{id}/{iv}",
                defaults: new { controller = "Report", action = "Invoice", id = UrlParameter.Optional, iv = UrlParameter.Optional }
            );

        }
    }
}
