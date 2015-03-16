using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dataway.MvcLibrary.Helpers
{
	public static class StringHelperExtensions
	{
		#region String Extensions

		public static string Truncate(this string stringObj, int characterLimit)
		{
			if (stringObj == null || stringObj.Length <= characterLimit)
			{
				return stringObj;
			}

			int endIndex = 0;
			for (int i = characterLimit; i > 0; i--)
			{
				if (stringObj[i] == ' ')
				{
					endIndex = i;
					break;
				}
			}

			if (endIndex == 0)
			{
				if (stringObj.Length > characterLimit)
				{
					endIndex = characterLimit;
				}
			}

			return string.Format("{0}...", stringObj.Substring(0, endIndex));
		}

		public static string ToTitleCase(this string stringObj)
		{
			string newString = stringObj;
			newString = stringObj.ToLower();

			var bits = newString.Split(' ');

			string rebuiltString = "";
			for (int i = 0; i < bits.Length; i++)
			{
				rebuiltString += string.Format("{0}{1} ", bits[i][0].ToString().ToUpper(), bits[i].Substring(1));
			}

			return rebuiltString.TrimEnd();
		}

		public static string Slugify(this string stringObj)
		{
			if (!string.IsNullOrWhiteSpace(stringObj))
			{
				string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXWZ1234567890 -";

				string slugified = stringObj.ToLower().Trim().Replace("  ", " ").Replace("/", "-").Replace(" - ", "-").Replace(' ', '-').Replace("--", "-").Replace("&", "and").Replace("%", "percent");

				foreach (var character in slugified)
				{
					if (!validCharacters.Contains(character))
					{
						slugified = slugified.Replace(character + "", "");
					}
				}

				return slugified;
			}
			return stringObj;
		}

		#endregion
	}
}
