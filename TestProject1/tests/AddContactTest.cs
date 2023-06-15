using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.pageObjects;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class AddContactTest : BaseTest
    {
        [Test,TestCaseSource("ValidLogInCredentialsAndNewContact")]
        public void AddNewContact(string userEmail, string password,string firstName, string lastName, string dateOfBirth, string contactEmail, string phone,
            string streetAdd1, string streetAdd2, string city,string state, string postalCode, string country)
        {
            MainPage mainPage = new MainPage(GetDriver());
            ContactListPage contactListPage = mainPage.ClickSubmitWithValidCredentials(userEmail, password);
            ContactPage contactPage = contactListPage.AddNewContact();

            contactPage.AddContact(firstName,lastName, dateOfBirth, contactEmail, phone,streetAdd1,streetAdd2,city, state, postalCode, country);
        }

        public static IEnumerable<TestCaseData> ValidLogInCredentialsAndNewContact()
        {
            yield return new TestCaseData(GetDataParser().ExtractUserData("email"), GetDataParser().ExtractUserData("password"), GetDataParser().ExtractContactData("firstName"),
                GetDataParser().ExtractContactData("lastName"), GetDataParser().ExtractContactData("dateOfBirth"), GetDataParser().ExtractContactData("email"),
                GetDataParser().ExtractContactData("phone"), GetDataParser().ExtractContactData("streetAdd1"), GetDataParser().ExtractContactData("streetAdd2"),
                GetDataParser().ExtractContactData("city"), GetDataParser().ExtractContactData("state"), GetDataParser().ExtractContactData("postalCode"),
                GetDataParser().ExtractContactData("country"));
        }
    }
}
