using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dataway.MvcLibrary.ViewModels
{
	public interface IValidationViewModel
	{
		List<ErrorMessage> ErrorMessages { get; }

		bool HasBeenValidated { get; }

		//void ValidationProcess();

		bool Validate();
	}

	//public abstract class ValidationViewModel
	//{
	//    #region Constructors

	//    public ValidationViewModel()
	//    {
	//        this.ErrorMessages = new List<ErrorMessage>();
	//    }

	//    #endregion

	//    #region Public Properties

	//    public List<ErrorMessage> ErrorMessages { get; set; }

	//    public bool HasBeenValidated { get; private set; }

	//    public bool IsValid
	//    {
	//        get
	//        {
	//            return this.ErrorMessages.Count == 0;
	//        }
	//    }

	//    #endregion

	//    #region Public Methods

	//    public void ShowErrorMessage(ErrorMessage errorMessage)
	//    {
	//        this.ErrorMessages.Add(errorMessage);
	//    }

	//    public void ShowErrorMessage(string property, string errorType, string message)
	//    {
	//        this.ShowErrorMessage(new ErrorMessage { Property = property, ErrorType = errorType, Message = message });
	//    }

	//    public void ShowErrorMessage(string property, string errorType)
	//    {
	//        this.ShowErrorMessage(property, errorType, string.Empty);
	//    }

	//    public bool HasError(string property, string errorType)
	//    {
	//        return this.ErrorMessages.Any(e => e.ErrorType == errorType && e.Property == property);
	//    }

	//    public void Validate()
	//    {
	//        this.HasBeenValidated = true;
	//        this.ValidationProcess();
	//    }

	//    #endregion

	//    #region Abstract Methods

	//    public abstract void ValidationProcess();

	//    #endregion
	//}

	public class ErrorMessage
	{
		#region Constructors

		public ErrorMessage() { }

		public ErrorMessage(string property, string errorType)
		{
			this.Property = property;
			this.ErrorType = errorType;
		}

		public ErrorMessage(string property, string errorType, string message)
		{
			this.Property = property;
			this.ErrorType = errorType;
			this.Message = message;
		}

		#endregion

		#region Public Properties

		public string Property { get; set; }

		public string ErrorType { get; set; }

		public string Message { get; set; }

		#endregion
	}
}
