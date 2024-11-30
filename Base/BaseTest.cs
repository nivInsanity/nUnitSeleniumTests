using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace myFirstNUnitTest.Base {
    public class BaseTest {
        protected IWebDriver Driver { get; private set; }

        [SetUp]
        public void Setup() {

            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            Driver = new ChromeDriver(path + "\\drivers");
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
