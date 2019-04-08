using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Models;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public User[] Get()
        {
            return new[] {
                    new User() {codigo = 1, nome = "Ugo", email =
                        "teste@gmail.com"}, new User() {codigo = 2, nome = "Simone", email= "Chiaretta@gmail.com"} };
        }

        [HttpGet("{codigo}")]
        public User Get(int codigo)
        {
            var users = new[] {
                    new User() {codigo = 1, nome = "Ugo", email =
                            "Lattanzi@gmail.com"}, new User() {codigo = 2, nome = "Simone", email = "Chiaretta@gmail.com"} };
            return users.FirstOrDefault(x => x.codigo == codigo);
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            var users = new List<User>();
            users.Add(user);
            return new CreatedResult($"/api/user/{user.codigo}", user);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int codigo)
        {
            var users = new[] {
                      new User() {codigo = 1, nome = "Ugo", email =
                              "Lattanzi@gmail.com"}, new User() {codigo = 2, nome = "Simone", email = "Chiaretta@gmail.com"} };
            var user = users.SingleOrDefault(x => x.codigo == codigo);
            if (user != null)
            {
                users.ToList().Remove(user);
                return new EmptyResult();
            }

            return new NotFoundResult();
        }
    }
    }