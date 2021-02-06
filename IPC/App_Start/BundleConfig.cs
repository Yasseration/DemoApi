﻿using System.Web;
using System.Web.Optimization;

namespace IPC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/assets").Include(
                         "~/Scripts/bootstrap.js",
                         "~/Scripts/jquery.unobtrusive-ajax.min.js",
                         "~/Scripts/jquery.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/jquery.dataTables.min.css",
                       "~/Content/all.min.css",
                       "~/Content/Site.css"));
        }
    }
}
