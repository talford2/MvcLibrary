using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dataway.MvcLibrary.ViewModels;

namespace Dataway.MvcLibrary.Helpers
{
	public static class ErrorHelperExtensions
	{
		public static string ErrorIdFormat
		{
			get
			{
				return "[Property][ErrorType]Error";
			}
		}

		public static IHtmlString ErrorMessage(this HtmlHelper helper, string property, string errorType)
		{
			return ErrorMessage(helper, property, errorType, null);
		}

		public static IHtmlString ErrorMessage(this HtmlHelper helper, string property, string errorType, string message)
		{
			string showStyle = " style=\"display: none;\"";
			string displayMessage = "";

			if (helper.ViewData.Model is IValidationViewModel)
			{
				var model = helper.ViewData.Model as IValidationViewModel;
				if (model.ErrorMessages.Any(i => i.ErrorType == errorType && i.Property == property))
				{
					showStyle = "";
				}

				var errorMessage = model.ErrorMessages.Where(e => e.Property == property && e.ErrorType == errorType).FirstOrDefault();

				if (errorMessage != null && errorMessage.Message != null)
				{
					displayMessage = errorMessage.Message;
				}

				if (message != null)
				{
					displayMessage = message;
					if (errorMessage != null)
					{
						errorMessage.Message = message;
					}
				}
			}

			string id = ErrorIdFormat.Replace("[Property]", property).Replace("[ErrorType]", errorType);

			return new HtmlString(string.Format("<span id=\"{0}\" class=\"error\"{1}>{2}</span>", id, showStyle, displayMessage));
		}
	}
}
