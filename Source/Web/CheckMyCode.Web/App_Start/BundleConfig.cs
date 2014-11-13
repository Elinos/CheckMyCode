using System.Web;
using System.Web.Optimization;

namespace CheckMyCode.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/snippet").Include(
                "~/Scripts/snippet/jquery.snippet.js"));

            bundles.Add(new ScriptBundle("~/bundles/codeMirror").Include(
                "~/Scripts/CodeMirror/codemirror.js",
                "~/Scripts/CodeMirror/mode/javascript/javascript.js",
                "~/Scripts/CodeMirror/addon/selection/active-line.js",
                "~/Scripts/CodeMirror/addon/edit/closebrackets.js",
                "~/Scripts/Custom/CodeMirrorSetup.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive-jquery").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Scripts/Custom/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.spacelab.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/snippet").Include(
                "~/Content/snippet/jquery.snippet.css",
                "~/Content/CodeMirror/codemirror.css",
                "~/Content/CodeMirror/theme/mdn-like.css"));

            bundles.Add(new StyleBundle("~/Content/codeMirror").Include(
                "~/Content/CodeMirror/codemirror.css",
                "~/Content/CodeMirror/theme/mdn-like.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}