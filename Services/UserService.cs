using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : BaseService, IUserService
            {
        public async Task<string?> AddUser(AppUserDTOFromUser user)
        {
            await LogInAndAuthorize();

            string uri = "https://thinking-tester-contact-list.herokuapp.com/users";

            HttpResponseMessage result = await HttpClient.PostAsJsonAsync(uri, user);

            return result.ReasonPhrase;
        }
    }
}
