using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workshop2019UMParte1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Workshop2019UMParte1
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public User[] Get()
        {
            return _context.user.ToArray();
        }
    

        [HttpGet("{codigo}")]
        public ActionResult Get(int codigo)
        {
            var user = _context.user.Find(codigo);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            _context.user.Add(user);
            _context.SaveChanges();
            return new CreatedResult($"/api/user/{user.codigo}", user);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int codigo)
        {
            var user = _context.user.Find(codigo);

            if (user == null)
            {
                return NotFound();
            }
            _context.user.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}