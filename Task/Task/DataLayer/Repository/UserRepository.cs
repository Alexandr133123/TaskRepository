using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.DataLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Task.DataLayer.Database;
namespace Task.DataLayer.Repository
{
    public class UserRepository: IUserRepository
    {
    
        private ApplicationContext db;

        public UserRepository(ApplicationContext dbContext)
        {
            db = dbContext;

        }

        public List<User> GetAllUsers()
        {
            return db.users.ToList();
        }

        public void InitData()
        {
            if (!db.users.Any())
            {
                db.users.Add(new User { Name = "Alan" });
                db.users.Add(new User { Name = "Tom" });
                db.users.Add(new User { Name = "Bob" });
                db.users.Add(new User { Name = "Christina" });
                db.users.Add(new User { Name = "Alice" });
                db.users.Add(new User { Name = "Daniel" });
                db.users.Add(new User { Name = "Alexandr" });
                db.users.Add(new User { Name = "Bill" });
                db.users.Add(new User { Name = "Michael" });
                db.users.Add(new User { Name = "Mark" });
                db.SaveChanges();

                
            }
            
        }
           
        public int TotalUsersCount()
        {
            return db.users.Count();
        }

        public int TotalActiveUsersCount()
        {
            int active = 0;
            foreach(User u in db.users)
            {
                if (u.Active)
                {
                    active++;
                }
            }
            return active;
        }

        public void UpdateUser(User user)
        {
            db.users.Update(user);
            db.SaveChanges();
        }

    }
}
