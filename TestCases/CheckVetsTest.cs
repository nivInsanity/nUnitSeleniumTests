using PetClinicTestAutomation.Base;
using PetClinicTestAutomation.Pages;

namespace PetClinicTestAutomation.TestCases;

[TestFixture]
public class CheckVetsTest : BaseTest
{
    private VeterinariansPage vetsPage;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        vetsPage = new VeterinariansPage(Driver);
    }
    
    [TearDown]
    public new void Teardown() {
        base.Teardown();
    }

    [Test]
    public void CheckVeterinariansTest()
    {
        vetsPage.GoToVeterinariansPage();
        vetsPage.IsVeterinariansListDisplayed();
        vetsPage.AreVeterinariansListColumnsDisplayed();
    }
    
}