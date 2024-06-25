using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteBanTraiCay
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "detail Order",
               url: "trackings/{id}",
               defaults: new { controller = "TrackOrder", action = "DetailOrder", id = UrlParameter.Optional }
               );

            routes.MapRoute(
              name: "theodoi",
              url: "tracking",
              defaults: new { controller = "TrackOrder", action = "Index", id = UrlParameter.Optional }
              );
            routes.MapRoute(
                name: "reset mật khẩu",
                url: "resetpassword",
                defaults: new { controller = "Account", action = "ResetPassword", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "tìm lại mật khẩu",
                url: "forgotpassword",
                defaults: new { controller = "Account", action = "ForgotPassword", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "danh sách cửa hàng gần bạn",
                url: "list-shop-longti",
                defaults: new { controller = "Recommend", action = "GetAddress", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "danh sách cửa hàng",
                url: "list-shop",
                defaults: new { controller = "Recommend", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AllProducts",
                url: "product",
                defaults: new { controller = "Site", action = "Product", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "AllProductsById",
              url: "product/{id}",
              defaults: new { controller = "Site", action = "ProductById", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "AllPosts",
               url: "post",
               defaults: new { controller = "Site", action = "Post", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Gio hang",
               url: "cart",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Thanh toán!",
               url: "checkout",
               defaults: new { controller = "Cart", action = "Checkout", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Search",
               url: "search",
               defaults: new { controller = "Site", action = "Search", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Contact",
              url: "contact",
              defaults: new { controller = "Site", action = "Contact", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "SiteSlug",
                url: "{slug}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Recommend",
               url: "gioi-thieu/{longTi}/{lat}",
               defaults: new { controller = "Recommend", action = "GetAddress", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
