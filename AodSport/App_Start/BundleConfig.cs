using System.Web;
using System.Web.Optimization;

namespace AodSport
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/common").Include(
                        "~/Scripts/common.js",
                        "~/assets/custom/js/Custom.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/jquery.twbsPagination.js",
                      "~/assets/custom/js/jquery-easyui/jquery.easyui.min.js",
                      "~/assets/custom/js/ScrollBar/jquery.mCustomScrollbar.js",
                      "~/assets/custom/js/jquery.cookie.js",
                      "~/assets/vendor/sweetalert/sweetalert.min.js",
                      "~/assets/bundles/chartist.bundle.js",
                      "~/Scripts/jquery.blockUI.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/toastr.css",
                      "~/assets/vendor/sweetalert/sweetalert.css",
                      "~/Content/PagedList.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/theme").Include(
                      "~/assets/vendor/font-awesome/css/font-awesome.min.css",
                      "~/assets/custom/font/font.css",
                      "~/assets/custom/js/ScrollBar/jquery.mCustomScrollbar.css",
                      "~/assets/custom/js/jquery-easyui/themes/bootstrap/tree.css",
                      "~/assets/custom/js/jquery-easyui/themes/icon.css",
                      "~/assets/vendor/chartist/css/chartist.min.css",
                      "~/assets/css/main.css",
                      "~/assets/css/color_skins.css",
                      "~/assets/custom/css/display.css",
                      "~/assets/custom/css/Common.css",
                      "~/assets/custom/css/css_rwd.css"));

            bundles.Add(new ScriptBundle("~/Scripts/theme").Include(
                        "~/assets/bundles/libscripts.bundle.js",
                        "~/assets/bundles/vendorscripts.bundle.js"));

            bundles.Add(new StyleBundle("~/Css/Form").Include(
                     "~/assets/vendor/parsleyjs/css/parsley.css",
                     "~/assets/vendor/bootstrap-multiselect/bootstrap-multiselect.css",
                     "~/assets/vendor/bootstrap-datepicker/css/bootstrap-datepicker3.min.css",
                     "~/assets/vendor/multi-select/css/multi-select.css",
                     "~/assets/custom/js/select2/select2-bootstrap.css",
                     "~/assets/custom/js/select2/select2.css"
                     ));

            bundles.Add(new ScriptBundle("~/Scripts/Form").Include(
                        "~/assets/vendor/parsleyjs/js/parsley.js",
                        "~/assets/vendor/parsleyjs/js/vi.js",
                        "~/assets/vendor/multi-select/js/jquery.multi-select.js",
                        "~/assets/vendor/bootstrap-multiselect/bootstrap-multiselect.js",
                        "~/assets/vendor/bootstrap-datepicker/js/bootstrap-datepicker.min.js",
                        "~/assets/vendor/bootstrap-datepicker/js/bootstrap-datepicker.vi.js",
                        "~/assets/vendor/jquery.maskedinput/jquery.maskedinput.min.js",
                        "~/assets/vendor/jquery-inputmask/jquery.inputmask.bundle.js",
                        "~/assets/js/pages/forms/advanced-form-elements.js",
                        "~/assets/custom/js/select2/select2.min.js",
                        "~/assets/custom/js/jquery.quicksearch.js",
                        "~/assets/custom/js/ckeditor/ckeditor.js",
                        "~/assets/custom/js/ckfinder/ckfinder.js",
                        "~/assets/custom/js/ckfinder/config.js"
                        ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
