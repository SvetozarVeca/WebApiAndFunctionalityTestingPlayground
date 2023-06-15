using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.utilities
{
    public static class ValidateNewUserEmailAndPasswordFormat
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
