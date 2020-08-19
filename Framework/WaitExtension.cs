using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation
{
    public static class WaitExtension
    {
        public static void InterceptedFindUntil(this WebDriverWait wait, Func<IWebDriver, string, bool> condition, string locator)
        {
            try
            {
                wait.Until(x => condition(x, locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebDriverTimeoutException(string.Format("Search failed : {0}", locator), ex);
            }
        }

        public static void InterceptedUntil(this WebDriverWait wait, Func<IWebElement, bool> condition, IWebElement element, string usedLocator = null)
        {
            try
            {
                wait.Until(x => condition(element));
            }
            catch (WebDriverTimeoutException ex)
            {
                var message = usedLocator == null
                    ? string.Format("Search failed for element : Tag name: {0}; Text : {1}; Location : {2}"
                        , element.TagName, element.Text, element.Location)
                    : string.Format("Search failed for element : Used locator: \"{0}\"; Tag name: \"{1}\"; Text : \"{2}\"; Location : {3}"
                        , usedLocator, element.TagName, element.Text, element.Location);

                throw new WebDriverTimeoutException(message, ex);
            }
        }
    }
}
