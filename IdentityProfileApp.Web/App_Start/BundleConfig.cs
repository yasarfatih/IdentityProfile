using IdentityProfileApp.Web.Extensions;
using System.Web;
using System.Web.Optimization;

namespace IdentityProfileApp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Jquery*
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Content/js/jquery-1.10.2.js")
                .Include("~/Content/js/jquery-1.10.2.min.js"));

            //Bootsrapt*
            bundles.Add(new ScriptBundle("~/bundles/bootsrapt")
               .Include("~/Content/js/bootstrap.js")
               .Include("~/Content/js/respond.js"));
            //css*
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/css/bootstrap.css",
                     "~/Content/css/Site.css"));
            //CKEditor
            bundles.Add(new ScriptBundle("~/Admin/ckEditor")
                .Include("~/Areas/Admin/Content/plugins/ck/ckeditor/ckeditor.js")
                .Include("~/Areas/Admin/Content/plugins/ck/ckfinder/ckfinder.js"));

            //Jconfirm
            bundles.Add(new StyleBundle("~/Admin/jconfirm/css")
                .Include("~/Areas/Admin/Content/plugins/jconfirm/css/jquery-confirm.css"));
            bundles.Add(new ScriptBundle("~/Admin/jconfirm/js")
                .Include("~/Areas/Admin/Content/plugins/jconfirm/js/jquery-confirm.js"));

            //DataTable
            bundles.Add(new StyleBundle("~/Admin/DataTable/css")
                .Include("~/Areas/Admin/Content/plugins/data-table/jquery.dataTables.min.css"));
            bundles.Add(new ScriptBundle("~/Admin/DataTable/js")
                .Include("~/Areas/Admin/Content/plugins/data-table/jquery.dataTables.min.js"));

            //select2
            bundles.Add(new StyleBundle("~/Admin/Select2/css")
                .Include("~/Areas/Admin/Content/select2/select2.min.css"));

            bundles.Add(new ScriptBundle("~/Admin/Select2/js")
                .Include("~/Areas/Admin/Content/select2/select2.min.js"));

            //cropper
            bundles.Add(new StyleBundle("~/Admin/cropper/css")
                .Include("~/Areas/Admin/Content/plugins/cropper/cropper.css"));

            bundles.Add(new ScriptBundle("~/Admin/cropper/js")
                .Include("~/Areas/Admin/Content/plugins/cropper/cropper.js")
                .Include("~/Areas/Admin/Content/plugins/cropper/jquery-cropper.js").CustomOrderer()
                );

            //mask
            bundles.Add(new ScriptBundle("~/Admin/Mask/js")
           .Include("~/Areas/Admin/Content/js/jquery.maskedinput.js"));
            //modernizr*
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/js/modernizr-2.6.2.js"));


            //ValidateInput*
            bundles.Add(new ScriptBundle("~/Validate/js")
           .Include("~/Content/js/jquery.validate.js"));

            //DropZone
            bundles.Add(new ScriptBundle("~/DropZone/js")
                .Include("~/Content/plugins/dropzone/dropzone.js"));
            bundles.Add(new StyleBundle("~/DropZone/css")
           .Include("~/Content/plugins/dropzone/dropzone.css"));
        }
    }
}
