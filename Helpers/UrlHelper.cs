using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Dataway.MvcLibrary.Helpers
{
    public static class UrlHelper
    {
        public static string WebsiteUrl
        {
            get
            {
                return string.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host);
            }
        }

        public static string Combine(string path, params string[] paths)
        {
            string outval = path.TrimEnd('/').Replace("\\", "/");
            foreach (var addedPath in paths)
            {
                outval += "/" + addedPath.TrimEnd('/').Replace("\\", "/");
            }
            return outval;
        }

        public static string CombineUrl(string path, params string[] paths)
        {
            string outval = path.TrimEnd('/').Replace("\\", "/");
            foreach (var addedPath in paths)
            {
                outval += "/" + addedPath.TrimEnd('/').Replace("\\", "/");
            }
            return outval;
        }

        public static string GetFullUrl(string relativeUrl)
        {
            if (string.IsNullOrWhiteSpace(relativeUrl))
            {
                return string.Format("{0}/{1}", WebsiteUrl, relativeUrl.TrimStart('/'));
            }
            return WebsiteUrl;
        }

        public static string GetRelativeUrl(string fullUrl)
        {
            if (!string.IsNullOrWhiteSpace(fullUrl))
            {
                return fullUrl.TrimStart(WebsiteUrl.ToCharArray());
            }
            return null;
        }
    }
}
