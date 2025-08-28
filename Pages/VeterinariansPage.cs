using OpenQA.Selenium;
using PetClinicTestAutomation.Base;


namespace PetClinicTestAutomation.Pages;


public class VeterinariansPage
{
    private readonly ElementInteractions elementInteractions;

    #region Locators
    private readonly string btnVeterinariansLocator = "//a[@title='veterinarians']";
    private readonly string tblVeterinariansLocator = "//table[@id='vets']";
    private readonly string strVeterinarianRecordLocator = "//tbody//tr";
    private readonly string theadLocator = "//thead//th";
    
    #endregion

    #region Methods
    public VeterinariansPage(IWebDriver driver) {
        this.elementInteractions = new ElementInteractions(driver);
    }

    public void GoToVeterinariansPage()
    {
        elementInteractions.ClickButton(btnVeterinariansLocator);
    }

    public void IsVeterinariansListDisplayed() {
        Assert.That(elementInteractions.IsElementPresent(By.XPath(tblVeterinariansLocator)), Is.EqualTo(true));
    }

    public void AreVeterinariansListColumnsDisplayed() {
        string theadNameText = elementInteractions.GetText($"({theadLocator})[1]");
        string theadSpecialityText = elementInteractions.GetText($"({theadLocator})[2]");

        Assert.That(theadNameText, Is.EqualTo("Name"));
        Assert.That(theadSpecialityText, Is.EqualTo("Specialties"));
    }
    
    #endregion

    #region Properties

    public int VeterinariansCount
    {
        get
        {
            var rows = elementInteractions.FindElements(By.XPath(tblVeterinariansLocator));
            return rows;
        }
    }

    #endregion
    
}