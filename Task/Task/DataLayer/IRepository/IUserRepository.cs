using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.DataLayer.IRepository
{
    public interface IUserRepository
    {
        void InitData();
        List<User> GetAllUsers();
        void UpdateUser(User user);
        int TotalActiveUsersCount();
        int TotalUsersCount();
    }
}
