using IdentityProfileApp.Utils.Extensions;
using MimeDetective;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Web;

namespace IdentityProfileApp.Web.StaticClasses
{
    public class UploadOperations
    {
        public static Tuple<string, string> UploadImage(HttpPostedFileBase file, NameValueCollection form, string path, string fileName)
        {

            string fileType = file.InputStream.GetFileType().ToString().IsImageFormat();
            if (fileType != "Image")
            {
                string error = "Yüklemiş olduğunuz dosya bir resim formatı değildir lütfen doğru bir dosya seçiniz";
                return Tuple.Create(error, fileName);
            }
            else
            {
                Image croppedImage = file.CropImage(form);
                string newFileName = fileName.GenerateFileName();
                string filePath = HttpContext.Current.Server.MapPath(string.Format("~{0}Image/{1}", path, newFileName));
                croppedImage.Save(filePath);

                string thumbFilePath = HttpContext.Current.Server.MapPath(string.Format("~{0}thumb/{1}", path, newFileName));
                Image thumpFile = croppedImage.GetThumbnailImage(105, 70);
                thumpFile.Save(thumbFilePath);

                return Tuple.Create("", newFileName);

            }
        }

    }

}