using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace PetClinicTestAutomation.Base {
    public class BaseTest {
        protected IWebDriver Driver { get; private set; }

        [SetUp]
        public virtual void Setup() {

            var options = new FirefoxOptions();
            options.BinaryLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            Driver = new FirefoxDriver(path + "\\drivers", options);
            Driver.Manage().Window.Maximize();
            Driver.Url = "http://localhost:8080/";

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.Until(driver => driver.Title == "PetClinic :: a Spring Framework demonstration");
        }

        [TearDown]
        public void Teardown() {
            Driver?.Quit();
            Driver?.Dispose();
        }

        public void Dispose() {
            Teardown();
        }
    }
}
