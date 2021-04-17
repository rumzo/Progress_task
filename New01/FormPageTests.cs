using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static ProgressTask.FormPage;
using System.Collections;





namespace ProgressTask
{

	[TestFixture]
	public class FormPageTests 
	{

		private  IWebDriver driver;
		private FormPage formPage;
		

		[SetUp]
		public void SetUp()
		{
			driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
			driver.Manage().Window.Maximize();
			formPage = new FormPage(driver);
		}

		[TearDown]
		public void TearDown()
		{
			driver.Close();
		}


		[Test]
		public void SubmitFormPageWithValidData()
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			formPage.NavigateTo();
			formPage.FirstNameField.SendKeys("testtt");
			formPage.LastNameField.SendKeys("testttt");
			formPage.EmailField.SendKeys("testttt@aa.bb");
			formPage.CompanyField.SendKeys("testttt");
			formPage.PhoneField.SendKeys("123456");

			IWebElement productInterest = formPage.ProductInterestDropDown;
			SelectElement productInterestDropDown = new SelectElement(productInterest);
			productInterestDropDown.SelectByText("iMacros");

			IWebElement country = formPage.CountryDropDown;
			SelectElement countryDropDown = new SelectElement(country);
			countryDropDown.SelectByText("Bulgaria");

			formPage.MessageField.SendKeys("testtt");
			formPage.AcceptCookiesButton.Click();
			formPage.ContactUsButton.Click();

            IWebElement confirmationMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#form--1 span[data-sf-role*='success-message']")));
            String ActualMessage = confirmationMessage.Text;
			String ExpectedMessage = "Thank you for filling out our form.";

			Assert.That(ActualMessage.Equals(ExpectedMessage));
		}

		[Test]
		public void CheckAllProductInterestOptions()
        {

			formPage.NavigateTo();

			var expOptions = new ArrayList()
			{
				"Select...", "WhatsUp Gold", "iMacros", "Log Management", "WS_FTP Professional", "WS_FTP Server", "MOVEit", "MessageWay"
			};

			IList<string> actOptions = new List<string>();

		   var selectElement = new SelectElement(formPage.ProductInterestDropDown);
		   var allOptions = selectElement.Options;

			for (int i = 0; i < allOptions.Count; i++)
			{
				if (allOptions[i].Displayed)
				{
					actOptions.Add(allOptions[i].Text);
				}
			}

			Assert.AreEqual(actOptions, expOptions);
		}


		[Test]
		public void SubmitFormPageWithInvalidEmail()
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			formPage.NavigateTo();
			formPage.FirstNameField.SendKeys("testtt");
			formPage.LastNameField.SendKeys("testttt");
			formPage.EmailField.SendKeys("testttt");
			formPage.CompanyField.SendKeys("testttt");
			formPage.PhoneField.SendKeys("123456");

			IWebElement productInterest = formPage.ProductInterestDropDown;
			SelectElement productInterestDropDown = new SelectElement(productInterest);
			productInterestDropDown.SelectByText("iMacros");

			IWebElement country = formPage.CountryDropDown;
			SelectElement countryDropDown = new SelectElement(country);
			countryDropDown.SelectByText("Bulgaria");

			formPage.MessageField.SendKeys("testtt");
			formPage.AcceptCookiesButton.Click();
			formPage.ContactUsButton.Click();

			IWebElement confirmationMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#Email-1 + p")));
			String ActualMessage = confirmationMessage.Text;
			String ExpectedMessage = "Enter a Valid Business Email Address example@yourdomain.com";

			Assert.That(ActualMessage.Equals(ExpectedMessage));
		}


		[Test]
		public void SubmitFormPageWithCountryUSA()
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			formPage.NavigateTo();
			formPage.FirstNameField.SendKeys("testtt");
			formPage.LastNameField.SendKeys("testttt");
			formPage.EmailField.SendKeys("testttt@aa.bb");
			formPage.CompanyField.SendKeys("testttt");
			formPage.PhoneField.SendKeys("123456");

			IWebElement productInterest = formPage.ProductInterestDropDown;
			SelectElement productInterestDropDown = new SelectElement(productInterest);
			productInterestDropDown.SelectByText("iMacros");

			IWebElement country = formPage.CountryDropDown;
			SelectElement countryDropDown = new SelectElement(country);
			countryDropDown.SelectByText("USA");

			IWebElement stateProvince = formPage.StateProvinceDropDown;
			SelectElement stateProvinceDropDown = new SelectElement(stateProvince);
			stateProvinceDropDown.SelectByText("Alabama");

			formPage.MessageField.SendKeys("testtt");
			formPage.AcceptCookiesButton.Click();
			formPage.ContactUsButton.Click();

			IWebElement confirmationMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#form--1 span[data-sf-role*='success-message']")));
			String ActualMessage = confirmationMessage.Text;
			String ExpectedMessage = "Thank you for filling out our form.";

			Assert.That(ActualMessage.Equals(ExpectedMessage));
		}


		[Test]
		public void SubmitEmptyForm()
		{
			formPage.NavigateTo();

			Thread.Sleep(2000);

			formPage.AcceptCookiesButton.Click();
			formPage.ContactUsButton.Click();

			String actFirstNameErrorMessage = formPage.FirstNameFieldErrorMessage.Text;
			String expFirstNameErrorMessage = "First Name is Required";

			String actLastNameErrorMessage = formPage.LastNameFieldErrorMessage.Text;
			String expLastNameErrorMessage = "Last Name is Required";

			String actEmailErrorMessage = formPage.EmailFieldErrorMessage.Text;
			String expEmailErrorMessage = "Enter a Valid Business Email Address example@yourdomain.com";

			String actPhoneErrorMessage = formPage.PhoneFieldErrorMessage.Text;
			String expPhoneErrorMessage = "Business Phone is Required";

			String actCompanyErrorMessage = formPage.CompanyFieldErrorMessage.Text;
			String expCompanyErrorMessage = "Organization is Required";

			String actProductInterestErrorMessage = formPage.ProductInterestErrorMessage.Text;
			String expProductInterestErrorMessage = "This Field is Required.";

			String actCountryErrorMessage = formPage.CompanyFieldErrorMessage.Text;
			String expCountryErrorMessage = "Country is Required";

			String actMessageFieldErrorMessage = formPage.MessageFieldErrorMessage.Text;
			String expMessageFieldErrorMessage = "This Field is Required.";
		}

	}
}
