using System;
using System.Configuration;

namespace Sigma_Automation.Framework.Configuration
{
    public class ConfigurationParams
    {
        public Uri SiteUrl { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public TimeSpan Timeout { get; set; }
        public string Browser { get; set; }
        public string ScreenshotsDir { get; set; }
        public string CreatedTestDataFileFolder { get; set; }
        public string PerformanceTestsDataFileFolder { get; set; }
        public string SmokeTestsDataFileFolder { get; set; }

        public static ConfigurationParams ReadFromConfig()
        {
            return new ConfigurationParams
            {
                SiteUrl = new Uri(ConfigurationManager.AppSettings["SiteUrl"]),
                UserName = ConfigurationManager.AppSettings["UserName"],
                UserPass = ConfigurationManager.AppSettings["UserPass"],
                Timeout = TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Timeout"])),
                Browser = ConfigurationManager.AppSettings["Browser"],
                ScreenshotsDir = ConfigurationManager.AppSettings["ScreenshotsDir"],
                CreatedTestDataFileFolder = ConfigurationManager.AppSettings["CreatedTestDataFileFolder"],
                PerformanceTestsDataFileFolder = ConfigurationManager.AppSettings["PerformanceTestsDataFileFolder"],
                SmokeTestsDataFileFolder = ConfigurationManager.AppSettings["SmokeTestsDataFileFolder"]
            };
        }

        public Uri GetUrl()
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(UserPass))
            {
                return SiteUrl;
            }

            var urlBuilder = new UriBuilder(SiteUrl);
            urlBuilder.UserName = UserName;
            urlBuilder.Password = UserPass;

            return urlBuilder.Uri;
        }
    }
}