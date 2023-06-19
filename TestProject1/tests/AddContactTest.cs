using TestProject1.pageObjects;


namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class AddContactTest : BaseTest
    {
        [Test, TestCaseSource("ValidLogInCredentialsAndNewContact")]
        public void AddNewContact(AppUserDTOFromUser user, ContactDTOFromUser contactEntry)
        {
            MainPage mainPage = new MainPage(GetDriver());
            ContactListPage contactListPage = mainPage.ClickSubmitWithValidCredentials(user.Email, user.Password);

            contactListPage.WaitForAddNewContact();

            ContactPage contactPage = contactListPage.AddNewContact();
            ContactListPage contactAdded = contactPage.AddContact(contactEntry);

            Assert.IsNotNull(contactAdded);
        }

        public static IEnumerable<TestCaseData> ValidLogInCredentialsAndNewContact()
        {           

            ContactDTOFromUser contactEntry = JsonReaderUtility.GetContactEntryFromJsonFile();
            AppUserDTOFromUser user = JsonReaderUtility.GetAppUserFromJsonFile();

            yield return new TestCaseData(user, contactEntry);
        }
    }
}
