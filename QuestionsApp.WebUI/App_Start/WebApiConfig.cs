﻿using System.Web.UI.WebControls;
using System.Web.Http;
using RouteParameter = System.Web.Http.RouteParameter;

namespace QuestionsApp.WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
