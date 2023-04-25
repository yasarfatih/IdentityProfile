using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Utils.AppGlobalization.Helper;
using IdentityProfileApp.Utils.AppGlobalization.UICulture;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace IdentityProfileApp.Web.BLL
{
    public class UICultureBLL
    {
        //Tüm dil listesini döndürüyoruz.
        public static List<Language> LanguageLists()
        {
            List<Language> languages = null;
            using (IdentityProfileAppContext entities = new IdentityProfileAppContext())
            {
                languages = entities.Language.ToList();
            }
            return languages;
        }

        //Seçili kültüre uygun dile ait içerikleri döndürdüğümüz metod.
        public static Language GetLanguageResources(string resourceCode)
        {
            //buraya dile ait resource kodu gelmektedir. Örneğin ingilizce için en-US gibi            
            using (IdentityProfileAppContext entities = new IdentityProfileAppContext())
            {
                var languageWithDefinitions = entities.Language.Include(x => x.LanguageDefinitions).FirstOrDefault(la => la.ResourceCode == resourceCode);
                if (languageWithDefinitions != null)
                {
                    return languageWithDefinitions;
                }
                else
                {
                    return null;
                }
            }
        }

        //Seçilen dili uyguladığımız kısım
        public static void SetLanguageFromCode(string resourceCode)
        {
            if (string.IsNullOrEmpty(resourceCode))
                resourceCode = GlobalHelper.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(resourceCode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(resourceCode);
        }

        public static void SetResourcesFromCode(string resourceCode)
        {
            Dictionary<string, string> cultureResourceDic = new Dictionary<string, string>();
            Language languageWithResources = GetLanguageResources(resourceCode);
            if (languageWithResources.LanguageDefinitions.Count > 0)
            {
                cultureResourceDic = languageWithResources.LanguageDefinitions.Select(x => new KeyValuePair<string, string>(x.ResourceNo, x.Body))
                               .ToDictionary(t => t.Key, t => t.Value);
            }
            CultureManager.Instance.SetCultureResources(cultureResourceDic);
        }
    }
}