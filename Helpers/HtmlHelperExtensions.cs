using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace Dataway.MvcLibrary.Helpers
{
    public static class HtmlHelperExtensions
    {
		public static string VersionedContent(this UrlHelper url, string fileName)
		{
			FileInfo fileDetails = new FileInfo(HttpContext.Current.Server.MapPath(fileName));

			if (fileName.Contains("?"))
			{
				return string.Format("{0}&v={1}", url.Content(fileName), fileDetails.LastWriteTime.ToString("dd-MM-yyyy-hh-mm-ss"));
			}
			return string.Format("{0}?v={1}", url.Content(fileName), fileDetails.LastWriteTime.ToString("dd-MM-yyyy-hh-mm-ss"));
		}

		public static IHtmlString HighlightSearch(this HtmlHelper helper, string content, string keywords, string highlighClass)
		{
			var words = keywords.Split(' ');

			string newContent = content;

			if (newContent == null)
			{
				newContent = string.Empty;
			}

			foreach (var word in words)
			{
				newContent = Regex.Replace(newContent, word, string.Format("<span class=\"" + highlighClass + "\">{0}</span>", "$0"), RegexOptions.IgnoreCase);
			}

			return helper.Raw(newContent);
		}
    }
}