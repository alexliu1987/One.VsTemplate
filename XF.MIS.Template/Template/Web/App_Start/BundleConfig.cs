using System.Web;
using System.Web.Optimization;

namespace $safeprojectname$.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/bower_components/jquery/dist/jquery.min.js"));

            //            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            //            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/bower_components/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                   "~/Scripts/jquery.validate.js",
                   "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/ie8").Include(
                   "~/bower_components/respond.min.js",
                   "~/bower_components/html5shiv.js"));

            bundles.Add(new ScriptBundle("~/bundles/metisMenu").Include(
                   "~/bower_components/metisMenu/dist/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/morrisCharts").Include(
                 "~/bower_components/raphael/raphael-min.js",
                 "~/bower_components/morrisjs/morris.min.js",
                 "~/js/morris-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/themeAdmin").Include(
                "~/dist/js/sb-admin-2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/bower_components/metisMenu/dist/metisMenu.min.css",
                      "~/dist/css/sb-admin-2.css",
                      "~/bower_components/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/timeline").Include(
                "~/dist/css/timeline.css"));

            bundles.Add(new StyleBundle("~/Content/morrisCharts").Include(
             "~/bower_components/morrisjs/morris.css"));
        }
    }
}
