using IPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace IPC.Utilities
{
    public static class SecurityUtilities
    {
        
        public static HttpCookie CreateAuthenticationCookie(string name, string id)
        {
            int timeout = 60;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddMinutes(timeout), true, id);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
            {
                Expires = DateTime.Now.AddMinutes(timeout),
                HttpOnly = true
            };
            return cookie;
        }

        public static int GetAuthenticatedUserID()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            return int.Parse(ticket.UserData);
        }

        
    }
}