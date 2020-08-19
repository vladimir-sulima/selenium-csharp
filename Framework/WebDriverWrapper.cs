using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System.Configuration;
using Sigma_Automation.Framework.Configuration;

namespace Sigma_Automation
{
    public class WebDriverWrapper : IDisposable
    {
        public IWebDriver WebDriver { get; set; }
        public WebDriverWait Wait { get; set; }
        public ConfigurationParams Configuration { get; set; }

        public WebDriverWrapper()
        {
            Configuration = ConfigurationParams.ReadFromConfig();
        }
        public void FindAndCheckCheckboxesByClassName(string className)
        {
            var elements = FindElementsByClassName(className);

            foreach (var element in elements.Where(element => !element.Selected))
            {
                Click(element, String.Format("checkbox[name:{0}]", className));
            }
        }

        public List<IWebElement> FindElementsBy(How how, string selector)
        {
            switch (how)
            {
                case How.Id:
                    return FindElementsById(selector);
                case How.Name:
                    return FindElementsByName(selector);
                case How.ClassName:
                    return FindElementsByClassName(selector);
                case How.CssSelector:
                    return FindElementsByCssSelector(selector);
                case How.LinkText:
                    return FindElementsByLinkText(selector);
                default:
                    return FindElementsByXPath(selector);
            }
        }

        public List<IWebElement> FindElementsByClassName(string className)
        {
            return WebDriver.FindElements(By.ClassName(className)).ToList();
        }

        public List<IWebElement> FindElementsByXPath(string locator)
        {
            return WebDriver.FindElements(By.XPath(locator)).ToList();
        }

        public List<IWebElement> FindElementsById(string locator)
        {
            return WebDriver.FindElements(By.Id(locator)).ToList();
        }

        public List<IWebElement> FindElementsByCssSelector(string locator)
        {
            return WebDriver.FindElements(By.CssSelector(locator)).ToList();
        }

        public List<IWebElement> FindElementsByLinkText(string locator)
        {
            return WebDriver.FindElements(By.LinkText(locator)).ToList();
        }

        public List<IWebElement> FindElementsByName(string locator)
        {
            return WebDriver.FindElements(By.Name(locator)).ToList();
        }

        public void Click(IWebElement self, string usedLocator = null)
        {
            WaitElementIsClickable(self, usedLocator);
            self.Click();
        }

        public IWebElement FindBy(How how, string locator, int index = 0)
        {

            switch (how)
            {
                case How.Id:
                    Wait.InterceptedFindUntil((x, l) => x.FindElements(By.Id(l)).Count > index, locator);
                    return WebDriver.FindElements(By.Id(locator))[index];

                case How.Name:
                    Wait.InterceptedFindUntil((x, l) => x.FindElements(By.Name(l)).Count > index, locator);
                    return WebDriver.FindElements(By.Name(locator))[index];

                case How.ClassName:
                    Wait.InterceptedFindUntil((x, l) => x.FindElements(By.ClassName(l)).Count > index, locator);
                    return WebDriver.FindElements(By.ClassName(locator))[index];

                case How.LinkText:
                    Wait.InterceptedFindUntil((x, l) => x.FindElements(By.LinkText(l)).Count > index, locator);
                    return WebDriver.FindElements(By.LinkText(locator))[index];

                case How.PartialLinkText:
                    Wait.InterceptedFindUntil((x, l) => x.FindElements(By.PartialLinkText(l)).Count > index, locator);
                    return WebDriver.FindElements(By.PartialLinkText(locator))[index];

                case How.CssSelector:
                    Wait.InterceptedFindUntil((x, l) => x.FindElements(By.CssSelector(l)).Count > index, locator);
                    return WebDriver.FindElements(By.CssSelector(locator))[index];

                default:
                    Wait.InterceptedFindUntil((x, l) => x.FindElements(By.XPath(l)).Count > index, locator);
                    return WebDriver.FindElements(By.XPath(locator))[index];
            }
        }

        public bool CheckElementExistsById(string locator)
        {
            return WebDriver.FindElements(By.Id(locator)).Count > 0;
        }

        public bool CheckElementExistsByName(string locator)
        {
            return WebDriver.FindElements(By.Name(locator)).Count > 0;
        }

        public bool CheckElementExistsByClassName(string locator)
        {
            return WebDriver.FindElements(By.ClassName(locator)).Count > 0;
        }

        public bool CheckElementExistsByLinkText(string locator)
        {
            return WebDriver.FindElements(By.LinkText(locator)).Count > 0;
        }

        public bool CheckElementExistsByXpath(string locator)
        {
            return WebDriver.FindElements(By.XPath(locator)).Count > 0;
        }

        /// <summary>
        ///     Search element on the page, if exists return true, else - false
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        public bool CheckElementExists(string locator, How how = How.Id)
        {
            switch (how)
            {
                case How.Id:
                    return CheckElementExistsById(locator);

                case How.Name:
                    return CheckElementExistsByName(locator);

                case How.ClassName:
                    return CheckElementExistsByClassName(locator);

                case How.LinkText:
                    return CheckElementExistsByLinkText(locator);

                default:
                    return CheckElementExistsByXpath(locator);
            }
        }


        /// <summary>
        ///     Find element and call click event on it
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        /// <param name="index">index of occurence, default is 0</param>
        public void FindAndClick(string locator, How how = How.Id, int index = 0)
        {
            Click(FindBy(how, locator, index), locator);
        }

        /// <summary>
        ///     Wait until element is displayed
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        public void WaitElementIsDisplayed(string locator, How how = How.Id)
        {
            Wait.InterceptedFindUntil((x, l) => FindBy(how, l).Displayed, locator);
        }

        /// <summary>
        ///     Wait until element is displayed
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        public void WaitElementIsNotDisplayed(string locator, How how = How.Id)
        {
            Wait.InterceptedFindUntil((x, l) => !FindBy(how, l).Displayed, locator);
        }

        /// <summary>
        ///     Wait until element is enabled
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        public void WaitElementIsEnabled(string locator, How how = How.Id)
        {
            Wait.InterceptedFindUntil((x, l) => FindBy(how, l).Enabled, locator);
        }

        public void WaitElementIsClickable(IWebElement element, string usedLocator = null)
        {
            //Wait.InterceptedUntil(e => e.Displayed && e.Enabled, element, usedLocator);
        }

        public void WaitUntilElementIsVisible(string locator, How how = How.Id)
        {
            switch (how)
            {
                case How.Id:
                    Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
                    break;

                case How.ClassName:
                    Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator)));
                    break;

                default:
                    Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
                    break;
            }

        }

        public void WaitForAjax()
        {
            try
            {
                Wait.Until(x => (bool)(WebDriver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
            }
            catch (WebDriverTimeoutException)
            {
                //TODO: add error handler
            }
        }

        public object ExecuteScript(string script)
        {
            return (WebDriver as IJavaScriptExecutor).ExecuteScript(script);
        }

        /// <summary>
        ///     Find element and check if it is enabled or not
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        public bool IsEnabled(string locator, How how = How.Id)
        {
            return FindBy(how, locator).Enabled;
        }

        /// <summary>
        ///     Find element and check if it is displayed or not
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        public bool IsDisplayed(string locator, How how = How.Id)
        {
            return FindBy(how, locator).Displayed;
        }

        /// <summary>
        ///     Get text of the element
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        /// <returns>element text</returns>
        public string GetText(string locator, How how = How.Id)
        {
            return FindBy(how, locator).Text;
        }

        /// <summary>
        ///     Get value of the element
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="how">identifier type, default is Id</param>
        /// <returns>element text</returns>
        public string GetValue(string locator, How how = How.Id)
        {
            return GetAttributeValue(locator, how, "value");
        }

        public string GetAttributeValue(string locator, How how, string attributeName)
        {
            return FindBy(how, locator).GetAttribute(attributeName);
        }

        public string GetAttributeValue(IWebElement element, string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        /// <summary>
        ///     Find and set text into element
        /// </summary>
        /// <param name="locator">element identifier name</param>
        /// <param name="text">text to be inserted</param>
        /// <param name="how">identifier type, default is Id</param>
        public void FindAndSetText(string locator, string text, How how = How.Id)
        {
            SetText(FindBy(how, locator), text);
        }

        public void SetText(IWebElement self, string text)
        {
            self.Clear();
            self.SendKeys(text);
        }

        public void Select(string defaultText, string optionToSelect)
        {
            WaitForAjax();

            FindAndClick(String.Format("//span[@class='k-input' and text()='{0}']", defaultText), How.XPath);

            FindAndClick(String.Format("//li[@role='option' and text()='{0}']", optionToSelect), How.XPath);
        }

        public void SelectFromDropdown(string id, string optionToSelect)
        {
            new SelectElement(FindBy(How.Id, id)).SelectByText(optionToSelect);
        }

        public void SelectItemFromMultiSelect(string id, string item)
        {
            WaitForAjax();
            FindAndClick(String.Format("//div[@id='{0}']//input", id), How.XPath);
            FindAndClick(String.Format("//li[text()='{0}']", item), How.XPath);
        }

        public void RemoveItemFromMultiSelect(string id, string item)
        {
            WaitForAjax();
            FindAndClick(
                String.Format("//div[@id='{0}']//span[text()='{1}']/following-sibling::span[text()='delete']", id,
                    item), How.XPath);
        }

        public String[] GetButtons(string containerId)
        {
            var buttons =
                WebDriver.FindElements(By.XPath(String.Format("//p[@id={0}]/a", containerId)));
            return (from IWebElement button in buttons select button.Text).ToArray();
        }

        public String[] GetGridActionButtons(string gridTitle, string textFromRow, int column)
        {
            var buttons =
                WebDriver.FindElements(
                    By.XPath(String.Format("//div[@id='{0}']//.[text()='{1}']/../../td[{2}]", gridTitle, textFromRow,
                        column)));

            return (from IWebElement button in buttons select button.Text).ToArray();
        }

        public void ForceWait(TimeSpan fromSeconds)
        {
            Thread.Sleep(fromSeconds.Seconds * 1000);
        }

        public void SendKeyTab(string locator, How how = How.Id)
        {
            FindBy(how, locator).SendKeys("\t");
        }

        public void SendEnterTab(string locator, How how = How.Id)
        {
            FindBy(how, locator).SendKeys(Keys.Return);
        }

        public void SendKeyPageDown(string xpathLocator)
        {
            Actions actions = new Actions(WebDriver);
            var element = WebDriver.FindElement(By.XPath(xpathLocator));
            actions.MoveToElement(element);
            actions.Click();
            actions.SendKeys(Keys.PageDown);
            actions.Build().Perform();
        }

        public void ScrollDownPage(int scrollValue)
        {
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            js.ExecuteScript(string.Format("window.scrollBy({0},0);", scrollValue));
        }


        public void Confirm()
        {
            WebDriver.SwitchTo().Alert().Accept();
        }

        public void SwithToActiveElement(string frameName)
        {
            WebDriver.SwitchTo().ActiveElement();
        }

        public int GetGridTotalItemsCount(string gridName)
        {
            var pagerInfo = GetText(
                string.Format("//div[@class='k-widget k-grid' and @id='{0}']//span[@class='k-pager-info k-label']",
                    gridName), How.XPath);

            var regex = new Regex(@"\d+");
            var number = regex.Matches(pagerInfo)[2].Value;
            return int.Parse(number);
        }

        public string TakeScreenshot(string testName)
        {
            if (Configuration == null)
            {
                throw new NotSupportedException("Configration is not set. Please set Configuration property.");
            }

            string screenshotFolder = ConfigurationManager.AppSettings["ScreenshotsDir"];

            string currentFolder = DateTime.Now.ToString("yyyy_MM_dd__hh_mm_ss");

            string outputFolder = Path.Combine(screenshotFolder, currentFolder);

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            var scrfail = ((ITakesScreenshot)WebDriver).GetScreenshot();
            string pngFileName = string.Format("{0}_{1}.png", testName,
                DateTime.Now.ToString("yyyy m d dddd hh_MM_ss"));
            string fullFileName = Path.Combine(outputFolder, pngFileName);

            scrfail.SaveAsFile(fullFileName, ScreenshotImageFormat.Png);

            return fullFileName;
        }



        public string ButtonIsNotPresented(string buttonID)
        {
            try
            {
                FindBy(How.Id, buttonID);
                return "no";
            }
            catch (NoSuchElementException)
            {
                return "true";
            }
        }

        public void WaitUntilButtonIsPresented(string buttonID)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(buttonID)));
        }

        public void FindAndUploadFile(string locator, string text, How how = How.Id)
        {
            var element = FindBy(how, locator);
            element.SendKeys(text);
        }

        public void WaitTillPageLoaded(int sleep = 0, bool waitForAjax = true)
        {
            Wait.Until(x => FindElementsByXPath("//div[@class='loader hidden']").Any());

            if (waitForAjax == true)
            {
                WaitForAjax();
            }

            Thread.Sleep(sleep);
        }

        public void BrowserStart(string url = null)
        {
            switch (Configuration.Browser)
            {
                case "IE":

                    var ieOptions = new InternetExplorerOptions { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
                    WebDriver = new InternetExplorerDriver(options: ieOptions);

                    break;

                case "Chrome":
                    WebDriver = new ChromeDriver();
                    break;

                case "DockerChrome":

                    var cap = new ChromeOptions();
                    cap.AddArguments("version", "", "platform", "Linux");

                    WebDriver = new RemoteWebDriver(new Uri("http://localhost:4449/wd/hub"), cap.ToCapabilities(), TimeSpan.FromSeconds(180));

                    break;

                case "ChromeRemoteLocal":
                    var capLocal = new ChromeOptions();
                    capLocal.AddArguments("version", "");
                    capLocal.AddArguments("platform", "Linux");
                    capLocal.ToCapabilities();

                    WebDriver = new RemoteWebDriver(new Uri("http://localhost:4447/wd/hub"), capLocal);

                    break;

                case "Firefox":
                    WebDriver = new FirefoxDriver();
                    break;

                default:
                    throw new NotSupportedException(
                        $"Browser {Configuration.Browser} is unknown or not supported. Please check browser name.");
            }
            WebDriver.Manage().Window.Maximize();
            if (url == null)
            {
                WebDriver.Navigate().GoToUrl(Configuration.GetUrl());
            }
            else
            {
                WebDriver.Navigate().GoToUrl(url);
            }

            Wait = new WebDriverWait(WebDriver, Configuration.Timeout);
        }

        public void BrowserRestart(string url = null)
        {
            WebDriver.Quit();
            BrowserStart(url);
        }
        public void BrowserRefresh(string url = null)
        {
            WebDriver.Navigate().Refresh();
            BrowserStart(url);
        }
        public void Dispose()
        {
            WebDriver?.Quit();
        }
        public void SwithToNewPage(int waitFor = 0)
        {
            Thread.Sleep(waitFor);

            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());

        }

    }
}