namespace ForumSystem.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
            "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.cosmo.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
            "~/Kendo/styles/kendo.common.core.min.css",
            "~/Kendo/styles/kendo.common.min.css",
            "~/Kendo/styles/kendo-bootstrap.common.core.min.css",
            "~/Kendo/styles/kendo-bootstrap.common.min.css",
            "~/Kendo/styles/kendo.black.min.css"));

                        // Kendo bundles
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Kendo/kendo.web.min.js",
                        "~/Kendo/kendo.aspnetmvc.min.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
