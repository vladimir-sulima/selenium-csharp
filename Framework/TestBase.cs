using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sigma_Automation.Page.enums;
using Sigma_Automation;
using Sigma_Automation.Dto;

namespace Sigma_Automation.Framework
{
    
    [TestFixture]
    [Parallelizable]
    public class TestBase
    {
        private List<WebDriverWrapper> runningDrivers { get; set; }
        public TestContext TestContext { get; set; }


        public TestBase()
        {
            runningDrivers = new List<WebDriverWrapper>();
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }

        public void Start<TPage>(Underwriter userName, string password, Action<TPage> action) where TPage : UIPage
        {
            using (var driver = new WebDriverWrapper())
            {
                AddRunningDriver(driver);
                driver.Configuration.UserName = userName.ToString();
                driver.Configuration.UserPass = password;

                driver.BrowserStart();

                try
                {
                    var page = UIPage.CreatePage<TPage>(driver);
                    action(page);
                }
                catch (Exception ex)
                {
                    var screenshotFile = driver.TakeScreenshot(TestContext.CurrentContext.Test.MethodName);
                    TestContext.AddTestAttachment(screenshotFile);

                    throw ex;
                }
                finally
                {
                    RemoveRunningDriver(driver);
                }
                
            }
        }

        public void Start<TPage>(Action<TPage> action) where TPage : UIPage
        {
            using (var driver = new WebDriverWrapper())
            {
                AddRunningDriver(driver);

                driver.BrowserStart();

                try
                {
                    var page = UIPage.CreatePage<TPage>(driver);
                    action(page);
                }
                catch (Exception ex)
                {
                    var screenshotFile = driver.TakeScreenshot(TestContext.CurrentContext.Test.MethodName);
                    TestContext.AddTestAttachment(screenshotFile);

                    throw ex;
                }
                finally
                {
                    RemoveRunningDriver(driver);
                }

            }

        }
        public void Start<TPage>(MainFlowData mainFlowData, Action<TPage> action) where TPage : UIPage
        {
            using (var driver = new WebDriverWrapper())
            {
                AddRunningDriver(driver);

                driver.BrowserStart();

                try
                {
                    mainFlowData.WindowsHandlerData.StartPageId = driver.WebDriver.CurrentWindowHandle;
                    var page = UIPage.CreatePage<TPage>(driver);
                    action(page);
                }
                catch (Exception ex)
                {
                    var screenshotFile = driver.TakeScreenshot(TestContext.CurrentContext.Test.MethodName);
                    TestContext.AddTestAttachment(screenshotFile);

                    throw ex;
                }
                finally
                {
                    RemoveRunningDriver(driver);
                }

            }

        }
        [OneTimeSetUp]
        protected void SetUp()
        {
            //SetupReporting();
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            //AfterTest();
        }
        [SetUp]
        public void BeforeTest()
        {
            //Test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void TestCleanup()
        {
            runningDrivers.ForEach(x => x.Dispose());
        }

        private void AddRunningDriver(WebDriverWrapper driver)
        {
            runningDrivers.Add(driver);
        }

        private void RemoveRunningDriver(WebDriverWrapper driver)
        {
            runningDrivers.Remove(driver);
        }


    }

    [TestFixture]
    public class TestBase<TPage> where TPage : UIPage
    {
        public TestContext TestContext { get; set; }
        public WebDriverWrapper WebDriverWrapper { get; private set; }

        public TestBase()
        {
            WebDriverWrapper = new WebDriverWrapper();
            WebDriverWrapper.BrowserStart();
        }

        public TPage Start()
        {
            var page = UIPage.CreatePage<TPage>(WebDriverWrapper);
            return page;
        }

        [SetUp]
        public void TestInit()
        {
            try
            {
                var currentUrl = WebDriverWrapper.WebDriver.Url;
            }

            catch (Exception)
            {
                WebDriverWrapper.BrowserRestart();
            }

            finally
            {
                //TODO: screen recording
            }
        }

        [TearDown]
        public void TestCleanup()
        {
            try
            {
                //if (TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
                //{
                //  var file = WebDriverWrapper.TakeScreenshot(TestContext.TestName);
                //TestContext.AddResultFile(file);
                //}

                //else
                //{
                //    //ControlBase.FindAndClick("//button[text()='Log out']", How.XPath);
                //    //try
                //    //{
                //    //    Thread.Sleep(3000);
                //    //    ControlBase.FindAndClick("//a[text()='Sign Out ']", How.XPath);

                //    //}

                //    //catch (Exception)
                //    //{
                //    //    ControlBase.FindAndClick("//a[@class='logo']", How.XPath);
                //    //    //   ControlBase.BrowserRestart();
                //    //}

                //    //finally
                //    //{
                //    //    //TODO: screen recording
                //    //}
                //}

                //var siteHome = new MasterPage<TPage>();
                //will do Logoff if test was not finished with logoff, if user is already on Login page nothing happens
                //siteHome.Logoff();

            }
            catch (Exception ex)
            {
                //TODO: exception handler
            }
            finally
            {
                //TODO: stop recording
                WebDriverWrapper?.WebDriver?.Quit();
            }
        }
    }
}
