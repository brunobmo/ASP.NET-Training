using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly UserContext _context;

        public TaskController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        //[Route("[action]")]
        public IActionResult Add([FromBody] Models.Task task)
        {
           // Models.Task task = new Models.Task() {nome = "tarefa1", data = new DateTime(2018,05,14), user_id = 1 };
            _context.task.Add(task);
            _context.SaveChanges();
            return new CreatedResult($"/api/task/{task.codigo}", task);
        }

        [HttpGet("{codigo}")]
        public ActionResult Get(int codigo)
        {
            var task = _context.task.Find(codigo);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
    }
}