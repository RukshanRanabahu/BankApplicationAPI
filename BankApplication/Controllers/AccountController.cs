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
    public class AccountController : ControllerBase
    {
        private BankDBContext db;
        public AccountController(BankDBContext _db)
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
                var useraa = db.Account.ToList();
                return Ok(useraa);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // GET: api/Product/5
        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(string id)
        {
            try
            {
                var products = db.Account.SingleOrDefault(p => p.AccountId == id);
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        // POST: api/Account
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Account acc)
        {
            try
            {
                db.Account.Add(acc);
                db.SaveChanges();
                return Ok(acc);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT: api/Product/5
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Account acc)
        {
            try
            {
                db.Entry(acc).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(acc);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(String id)
        {
            try
            {
                db.Remove(db.Account.Find(id));
                db.SaveChanges();
                return Ok("success");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
