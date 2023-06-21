using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AppUserDTOFromUser
    {
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        
    }
   
}