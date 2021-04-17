using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProgressTask
{
	public partial class FormPage : BasePage
	{
       
		public FormPage(IWebDriver driver) : base(driver)
		{
			Url = "https://www.ipswitch.com/test-form-page";
		}

		public IWebElement FirstNameField => Driver.FindElement(By.Id("Textbox-1"));
		public IWebElement LastNameField => Driver.FindElement(By.Id("Textbox-3"));
		public IWebElement EmailField => Driver.FindElement(By.Id("Email-1"));
		public IWebElement CompanyField => Driver.FindElement(By.Id("Textbox-2"));
		public IWebElement PhoneField => Driver.FindElement(By.Id("Textbox-4"));
		public IWebElement ProductInterestDropDown => Driver.FindElement(By.Id("Dropdown-1"));
		public IWebElement CountryDropDown => Driver.FindElement(By.Id("Country-1"));
		public IWebElement StateProvinceDropDown => Driver.FindElement(By.Id("State-1"));
		public IWebElement MessageField => Driver.FindElement(By.Id("Textarea-1"));
		public IWebElement AcceptCookiesButton => Driver.FindElement(By.CssSelector("#onetrust-banner-sdk #onetrust-accept-btn-handler"));
		public IWebElement ContactUsButton => Driver.FindElement(By.CssSelector("#C023_Col00 .Btn"));
		public IWebElement EmailFieldErrorMessage => Driver.FindElement(By.CssSelector("#Email-1 + p"));
		public IWebElement FirstNameFieldErrorMessage => Driver.FindElement(By.CssSelector("#Textbox-1 + p"));
		public IWebElement LastNameFieldErrorMessage => Driver.FindElement(By.CssSelector("#Textbox-3 + p"));
		public IWebElement PhoneFieldErrorMessage => Driver.FindElement(By.CssSelector("#Textbox-4 + p"));
		public IWebElement CompanyFieldErrorMessage => Driver.FindElement(By.CssSelector(".sf-fieldWrp .dnb-input + p"));
		public IWebElement ProductInterestErrorMessage => Driver.FindElement(By.CssSelector("#Dropdown-1 + p"));
		public IWebElement CountryErrorMessage => Driver.FindElement(By.CssSelector("#Country-1 + p"));
		public IWebElement MessageFieldErrorMessage => Driver.FindElement(By.CssSelector("#Textarea-1 + p"));
		public IWebElement ConfirmationMessage => Driver.FindElement(By.CssSelector("#form--1 span[data-sf-role*='success-message']"));

	}
}
