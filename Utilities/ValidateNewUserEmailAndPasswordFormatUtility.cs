using System.Net.Mail;

namespace Utilities
{
    public static class ValidateNewUserEmailAndPasswordFormatUtility
    {
        public static bool IsEmailValidFormat(string email)
        {
            try
            {
                _ = new MailAddress(email);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static bool IsPasswordValid(string password)
        {
            return password.Length > 6;
        }
    }
}
