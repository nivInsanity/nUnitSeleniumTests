using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PetClinicTestAutomation.Base {
    public class ElementInteractions {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public ElementInteractions(IWebDriver driver) {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClickButton(string locator) {
            var button = FindElement(By.XPath(locator));
            button.Click();
        }

        public void FillInput(string locator, string value) {
            var inputField = FindElement(By.Id(locator));
            inputField.SendKeys(value);
        }
        
        public void ClearInput(string locator) {
            var inputField = FindElement(By.Id(locator));
            inputField.Clear();
        }

        private IWebElement FindElement(By by) {
            return wait.Until(d => d.FindElement(by));
        }
        public string GetText(string locator) {
            IWebElement element = FindElement(By.XPath(locator));
            return element.Text;
        }

        public bool IsElementPresent(By by) {
            var elements = driver.FindElements(by);
            return elements.Count > 0;
        }

        public void SelectFromDropdown(string locator, string lstText) {
            IWebElement dropdown = driver.FindElement(By.Id(locator));

            SelectElement selectFromDropdown = new SelectElement(dropdown);

            selectFromDropdown.SelectByText(lstText);
        }
    }
}
