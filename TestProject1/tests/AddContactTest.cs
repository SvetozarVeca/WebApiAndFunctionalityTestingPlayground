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

            ContactEntry contactEntry = ConvertJsonToContactEntry();
            AppUser user = ConvertJsonToAppUser();

            yield return new TestCaseData(user, contactEntry);
        }
    }
}
