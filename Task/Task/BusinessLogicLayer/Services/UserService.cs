using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.BusinessLogicLayer.IServices;
using Task.DataLayer.Repository;
using Task.DataLayer.IRepository;
using Task.BusinessLogicLayer.DTO;
namespace Task.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userRepository.InitData();
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = _userRepository.GetAllUsers().ToList();
            return users;

        }
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
           
        }

        public UsersCountResult GetUsersCountInfo()
        {
            UsersCountResult result = new UsersCountResult();
            result.totalCount = _userRepository.TotalUsersCount();
            result.activeCount = _userRepository.TotalActiveUsersCount();

            return result;
        }

    }
}
