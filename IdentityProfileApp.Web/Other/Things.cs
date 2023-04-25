using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace IdentityProfileApp.Web.Other
{
    public static class Things
    {
        public static FormsAuthenticationTicket CreateTicket(string name, int expirationDay, bool rememberMe)
        {
            return new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddDays(expirationDay), rememberMe, "", FormsAuthentication.FormsCookiePath);
        }
        public static HttpCookie CreateCookie(FormsAuthenticationTicket ticket)
        {
            var hash = FormsAuthentication.Encrypt(ticket);
            return new HttpCookie(FormsAuthentication.FormsCookieName, hash);
        }
    }
}