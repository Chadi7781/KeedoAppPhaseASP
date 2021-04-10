using System.Web;
using System.Web.Optimization;

namespace KeedoApp
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {




            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                       "~/FrontEnd/assets/libs/jquery/jquery.min.js",
                      "~/FrontEnd/assets/libs/bootstrap/js/bootstrap.bundle.min.js",
                      "~/FrontEnd/assets/libs/metismenu/metisMenu.min.js",
                      "~/FrontEnd/assets/libs/simplebar/simplebar.min.js",
                      "~/FrontEnd/assets/libs/node-waves/waves.min.js",
                      "~/FrontEnd/assets/libs/waypoints/lib/jquery.waypoints.min.js",
                      "~/FrontEnd/assets/libs/jquery.counterup/jquery.counterup.min.js",
                      "~/FrontEnd/assets/libs/apexcharts/apexcharts.min.js",
                      "~/FrontEnd/assets/js/pages/dashboard.init.js",
                      "~/FrontEnd/assets/js/app.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/site.css",
            "~/FrontEnd/assets/css/bootstrap.min.css",
            "~/Frontend/assets/css/app-dark.min.css",
            "~/Frontend/assets/css/app-rtl.min.css",
            "~/Frontend/assets/css/icons.min.css",
            "~/FrontEnd/assets/css/app.min.css",
            "~/FrontEnd/assets/css/line.css"
            ));
        }
    }
}
