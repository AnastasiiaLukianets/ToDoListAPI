using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskToDoController : ControllerBase
    {
        private static List<TaskToDo> tasks = new List<TaskToDo>
        {
            new TaskToDo
                {
                    Id = 1,
                    DescriptionText = "Book hotel",
                    DueDate = DateTime.Parse("22/7/2022  8:30:52 AM"),
                    IsCompleted = false
                },
                new TaskToDo
                {
                    Id = 2,
                    DescriptionText = "Buy bus ticket",
                    DueDate = DateTime.Parse("20/7/2022 8:30:52 AM"),
                    IsCompleted = false
                }
        };
        private readonly DataContext _context;

        public TaskToDoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskToDo>>> Get()
        {
            //return Ok(tasks);
            return Ok(await _context.TasksToDo.ToListAsync()); // call to the service 1 to 1 
            // no instance of context in controller
            // git
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskToDo>> Get(int id)
        {
            //var task = tasks.Find(x => x.Id == id);
            var task = await _context.TasksToDo.FindAsync(id);
            if (task == null)
            {
                //return BadRequest("Task not found."); // Rest convention
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskToDo>>> AddTaskToDo(TaskToDo task)
        {
            //tasks.Add(task);
            //return Ok(tasks);
            _context.TasksToDo.Add(task); // changes in table
            await _context.SaveChangesAsync(); // save changes in DB table

            return Ok(await _context.TasksToDo.ToListAsync());
            // new object return
            // 200 -> 201 status code
        }

        [HttpPut]
        public async Task<ActionResult<List<TaskToDo>>> UpdateTaskToDo(TaskToDo request)
        {
            /*
            var task = tasks.Find(x => x.Id == request.Id);
            if (task == null)
                return BadRequest("Task not found.");

            task.DescriptionText = request.DescriptionText;
            task.IsCompleted = request.IsCompleted;
            task.DueDate = request.DueDate;

            return Ok(tasks);
            */

            var dbTaskToDo = await _context.TasksToDo.FindAsync(request.Id);
            if (dbTaskToDo == null)
                return BadRequest("Task not found.");

            dbTaskToDo.DescriptionText = request.DescriptionText;
            dbTaskToDo.IsCompleted = request.IsCompleted;
            dbTaskToDo.DueDate = request.DueDate;

            await _context.SaveChangesAsync(); // save changes in DB table

            return Ok(await _context.TasksToDo.ToListAsync()); // not the hole list return for performance reasons
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaskToDo>>> Delete(int id)
        {
            //var task = tasks.Find(x => x.Id == id);
            var task = await _context.TasksToDo.FindAsync(id);
            if (task == null)
                return BadRequest("Task to delete not found.");

            //tasks.Remove(task);
            _context.TasksToDo.Remove(task);
            await _context.SaveChangesAsync(); // save changes in DB table

            return Ok(tasks);
        }
    }
}
