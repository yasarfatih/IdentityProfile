using IdentityProfileApp.Utils.AppGlobalization.UICulture;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace IdentityProfileApp.Utils.AppGlobalization.Helper
{
    public class GlobalHelper
    {
        public static string CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
        }
        public static string DefaultCulture
        {
            get
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
                GlobalizationSection section = (GlobalizationSection)config.GetSection("system.web/globalization");
                return section.UICulture;
            }
        }
        public static string GetTextFromResourceCode(string resourceCode)
        {
            if (!string.IsNullOrEmpty(resourceCode))
            {
                if (CultureManager.Instance.ResourceContent.ContainsKey(resourceCode))
                    return CultureManager.Instance.ResourceContent[resourceCode];
                else
                {
                    return "Resource kod hatalı";
                }
            }
            else
            {
                return "Resource kod yok";
            }
        }
    }
}
