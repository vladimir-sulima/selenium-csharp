using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Dto
{
    public class WindowsHandlerData 
    {
        #region Properties
        public int NumberOfCurrentlyOpenedWindows { get; set; }
        public string StartPageId { get; set; }
        public string CreateQuotePopUpPageId { get; set; }
        public string CurrentPageId { get; set; }
        public string MainFlowPageId { get; set; }
        public string AddAssuredMemberPageId { get; set; }
        public string AddNewMemberPageId { get; set; }
        public string AddRiskPageId { get; set; }
        public string AddNewRiskPageId { get; set; }
        public string SearchPartyPageId { get; set; }
        public string AddDetailsToExistAssociatedPartyPopUpPageId { get; set; }
        public string AddEditAssociatedPartyPopUpPageId { get; set; }
        public string SelectBrokerToAddToPolicyPopUpPageId { get; set; }
        public string EditFinancialDataPopUpPageId { get; set; }
        public string InstalmentsAndCommissionPopUpPageId { get; set; }
        public string SetPremiumsPopUpPageId { get; set; }
        public string InstalmentsDetailsPopUpPageId { get; set; }
        public string BindQuotePopUpPageId { get; set; }
        public string BindQuoteAddPatternPopUpPageId { get; set; }
        public string NewTab { get; set; }

        #endregion

        #region Public methods
        public int GetNumberOfCurrentlyOpenedWindows(IUIPage page)
        {
            NumberOfCurrentlyOpenedWindows = page.WebDriverWrapper.WebDriver.WindowHandles.Count;

            return NumberOfCurrentlyOpenedWindows;
        }
        public string WaitAndGetIdForNewlyOpenedWindow(WindowsHandlerData data, IUIPage page, int expectedNumbersOfOpenedWindows = 0)
        {
            WaitForNewWindowOpened(page, expectedNumbersOfOpenedWindows);

            var newPageId = GetNewWindowId(page, GetPropertyData(data));

            return newPageId;
        }
        #endregion
        #region Private methods
        private string GetNewWindowId(IUIPage page, List<string> propertiesValue)
        {
            string newWindowId = null;

            var allWindowsId = page.WebDriverWrapper.WebDriver.WindowHandles;
            foreach (var win in allWindowsId)
            {
                if (!propertiesValue.Contains(win))
                {
                    newWindowId = win;
                }
            }
            return newWindowId;
        }

        private void WaitForNewWindowOpened(IUIPage page, int numberOfExpectedWindows = 0)
        {
            var winHan = page.WebDriverWrapper.WebDriver.WindowHandles;
            if (numberOfExpectedWindows == 0)
            {
                page.WebDriverWrapper.Wait.Until(x => page.WebDriverWrapper.WebDriver.WindowHandles.Count > NumberOfCurrentlyOpenedWindows);
            }
            else
            {
                page.WebDriverWrapper.Wait.Until(x => page.WebDriverWrapper.WebDriver.WindowHandles.Count == numberOfExpectedWindows);
            }
        }
        private List<string> GetPropertyData(WindowsHandlerData data)
        {
            List<string> currentPropertiesValue = new List<string>();

            var propertiesNameAndValue = new List<PropertyInfo>(data.GetType().GetProperties());

            foreach (var prop in propertiesNameAndValue)
            {
                var propertyValue = prop.GetValue(data, null);

                if (prop.Name != "NumberOfCurrentlyOpenedWindows" && propertyValue != null)
                {
                    currentPropertiesValue.Add(propertyValue.ToString());
                }
            }
            return currentPropertiesValue;
        }
        #endregion

    }
}
