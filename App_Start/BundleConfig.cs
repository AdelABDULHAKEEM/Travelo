using System.Web;
using System.Web.Optimization;

namespace Travelo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                   "~/Scripts/popper.min.js",
                    "~/Scripts/main.js"
                   ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/main.css",
                      "~/Content/Content.css",
                      "~/Content/box-icons/font-awesome.min.css"));
        }
    }
}
