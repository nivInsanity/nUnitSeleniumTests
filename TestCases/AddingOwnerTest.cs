using PetClinicTestAutomation.Base;
using PetClinicTestAutomation.Pages;
using PetClinicTestAutomation.TestData;


namespace PetClinicTestAutomation.TestCases {

    [TestFixture]
    public class AddingOwnerTest : BaseTest {
        private FindOwnersPage findOwnerPage;


        [SetUp]
        public override void Setup() {
            base.Setup();
            findOwnerPage = new FindOwnersPage(Driver);
        }

        [TearDown]
        public new void Teardown() {
            base.Teardown();
        }

        [Test]
        [Order(1)]
        public void AddOwnerTest() {

            var owner = PeopleData.Bartolomeo;

            findOwnerPage.AddOwner(owner.firstName,
                                   owner.lastName,
                                   owner.address,
                                   owner.city,
                                   owner.phoneNumber);

            findOwnerPage.CheckOwner(owner.firstName,
                                     owner.lastName,
                                     owner.address,
                                     owner.city,
                                     owner.phoneNumber);
        }

        [Test]
        [Order(2)]
        public void AddAnimalTest() {
            var dog = AnimalData.Dog;
            var owner = PeopleData.Bartolomeo;

            findOwnerPage.AddPet(dog.name,
                                 dog.birthDate,
                                 dog.type,
                                 owner.firstName,
                                 owner.lastName);

            findOwnerPage.CheckPet(dog.name,
                                   dog.birthDateFromPetsAndVisits,
                                   dog.type,
                                   owner.firstName,
                                   owner.lastName);
        }

        [Test]
        [Order(3)]
        public void EditOwnerTest() {
            var owner = PeopleData.Bartolomeo;
            var editedOwner = PeopleData.Pedro;

            findOwnerPage.EditOwnerData(owner.firstName,
                                        owner.lastName,
                                        editedOwner.firstName,
                                        editedOwner.lastName,
                                        editedOwner.address,
                                        editedOwner.city,
                                        editedOwner.phoneNumber);

            findOwnerPage.CheckOwner(editedOwner.firstName,
                                     editedOwner.lastName,
                                     editedOwner.address,
                                     editedOwner.city,
                                     editedOwner.phoneNumber);
        }
    }
}