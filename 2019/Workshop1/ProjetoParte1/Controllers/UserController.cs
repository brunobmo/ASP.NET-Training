using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
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
            /**return new[] {
                    new User() {codigo = 1, nome = "Ugo", email =
                        "teste@gmail.com"}, new User() {codigo = 2, nome = "Simone", email= "Chiaretta@gmail.com"} };
    */
           return  _context.user.ToArray();
        }
        [HttpGet("{codigo}")]
        public ActionResult Get(int codigo)
        {
            /**
            var users = new[] {
                    new User() {codigo = 1, nome = "Ugo", email =
                            "Lattanzi@gmail.com"}, new User() {codigo = 2, nome = "Simone", email = "Chiaretta@gmail.com"} };
            return users.FirstOrDefault(x => x.codigo == codigo);
           */
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
            //var users = new List<User>();
            //users.Add(user);
            _context.user.Add(user);
            _context.SaveChanges();
            return new CreatedResult($"/api/user/{user.codigo}", user);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int codigo)
        {
            /**  var users = new[] {
                      new User() {codigo = 1, nome = "Ugo", email =
                              "Lattanzi@gmail.com"}, new User() {codigo = 2, nome = "Simone", email = "Chiaretta@gmail.com"} };
              var user = users.SingleOrDefault(x => x.codigo == id);
              if (user != null)
              {
                  users.ToList().Remove(user);
                  return new EmptyResult();
              }

              return new NotFoundResult();
          */
            var user = _context.user.Find(codigo);

            if (user == null)
            {
                return NotFound();
            }
            _context.user.Remove(user);
            _context.SaveChanges();
            return NoContent();

        }
        
        [HttpGet("gettasks/{codigo}")]
        public IActionResult getUserTasks(int codigo)
        {
            var user = _context.user.Find(codigo);

            if (user == null)
            {
                return NotFound();
            }
            var tasks = _context.task.Where(s=>s.user_id == codigo);
            foreach (Models.Task t in tasks)
            {
                user.Tasks.Add(t);
            }
        

            return Ok(user);
        }
    

    }
}