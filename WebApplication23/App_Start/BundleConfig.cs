using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplication23.App_Start
{
    public class BundleConfig
    {
        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/bundles/js")
                    .Include("~/Scripts/bootstrap.min.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/jquery-{version}.js")
                    .IncludeDirectory("~/Scripts", "*.js"));
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/bootstrap.css",
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/full-slider.css",
                "~/Content/MyStyle.css"
                )
                .IncludeDirectory("~/Content", "*.css"));
        }
    }
}