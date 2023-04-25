using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Utils.Extensions
{
    public static class TypeExtensions
    {
        public static string IsImageFormat(this String extension)
        {
            bool isImage = false;
            string[] ImageTypes = new string[] { "JPG", "PNG" };

            for (int i = 0; i < ImageTypes.Length; i++)
            {
                if (ImageTypes[i] == extension.ToUpper())
                {
                    isImage = true;
                }
            }
            if (!isImage)
            {
                return "Other";
            }
            else
            {
                return "Image";
            }
        }
    }
}
