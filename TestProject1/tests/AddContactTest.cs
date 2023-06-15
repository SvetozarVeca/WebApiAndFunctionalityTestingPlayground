using MongoDB.Bson.IO;
using System.Diagnostics.Contracts;
using TestProject1.pageObjects;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class AddContactTest : BaseTest
    {
        [Test, TestCaseSource("ValidLogInCredentialsAndNewContact")]
        public void AddNewContact(AppUser user, ContactEntry contactEntry)
        {
            MainPage mainPage = new MainPage(GetDriver());
            ContactListPage contactListPage = mainPage.ClickSubmitWithValidCredentials(user.Email, user.Password);
            ContactPage contactPage = contactListPage.AddNewContact();

            contactPage.AddContact(contactEntry);
        }

        public static IEnumerable<TestCaseData> ValidLogInCredentialsAndNewContact()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirecory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string contactJsonFilePath = $"{projectDirecory}\\contactData.json";
            string userJsonFilePath = $"{projectDirecory}\\userData.json";

            ContactEntry contactEntry = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactEntry>(File.ReadAllText(contactJsonFilePath));
            AppUser user = Newtonsoft.Json.JsonConvert.DeserializeObject<AppUser>(File.ReadAllText(userJsonFilePath));

            yield return new TestCaseData(user, contactEntry);
        }
    }
}
