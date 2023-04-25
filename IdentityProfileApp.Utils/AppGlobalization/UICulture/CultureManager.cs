using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Utils.AppGlobalization.UICulture
{
    public class CultureManager
    {
        private class SingletonHelper
        {
            static SingletonHelper() { }
            static internal CultureManager instance = new CultureManager();
        }

        public static CultureManager Instance { get { return SingletonHelper.instance; } }

        //Aşağıdaki metod yardımıyla dile ait resource tanımları buraya gönderilecek
        //Böylece artık kontrollerimiz bu resource tanımlarını kullanacaktır.
        public void SetCultureResources(Dictionary<string, string> cultureContent)
        {
            ResourceContent = cultureContent;
        }

        //Tüm resource dosyası içeriği bu property yardımıyla elde edilebilecektir.
        public Dictionary<string, string> ResourceContent { get; private set; } = null;
    }
}
