using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProgressTask
{

	public abstract class BasePage
	{
		private IWebDriver _driver;
		
		public BasePage(IWebDriver driver)
		{
			_driver = driver;
		}

		public IWebDriver Driver => _driver;

		public string Url { get; protected set; }

		public void NavigateTo()
		{
			Driver.Navigate().GoToUrl(Url);
		}

	}
}
