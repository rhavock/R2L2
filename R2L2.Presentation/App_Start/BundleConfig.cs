using System.Web;
using System.Web.Optimization;

namespace R2L2.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/material-design-iconic-font.min.css",
                      "~/Content/materialadmin.css",
                      "~/Content/toastr.css",
                      "~/Content/dataTables.colVis.css",
                      "~/Content/dataTables.tableTools.css",
                      "~/Content/jquery.dataTables.css"));

            bundles.Add(new ScriptBundle("~/bundles/R2L2Presentation")
                .IncludeDirectory("~/Scripts/Controllers","*.js")
                .IncludeDirectory("~/Scripts/Factories","*.js")
                .IncludeDirectory("~/Scripts/Services", "*.js")
                .Include("~/Scripts/R2L2Presentation.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .IncludeDirectory("~/Scripts/Angular","*.js"));

            bundles.Add(new ScriptBundle("~/bundles/Material")
                  .IncludeDirectory("~/Scripts/Material", "*.js"));


            BundleTable.EnableOptimizations = true;
        }
    }
}
