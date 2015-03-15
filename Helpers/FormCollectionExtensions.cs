using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Web.SessionState;

namespace Dataway.MvcLibrary.Helpers
{
    public static class FormCollectionExtensions
    {
        #region Public Extension Methods

        public static T Value<T>(this HttpRequestBase request, string key)
        {
            return FormCollectionExtensions.GetValueOrDefault<T>(request[key]);
        }

        public static T Value<T>(this NameValueCollection collection, string key)
        {
            return FormCollectionExtensions.GetValueOrDefault<T>(collection[key]);
        }

        public static bool Contains(this NameValueCollection collection, string key)
        {
            return collection.AllKeys.Contains(key);
        }

        public static T Value<T>(this HttpSessionState session, string key)
        {
            return GetValueOrDefault<T>(session[key]);
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