using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.BusinessLogicLayer.DTO;

namespace Task.BusinessLogicLayer.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
        void UpdateUser(User user);
        UsersCountResult GetUsersCountInfo();
        
    }
}
