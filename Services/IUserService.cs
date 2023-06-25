using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        public Task<string?> AddUser(AppUserDTOFromUser user);       

    }
}
