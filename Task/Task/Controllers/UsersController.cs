using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Model; 
namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApplicationContext db;

        public UsersController(ApplicationContext context)
        {
            db = context;
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

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.users.ToList();
        }

        [HttpPut]
        public IActionResult Check(User user)
        {

            if (ModelState.IsValid)
            {
                db.Update(user);
                db.SaveChanges();
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

    }
}
