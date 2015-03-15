using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Dataway.MvcLibrary
{
    public static class CookieManager
    {
        #region Public Static Methods

        public static void Set(string key, object value, DateTime expiration)
        {
            if (value != null)
            {
                HttpCookie cookie = new HttpCookie(key, value.ToString());
                cookie.Expires = expiration;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static string Get(string key)
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(key))
            {
                return HttpContext.Current.Request.Cookies[key].Value;
            }
            return null;
        }

        public static T Get<T>(string key)
        {
            return GetValueOrDefault<T>(Get(key));
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(key))
            {
                HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
            }
        }

        #endregion

        #region Private Static Methods

        private static T GetValueOrDefault<T>(object value)
        {
            Type t = typeof(T);
            t = Nullable.GetUnderlyingType(t) ?? t;

            return (value == null || DBNull.Value.Equals(value) || (!(typeof(T).FullName == "System.String") && (value.ToString() == string.Empty)))
                ? default(T) :
                (T)Convert.ChangeType(value, t);
        }

        #endregion
    }
}
