using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Data;
using BankApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private BankDBContext db;
        public UserController(BankDBContext _db)
        {
            db = _db;
        }

        // GET: api/User
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {

            try
            {
                var useraa = db.User.ToList();
                return Ok(useraa);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        // POST: api/Account
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser users)
        {
            try
            {
                
                bool log = db.User.ToList().Where(u => u.Username.Equals(users.username) && u.password.Equals(users.password)).Count()>0;
                
                if (log) {

                    User user = db.User.Where(ur => ur.Username.Equals(users.username)).FirstOrDefault();
                    string NewSessionId = System.Guid.NewGuid().ToString();
                    Session session = null;
                    session = new Session()
                    {
                        SessionID = NewSessionId,
                        UserID = user.Id
                    };

                    if (session.UserID == session.UserID)
                    {
                        db.Session.Add(session);
                    }
                    else
                    {
                       db.Entry(session).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return Ok(user);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Account
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("LogOut/{id}")]
        public async Task<IActionResult> Logout(String id)
        {
            try
            {
                Session session = db.Session.Where(ur => ur.UserID.Equals(id)).FirstOrDefault();

                db.Remove(db.Session.Find(session.SessionID));
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        private bool hasSesssion(string userId) {
            return db.Session.Count(s => s.UserID.Equals(userId))>0;
        }

    }
}
