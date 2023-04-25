using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Utils;
using System;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Caching;
using System.Xml.Linq;

namespace IdentityProfileApp.Web.Extensions
{
    public static class ProfilePartsExtension
    {
        public static XDocument getdocument()
        {
            XDocument doc;
            if (HttpContext.Current.Cache["part"] == null)
            {
                var path = System.Web.HttpContext.Current.Server.MapPath("~/StaticFiles/ProfilePart.xml");
                doc = XDocument.Load(path);
                HttpContext.Current.Cache.Insert("part", doc, new CacheDependency(path));
                return doc;
            }
            else
            {
                doc = HttpContext.Current.Cache["part"] as XDocument;
                return doc;
            }
        }
        public static ProfileParts GetOppositePart(this ProfileParts profilePart)
        {

            var doc = getdocument();
            var items = from i in doc.Descendants("part").Where(node => (string)node.Attribute("name") == profilePart.ToString())
                        select new
                        {
                            part = (string)i.Attribute("opposite"),
                        };
            ProfileParts returnValue;
            Enum.TryParse(items.FirstOrDefault().part.ToString(),out returnValue);
            return returnValue;
        }

        public static string GetPartColor(this ProfileParts profilePart)
        {
            var doc = getdocument();

            var items = from i in doc.Descendants("part").Where(node => (string)node.Attribute("name") == profilePart.ToString())
                        select new
                        {
                            color = (string)i.Attribute("color"),
                        };
                        

            //var x = from element in doc.Element("root").Elements("part")
            //        where element.Name == profilePart.ToString()
            //        select element.Attribute("color");
            return items.FirstOrDefault().color.ToString();
        }

    }
}