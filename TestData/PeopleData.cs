namespace PetClinicTestAutomation.TestData {
    public class Owner {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }
    }
    public class Animal {
        public string name { get; set; }
        public string birthDate { get; set; }
        public string birthDateFromPetsAndVisits { get; set; }
        public string type { get; set; }
    }
    public static class PeopleData {
        public static Owner Bartolomeo { get; } = new Owner {
            firstName = "Bartolomeo",
            lastName = "Chaffinch",
            address = "Imagined 234/a",
            city = "New York",
            phoneNumber = "1234567890"
        };

        public static Owner Pedro { get; } = new Owner {
            firstName = "Pedro",
            lastName = "Pascal",
            address = "610 Canyon Rd",
            city = "Santa Fe",
            phoneNumber = "1234567890"
        };
    }

    public static class AnimalData {
        public static Animal Dog { get; } = new Animal {
            name = "Puffy",
            birthDate = "2020-02-02",
            //On adding and editing page date format is dd.mm.yyyy, but on Pets and Visits it's yyyy-mm-dd
            birthDateFromPetsAndVisits = "2020-02-02",
            type = "dog"
        };
    }
}
