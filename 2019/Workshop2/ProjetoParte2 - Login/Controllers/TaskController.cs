using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workshop2019UMParte1.Models;

namespace Workshop2019UMParte1.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly UserContext _context;
        public TaskController(UserContext context)
        {
            _context = context;
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

        [HttpPost]
        public IActionResult Add([FromBody] Models.Task task)
        {
            _context.task.Add(task);
            _context.SaveChanges();
            return new CreatedResult($"/api/task/{task.codigo}", task);
        }



    }
}